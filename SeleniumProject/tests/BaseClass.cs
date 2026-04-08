using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework.Interfaces;

public class BaseClass
{
    protected IWebDriver driver;
    protected WebDriverWait wait;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();

        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        driver.Manage().Window.Size = new Size(1024, 768);
    }

    [TearDown]
    public void Teardown()
    {
        // Only take screenshot if test failed
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            TakeScreenshot();
        }

        if (driver != null)
        {
            driver.Quit();
            driver.Dispose();
        }
    }

    private void TakeScreenshot()
    {
        try
        {
            ITakesScreenshot ssDriver = driver as ITakesScreenshot;
            Screenshot screenshot = ssDriver.GetScreenshot();

            string screenshotDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "screenshots");
            Directory.CreateDirectory(screenshotDir); // Creates folder if it doesn't exist

            string fileName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            string filePath = Path.Combine(screenshotDir, fileName);

            screenshot.SaveAsFile(filePath);

            // Attach to NUnit report
            TestContext.AddTestAttachment(filePath, "Failure Screenshot");
            TestContext.WriteLine($"Screenshot saved to: {filePath}");
        }
        catch (Exception ex)
        {
            TestContext.WriteLine($"Failed to take screenshot: {ex.Message}");
        }
    }
}