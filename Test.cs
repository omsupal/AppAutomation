using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using Xunit;
using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Appium.Service;
using AppAutomation.Utility;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System.Drawing;
using OpenQA.Selenium.Appium.MultiTouch;

namespace AppAutomation
{
    public class AppiumAndroidTest : IClassFixture<AppiumFixture>
    {
        // public static AppiumDriver<AndroidElement> driver;
        Random rndom;

        [Fact]
        public void AnimationSampleTestCase()
        {
            rndom = new Random();
            // Your test logic goes here
            // For example, you can find an element and interact with it:
            AndroidElement animationbtn = AppiumFixture.Driver.FindElementByAccessibilityId("Animation");
            animationbtn.Click();
            AndroidElement bouncingballbtn = AppiumFixture.Driver.FindElementByAccessibilityId("Bouncing Balls");
            bouncingballbtn.Click();
            AndroidElement clicktoanimate = AppiumFixture.Driver.FindElementByClassName("android.view.View");
            clicktoanimate.Click();
            TouchAction tapOptions = new TouchAction(AppiumFixture.Driver);
            for (int i = 0; i <= 10; i++)
            {
                int xCoordinate = rndom.Next(100, 800); // Adjust the range as needed
                int yCoordinate = rndom.Next(200, 1000);
                tapOptions.Tap(xCoordinate, yCoordinate).Perform();
            }
            AppiumFixture.Driver.PressKeyCode(new KeyEvent().WithKeyCode(AndroidKeyCode.Back));
        }
        [Fact]
        public void DropDownSampleTestCase()
        {
            rndom = new Random();
            // Your test logic goes here
            // For example, you can find an element and interact with it:
            AndroidElement Appbtn = AppiumFixture.Driver.FindElementByAccessibilityId("App");
            Appbtn.Click();
            AndroidElement Menubtn = AppiumFixture.Driver.FindElementByXPath("//android.widget.TextView[@content-desc='Menu']");
            Menubtn.Click();
            AndroidElement ClickTitle = AppiumFixture.Driver.FindElementById("android:id/text1");
            ClickTitle.Click();
            AndroidElement title = AppiumFixture.Driver.FindElementById("io.appium.android.apis:id/spinner");
            title.Click();
            AndroidElement listView = AppiumFixture.Driver.FindElementByClassName("android.widget.ListView");

            AppiumFixture.Driver.PressKeyCode(new KeyEvent().WithKeyCode(AndroidKeyCode.Back));
        }
        [Fact]
        public void AutoComplete()
        {
            // Your test logic goes here
            // For example, you can find an element and interact with it:
            AndroidElement Viewsbtn = AppiumFixture.Driver.FindElementByAccessibilityId("Views");
            Viewsbtn.Click();
            AndroidElement AutoCompletebtn = AppiumFixture.Driver.FindElementByXPath("//android.widget.TextView[@content-desc='Auto Complete']");
            AutoCompletebtn.Click();
            AndroidElement Screentopbtn = AppiumFixture.Driver.FindElementByAccessibilityId("1. Screen Top");
            Screentopbtn.Click();
            AndroidElement title = AppiumFixture.Driver.FindElementById("io.appium.android.apis:id/edit");
            title.SendKeys("india");
            // Find and click on the desired autocomplete suggestion
            AndroidElement autocompleteSuggestion = AppiumFixture.Driver.FindElementByAndroidUIAutomator("//android.widget.ListView/android.widget.TextView[@text='British Indian Ocean Territory']");
            autocompleteSuggestion.Click();

            AppiumFixture.Driver.PressKeyCode(new KeyEvent().WithKeyCode(AndroidKeyCode.Back));
        }


    }
}
