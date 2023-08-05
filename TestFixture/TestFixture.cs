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
        public static AndroidDriver<AndroidElement> Driver{get;set;}

        public AppiumFixture()
        {
            // Initialize and start the Appium server here if needed
            AppiumHelper.StartServer();

            Thread.Sleep(9000);
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "pixel_3a");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "13.0");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            appiumOptions.AddAdditionalCapability("automationName", "UiAutomator2");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Users\OmkarSupal\Documents\AppAutomation\apk\ApiDemos.apk");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, true);
            try
            {
                string appiumServerUrl = "http://127.0.0.1:4723/wd/hub";
                Uri appiumUri = new(appiumServerUrl);
                Driver = new AndroidDriver<AndroidElement>(appiumUri, appiumOptions);
                // AppiumHelper.HandlePopups();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            // Set an implicit wait to handle latency
            // Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void Dispose()
        {
            // Quit the Driver after all the tests have executed
            Driver.Quit();
            if (AppiumHelper.AppiumProcess != null && !AppiumHelper.AppiumProcess.HasExited)
            {
                // Stop the Appium server
                AppiumHelper.AppiumProcess.Kill();
                AppiumHelper.AppiumProcess.Dispose();
                AppiumHelper.AppiumProcess = null;
            }
        }
    }
}