using System;
using System.Diagnostics;

namespace AppAutomation
{
    public class AppiumHelper
    {
        // private static Process appiumProcess;

        public Process appiumProcess{get;set;}
        private string nodePath;
        private string appiumPath;
        private string androidSdkPath;
        private int appiumPort;
        
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
