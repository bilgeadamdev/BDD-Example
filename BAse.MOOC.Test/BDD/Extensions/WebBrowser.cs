using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace BAse.MOOC.Test.BDD.Extensions
{
    internal static class WebBrowser
    {
        private static readonly string _baseUrl = "https://localhost:44353";
        public static IWebDriver Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey("browser"))
                {
                    ScenarioContext.Current["browser"] = new ChromeDriver(".");
                }

                return ScenarioContext.Current["browser"] as IWebDriver;
            }
        }

        public static string GetUrl(string pageName) =>
            _baseUrl + "/" + (pageName == "home" ? string.Empty : pageName);

        public static IWebElement FindByAria(string label, string role)
        {
            var selector = $"[aria-label=\"{label}\"][role={role}]";
            Thread.Sleep(5000);
            return WebBrowser.Current?.FindElement(By.CssSelector(selector));
        }

        public static string Url
        {
            get => WebBrowser.Current.Url;
            set => WebBrowser.Current.Navigate().GoToUrl(value);
        }
    }
}
