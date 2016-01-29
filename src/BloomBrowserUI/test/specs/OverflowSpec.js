"use strict";
import 'jasmine-jquery';
import OverflowChecker from '../../bookEdit/OverflowChecker/OverflowChecker';

//hello
var consoleDef = false;

jQuery.fn.RunTests = function() {
    $.each(this, RunTest);
};


jQuery.fn.RunAncestorMarginTests = function() {
    $.each(this, RunAncestorMarginTest);
};

var RunTest = function(index, value) {
    var testHtml = $(value);
    var nameAttr = testHtml.attr("name");
    if(typeof nameAttr === 'undefined')
        nameAttr = '***** This test needs a name! *****';
    if(consoleDef)
        console.log('\nBeginning test # '+ index + ' ' + nameAttr);
    var overflowingSelf = OverflowChecker.IsOverflowingSelf(testHtml[0]);
    var testExpectation = testHtml.hasClass('expectToOverflow');
    if(consoleDef) {
        console.log('  scrollH: ' + testHtml[0].scrollHeight + ' clientH: ' + testHtml[0].clientHeight);
        console.log('    Height: ' + testHtml.height());
        var styleAttr = testHtml.attr("style");
        if(typeof styleAttr === 'undefined')
            styleAttr = 'No styles';
        console.log('   Test Style: ' + styleAttr);
        var cs = window.getComputedStyle(testHtml[0], null);
        var lineH = cs.getPropertyValue('line-height');
        var fontS = cs.getPropertyValue('font-size');
        var font = cs.getPropertyValue('font-family');
        var padding = cs.getPropertyValue('padding');
        console.warn('     Computed Style: line-height ' + lineH + ' font-size ' + fontS + ' padding ' + padding);
        console.warn('     OverflowSelf: ' + overflowingSelf + ' font: ' + font);
        console.warn('     Expecting: ' + testExpectation); // added this because the failure message is not always immediately after the test output
    }
    expect(overflowingSelf).toBe(testExpectation);
};

var RunAncestorMarginTest = function(index, value) {
    var testHtml = $(value);
    var nameAttr = testHtml.attr("name");
    if(typeof nameAttr === 'undefined')
        nameAttr = '***** This test needs a name! *****';
    if(consoleDef)
        console.log('\nBeginning test # '+ index + ' ' + nameAttr);
    var overflowingAncestor = OverflowChecker.overflowingAncestor(testHtml[0]);
    var overflowingMargins = overflowingAncestor != null;
    var testExpectation = testHtml.hasClass('expectToOverflow');
    if(consoleDef) {
        console.log('  scrollH: ' + testHtml[0].scrollHeight + ' clientH: ' + testHtml[0].clientHeight);
        console.log('    Height: ' + testHtml.height());
        var styleAttr = testHtml.attr("style");
        if(typeof styleAttr === 'undefined')
            styleAttr = 'No styles';
        console.log('   Test Style: ' + styleAttr);
        var cs = window.getComputedStyle(testHtml[0], null);
        var lineH = cs.getPropertyValue('line-height');
        var fontS = cs.getPropertyValue('font-size');
        var font = cs.getPropertyValue('font-family');
        var padding = cs.getPropertyValue('padding');
        console.warn('     Computed Style: line-height ' + lineH + ' font-size ' + fontS + ' padding ' + padding);
        console.warn('     OverflowMargins: ' + overflowingMargins + ' font: ' + font);
        console.warn('     Expecting: ' + testExpectation); // added this because the failure message is not always immediately after the test output
    }
    expect(overflowingMargins).toBe(testExpectation);
};

// Uses jasmine-query-1.3.1.js
describe("Overflow Tests", function () {
    jasmine.getFixtures().fixturesPath = 'base/test/fixtures';

    // these tests are only reliable when tested with Firefox
    if (navigator.userAgent.indexOf('Firefox') === -1) {
        console.log('Overflow tests are only run on Firefox.');
        return;
    }

    it("Check test page for Self overflows", function() {
        loadFixtures('OverflowTestPage.html');
        expect($('#jasmine-fixtures')).toBeTruthy();
        if(window.console && window.console.log) {
            consoleDef = true;
            console.log('Commencing Overflow tests...');
        }
        $(".myTest").RunTests();
    });

    it("Check test page for Margin overflows", function() {
        loadFixtures('OverflowMarginTestPage.html');
        expect($('#jasmine-fixtures')).toBeTruthy();
        if(window.console && window.console.log) {
            consoleDef = true;
            console.log('Commencing Margin Overflow tests...');
        }
        $(".myTest").RunAncestorMarginTests();
    });

    it("Check test page for Fixed Ancestor overflows", function() {
        loadFixtures('OverflowAncestorTestPage.html');
        expect($('#jasmine-fixtures')).toBeTruthy();
        if(window.console && window.console.log) {
            consoleDef = true;
            console.log('Commencing Fixed Ancestor Overflow tests...');
        }
        $(".myTest").RunAncestorMarginTests();
    });
});