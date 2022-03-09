using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Net.Http;
using OpenQA.Selenium.Interactions;

namespace WebScraping;
public class Program
{
    static void Main(string[] args)
    {
        Console.Write("Search For : ");
        string searchItem = Console.ReadLine();
        trendYol(searchItem);
    }
    static void tapAz(string searchItem)
    {
        IWebDriver driver = new ChromeDriver(@"C:\Users\User\OneDrive - Baku Higher Oil School\Desktop\Web Dev\2 - backend\WebScraping\bin\Debug");
        driver.Navigate().GoToUrl("https://www.tap.az/");
        var element = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[2]/form/div[1]/input"));
        element.SendKeys(searchItem);
        element.Submit();
        int i = 0;
        int k = 0;
        var links = driver.FindElements(By.XPath("//*[@id=\"content\"]/div/div/div[2]/div[2]/div/div/a/div[3]"));
        var prices = driver.FindElements(By.XPath("//*[@id=\"content\"]/div/div/div[2]/div[2]/div/div/a/div[2]/div"));
        while (i < prices.Count && i < 10 && k < 10)
        {
            Console.Write(links[i].Text + " --- ");
            Console.WriteLine(prices[k].Text);
            Console.WriteLine();
            i++;
        }
        driver.Quit();
    }
    static void trendYol(string searchItem)
    {
        IWebDriver trendYol = new ChromeDriver(@"C:\Users\User\OneDrive - Baku Higher Oil School\Desktop\Web Dev\2 - backend\WebScraping\bin\Debug");
        trendYol.Navigate().GoToUrl("https://www.trendyol.com/");
        var element = trendYol.FindElement(By.XPath("//*[@id=\"country-selection\"]/div/div/div[2]/div[2]/select"));
        var selectElement = new SelectElement(element);
        selectElement.SelectByText("Turkey");
        var submitting = trendYol.FindElement(By.XPath("//*[@id=\"country-selection\"]/div/div/div[2]/div[4]/button"));
        submitting.Click();
        var searchBox = trendYol.FindElement(By.XPath("//*[@id=\"auto-complete-app\"]/div/div/input"));
        searchBox.SendKeys(searchItem + '\n');
        int i = 0;
        int k = 0;
        var links = trendYol.FindElements(By.XPath("//*[@id=\"search-app\"]/div/div[1]/div[2]/div/div/div/div[1]/a/div[2]/div[1]"));
        var prices = trendYol.FindElements(By.XPath("//*[@id=\"search-app\"]/div/div[1]/div[2]/div/div/div/div[1]/a/div[2]/div[3]/div[1]/div"));
        var discount = trendYol.FindElements(By.XPath("//*[@id=\"search-app\"]/div/div[1]/div[2]/div[4]/div/div/div[1]/a/div[2]/div[3]/div[2]/div/div[2]"));
        while (i < 10 && k < 10 && i < links.Count)
        {
            Console.Write(links[i].Text + " --- ");
            Console.WriteLine(prices[k].Text + " endirimli --- " + discount[k].Text);
            Console.WriteLine();
            i++;
            k++;
        }
        trendYol.Quit();
    }
}