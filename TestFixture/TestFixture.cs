using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using Xunit;
using OpenQA.Selenium.Appium.Service;
using System.Threading;
using System.Net.Http;

namespace AppAutomation
{
    public class AppiumFixture : IDisposable
    {
        public static AndroidDriver<AndroidElement> driver;

        public AppiumFixture()
        {
            // Initialize and start the Appium server here if needed
            AppiumHelper.startServer();

            // Thread.Sleep(9000);
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "pixel_3a");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "13.0");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            appiumOptions.AddAdditionalCapability("automationName", "UiAutomator2");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Users\OmkarSupal\Documents\AppAutomation\apk\ApiDemos.apk");

            try
            {
                string appiumServerUrl = "http://127.0.0.1:4723/wd/hub";
                Uri appiumUri = new Uri(appiumServerUrl);
                driver = new AndroidDriver<AndroidElement>(appiumUri, appiumOptions);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            // Set an implicit wait to handle latency
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void Dispose()
        {
            // Quit the driver after all the tests have executed
            driver.Quit();

            // Kill the Appium server process if it hasn't exited
            if (!AppiumHelper.appiumProcess.HasExited)
                AppiumHelper.appiumProcess.Kill();
        }
    }
}