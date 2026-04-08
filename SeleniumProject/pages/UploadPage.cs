using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public class UploadPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    private readonly By BrowseFileLocator = By.Id("file-upload");
    private readonly By DragDropFileLocator = By.CssSelector("input.dz-hidden-input");
    private readonly By UploadButtonLocator = By.Id("file-submit");
    private readonly By FileUploadedSuccessLocator = By.XPath("//h3[text()='File Uploaded!']");
    private readonly By FileNameUploadedLocator = By.Id("uploaded-files");
    private readonly By ErrorMessageLocator = By.CssSelector("h1");

    public UploadPage(IWebDriver driver, WebDriverWait wait)
    {
        this.driver = driver;
        this.wait = wait;
    }

    public void BrowseFileUpload(string filePath)
    {
        IWebElement BrowseFileButton = wait.Until(
            ExpectedConditions.ElementIsVisible(BrowseFileLocator)
        );
        BrowseFileButton.SendKeys(filePath);
    }

    public void DragAndDropFileUpload(params string[] filePaths)
    {
        if (filePaths == null || filePaths.Length == 0)
            throw new ArgumentException("At least one file path must be provided.", nameof(filePaths));
            
        IWebElement dragDropFileInput = wait.Until(
            ExpectedConditions.ElementExists(DragDropFileLocator)
        );

        ((IJavaScriptExecutor)driver).ExecuteScript(
            "arguments[0].style.visibility = 'visible'; arguments[0].style.height = '1px'; arguments[0].style.width = '1px';",
            dragDropFileInput
        );

        dragDropFileInput.SendKeys(string.Join("\n", filePaths));
    }

    public void ClickUploadButton()
    {
        IWebElement UploadButton = wait.Until(
            ExpectedConditions.ElementToBeClickable(UploadButtonLocator)
        );
        UploadButton.Click();
    }

    public string GetFileUploadedMessage()
    {
        wait.Until(ExpectedConditions.ElementIsVisible(FileUploadedSuccessLocator));
        return driver.FindElement(FileUploadedSuccessLocator).Text;       
    }

    public string GetUploadedFileName()
    {
        wait.Until(ExpectedConditions.ElementIsVisible(FileNameUploadedLocator));
        return driver.FindElement(FileNameUploadedLocator).Text;
    }

    public string GetErrorMessage()
    {
        wait.Until(ExpectedConditions.ElementIsVisible(ErrorMessageLocator));
        return driver.FindElement(ErrorMessageLocator).Text;
    }
}