﻿using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using Bloom.Collection;
using SIL.Extensions;
using SIL.Text;
using SIL.Windows.Forms.ClearShare;

namespace Bloom.Book
{
	/// <summary>
	/// Reads and writes the aspects of the book related to copyright, license, license logo, etc.
	/// That involves three duties:
	/// 1) Serializing/Deserializing a libpalaso.ClearShare.Metadata to/from the bloomDataDiv of the html
	/// 2) Propagating that information into template fields found in the pages of the book (normally just the credits page)
	/// 3) Placing the correct license image into the folder
	/// </summary>
	public class BookCopyrightAndLicense
	{
		/// <summary>
		/// Create a Clearshare.Metadata object by reading values out of the dom's bloomDataDiv
		/// </summary>
		public static Metadata GetMetadata(HtmlDom dom)
		{
			var metadata = new Metadata();
			if (ShouldSetToDefaultLicense(dom))
			{
				//start the book off with a simple cc-by
				metadata.License = new CreativeCommonsLicense(true, true, CreativeCommonsLicense.DerivativeRules.Derivatives);
				return metadata;
			}

			var copyright = dom.GetBookSetting("copyright");
			if (!copyright.Empty)
			{
				metadata.CopyrightNotice = WebUtility.HtmlDecode(copyright.GetFirstAlternative());
			}

			var licenseUrl = dom.GetBookSetting("licenseUrl").GetBestAlternativeString(new[] { "*", "en" });

			if (string.IsNullOrWhiteSpace(licenseUrl))
			{
				//NB: we are mapping "RightsStatement" (which comes from XMP-dc:Rights) to "LicenseNotes" in the html.
				//custom licenses live in this field, so if we have notes (and no URL) it is a custom one.
				var licenseNotes = dom.GetBookSetting("licenseNotes");
				if (!licenseNotes.Empty)
				{
					metadata.License = new CustomLicense { RightsStatement = WebUtility.HtmlDecode(licenseNotes.GetFirstAlternative()) };
				}
				else
				{
					// The only remaining current option is a NullLicense
					metadata.License = new NullLicense(); //"contact the copyright owner
				}
			}
			else // there is a licenseUrl, which means it is a CC license
			{
				metadata.License = CreativeCommonsLicense.FromLicenseUrl(licenseUrl);

				//are there notes that go along with that?
				var licenseNotes = dom.GetBookSetting("licenseNotes");
				if (!licenseNotes.Empty)
					metadata.License.RightsStatement = WebUtility.HtmlDecode(licenseNotes.GetFirstAlternative());
			}
			return metadata;
		}

		/// <summary>
		/// Call this when we have a new set of metadata to use. It 
		/// 1) sets the bloomDataDiv with the data, 
		/// 2) causes any template fields in the book to get the new values
		/// 3) updates the license image on disk
		/// </summary>
		public static void SetMetadata(Metadata metadata, HtmlDom dom, string bookFolderPath, CollectionSettings collectionSettings)
		{
			dom.SetBookSetting("copyright","*",metadata.CopyrightNotice);
			dom.SetBookSetting("licenseUrl","*",metadata.License.Url);
			string languageUsedForDescription;

			//This part is unfortunate... the license description, which is always localized, doesn't belong in the datadiv; it
			//could instead just be generated when we update the page. However, for backwards compatibility (prior to 3.6),
			//we localize it and place it in the datadiv.
			dom.RemoveBookSetting("licenseDescription");
			var description = metadata.License.GetDescription(collectionSettings.LicenseDescriptionLanguagePriorities, out languageUsedForDescription);
			dom.SetBookSetting("licenseDescription", languageUsedForDescription, description);

			dom.SetBookSetting("licenseNotes", "*", metadata.License.RightsStatement);

			// we could do away with licenseImage in the bloomDataDiv, since the name is always the same, but we keep it for backward compatibility
			if (metadata.License is CreativeCommonsLicense)
			{
				dom.SetBookSetting("licenseImage", "*", "license.png");
			}
			else
			{
				//CC licenses are the only ones we know how to show an image for
				dom.RemoveBookSetting("licenseImage");
			}


			UpdateDomFromDataDiv(dom, bookFolderPath, collectionSettings);
		}

		/// <summary>
		/// Propagating the copyright and license information in the bloomDataDiv to template fields 
		/// found in the pages of the book (normally just the credits page).
		/// </summary>
		/// <remarks>This is "internal" just as a convention, that it is accessible for testing purposes only</remarks>
		internal static void UpdateDomFromDataDiv(HtmlDom dom, string bookFolderPath, CollectionSettings collectionSettings)
		{
			CopyItemToFieldsInPages(dom, "copyright");
			CopyItemToFieldsInPages(dom, "licenseUrl");
			CopyItemToFieldsInPages(dom, "licenseDescription", languagePreferences:collectionSettings.LicenseDescriptionLanguagePriorities.ToArray());
			CopyItemToFieldsInPages(dom, "licenseNotes");
			CopyItemToFieldsInPages(dom, "licenseImage", valueAttribute:"src");

			if(!String.IsNullOrEmpty(bookFolderPath)) //unit tests may not be interested in checking this part
				UpdateBookLicenseIcon(GetMetadata(dom), bookFolderPath);
		}

		private static void CopyItemToFieldsInPages(HtmlDom dom, string key, string valueAttribute = null, string[] languagePreferences= null)
		{
			if (languagePreferences == null)
				languagePreferences = new[] {"*", "en"};

            MultiTextBase source = dom.GetBookSetting(key);

			var target = dom.SelectSingleNode("//*[@data-derived='" + key + "']");
			if (target == null)
			{
				return;
			}
			

			//just put value into the text of the element
			if (string.IsNullOrEmpty(valueAttribute))
			{
				//clear out what's there now
				target.RemoveAttribute("lang");
				target.InnerText = "";

				var form = source.GetBestAlternative(languagePreferences);
				if (form != null && !string.IsNullOrWhiteSpace(form.Form))
				{
					target.InnerText = form.Form;
					target.SetAttribute("lang", form.WritingSystemId); //this allows us to set the font to suit the language
				}
			}
			else //Put the value into an attribute. The license image goes through this path.
			{
				target.SetAttribute(valueAttribute, source.GetBestAlternativeString(languagePreferences));
				if (source.Empty)
				{
					//if the license image is empty, make sure we don't have some alternative text 
					//about the image being missing or slow to load
					target.SetAttribute("alt", "");
					//over in javascript land, @alt will get set appropriately when the image url is not empty.
				}
			}
		}

		/// <summary>
		/// Get the license from the metadata and save it.
		/// </summary>
		private static void UpdateBookLicenseIcon(Metadata metadata, string bookFolderPath)
		{
			var licenseImage = metadata.License.GetImage();
			var imagePath = bookFolderPath.CombineForPath("license.png");
			if (licenseImage != null)
			{
				using (Stream fs = new FileStream(imagePath, FileMode.Create))
				{
					licenseImage.Save(fs, ImageFormat.Png);
				}
			}
			else
			{
				if (File.Exists(imagePath))
					File.Delete(imagePath);
			}
		}

		private static bool ShouldSetToDefaultLicense(HtmlDom dom)
		{
			var hasCopyright = !dom.GetBookSetting("copyright").Empty;
			var hasLicenseUrl = !dom.GetBookSetting("licenseUrl").Empty;
			var hasLicenseNotes = !dom.GetBookSetting("licenseNotes").Empty;

			//Enhance: this logic is perhaps overly restrictive?
			return !hasCopyright && !hasLicenseUrl && !hasLicenseNotes;
		}
	}
}