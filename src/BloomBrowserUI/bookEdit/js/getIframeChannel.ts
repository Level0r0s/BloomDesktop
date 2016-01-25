/// <reference path="interIframeChannel.ts" />
/**
 * Finds the interIframeChannel on the main document
 */
export default function getIframeChannel(): interIframeChannel {

  if (typeof document["interIframeChannel"] === 'object') {
    return document["interIframeChannel"];
  }
  else if (typeof window.parent["interIframeChannel"] === 'object') {
    return window.parent["interIframeChannel"];
  }
  console.debug('interIframeChannel not found');
  return null;
}
