using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using Xunit;
using OpenQA.Selenium.Appium.Service;
using System.Threading;

namespace AppAutomation
{
    public class AppiumAndroidTest : IClassFixture<AppiumFixture>
    {
        // public static AppiumDriver<AndroidElement> driver;

        [Fact]
        public void SampleTest()
        {
            // Your test logic goes here
            // For example, you can find an element and interact with it:
            // var element = AppiumFixture.driver.FindElementByAccessibilityId("Accessibility");
            // element.Click();

            // // Add your assertions here to verify the expected behavior
            // Assert.True(element.Displayed);
        }
        

        
    }
}
