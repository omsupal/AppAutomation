using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using Xunit;

namespace AppAutomation
{
    public class AppiumAndroidTest : IDisposable
    {
        private AppiumDriver<AndroidElement> driver;

        public AppiumAndroidTest()
        {
            // Set the Appium server URL (assuming it's running locally)
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "pixel_3a");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "13.0");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Users\OmkarSupal\Documents\AppAutomation\apk\ApiDemos.apk");

            // Initialize the AndroidDriver with the Appium server URL and capabilities
            driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), appiumOptions);

            // Set an implicit wait to handle latency
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Fact]
        public void SampleTest()
        {
            // Your test logic goes here
            // For example, you can find an element and interact with it:
            var element = driver.FindElementByAccessibilityId("your_element_accessibility_id");
            element.Click();
            
            // Add your assertions here to verify the expected behavior
            Assert.True(element.Displayed);
        }

        public void Dispose()
        {
            // Quit the driver after the test is done
            driver.Quit();
        }
    }
}
