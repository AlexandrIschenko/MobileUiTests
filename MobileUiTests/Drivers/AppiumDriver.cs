using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;

namespace MobileUiTests.Drivers
{
    class AppiumDriver
    {
        private AppiumDriver<AndroidElement> _driver;

        public AppiumDriver<AndroidElement> InitializeAppium()
        {
            var driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "9.0");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Huawei P30 Pro");
            //capabilities.SetCapability("appActivity", ".app.SearchInvoke");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.App, "C:\\Users\\Alex\\Desktop\\apps\\ApiDemos-debug.apk");

            var appiumService = new AppiumServiceBuilder()
                                .WithIPAddress("127.0.0.1")
                                .UsingAnyFreePort()
                                .Build();

            if(!appiumService.IsRunning)
                appiumService.Start();
           
            _driver = new AndroidDriver<AndroidElement>(appiumService, driverOptions, TimeSpan.FromSeconds(180));
            //_driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), driverOptions, TimeSpan.FromSeconds(180));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return _driver;
        }
    }
}
