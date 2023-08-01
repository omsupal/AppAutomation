using System;
using System.Diagnostics;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
namespace AppAutomation
{
    public static class AppiumHelper
    {

        public static Process appiumProcess { get; set; }
        private static string nodePath;
        private static string appiumPath;
        private static string androidSdkPath;
        private static int appiumPort;
        public static void startServer()
        {
            // Set the path to the Appium server executable
            string nodeJsPath = @"C:\Program Files\nodejs\node.exe";
            string appiumServerPath = @"C:\Users\OmkarSupal\AppData\Roaming\npm\node_modules\appium\build\lib\main.js"; // Update with your actual path

            // Start the Appium server process
            appiumProcess = new Process();
            appiumProcess.StartInfo.FileName = nodeJsPath;
            appiumProcess.StartInfo.Arguments = appiumServerPath + " --address 127.0.0.1 --port 4723"; // You can add any other Appium server arguments here
            appiumProcess.Start();
            Console.WriteLine(appiumProcess.Responding + "" + appiumProcess.SessionId);

        }
      

        public static void SetJAVA_HOMEANDROID_HOME()
        {
            string javaHome = @"C:\Program Files\Java\jdk-20";
            string androidHome = @"C:\Users\OmkarSupal\AppData\Local\Android\Sdk";
            string ANDROID_HOME = "ANDROID_HOME";
            string JAVA_HOME = "JAVA_HOME";

            try
            {
                // Get the current value of the environment variable
                string currentValueandroid = Environment.GetEnvironmentVariable(ANDROID_HOME, EnvironmentVariableTarget.User);
                string currentValuejava = Environment.GetEnvironmentVariable(JAVA_HOME, EnvironmentVariableTarget.User);


                currentValueandroid = androidHome;
                currentValuejava = javaHome;

                // Set the updated value back to the environment variable
                Environment.SetEnvironmentVariable(ANDROID_HOME, currentValueandroid, EnvironmentVariableTarget.User);
                Environment.SetEnvironmentVariable(JAVA_HOME, currentValuejava, EnvironmentVariableTarget.User);

                Console.WriteLine($"Environment variable '{ANDROID_HOME}' has been set to: {currentValueandroid}");
                Console.WriteLine($"Environment variable '{JAVA_HOME}' has been set to: {currentValuejava}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting environment variable: {ex.Message}");
            }
        }

    }
}
