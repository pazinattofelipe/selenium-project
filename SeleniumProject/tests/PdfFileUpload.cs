public class PdfFileUpload : BaseClass
{
    private UploadPage UploadPage;
    private static readonly string Valid_PdfFile = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory, "data", "valid", "file_example.pdf"
    );
    private static readonly string Valid_JpgFile = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory, "data", "valid", "file_example.jpg"
    );
    private static readonly string Valid_XlsFile = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory, "data", "valid", "file_example.xls"
    );

    [SetUp]
    public void TestSetUp()
    {
        UploadPage = new UploadPage(driver, wait);
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/upload");
    }

    [Test, Description("Tests the upload of a valid PDF file and verifies the success message and uploaded file name.")]
    public void TC001_UploadFileBrowse()
    {
        UploadPage.BrowseFileUpload(Valid_PdfFile);
        UploadPage.ClickUploadButton();

        //Asserts that the file was uploaded successfully by checking the presence of the "File Uploaded!" message
        Assert.That(UploadPage.GetFileUploadedMessage(), Does.Contain("File Uploaded!"),
            "The actual text: " + UploadPage.GetFileUploadedMessage() + " does not match the expected text: 'File Uploaded!'");

        //Asserts that the uploaded file name is correct by checking the presence of the expected file name in the actual uploaded file name
        Assert.That(UploadPage.GetUploadedFileName(), Does.Contain(Path.GetFileName(Valid_PdfFile)),
            "The actual uploaded file name: " + UploadPage.GetUploadedFileName() + " does not match the expected file name: '" + Path.GetFileName(Valid_PdfFile) + "'");        
    }

    [Test, Description("Tests the upload of a file without selecting any file and verifies the error message.")]
    public void TC002_UploadFileWithoutSelecting()
    {
        UploadPage.ClickUploadButton();

        //Asserts that the error message is correct by checking the presence of the expected error message in the actual error message
        Assert.That(UploadPage.GetErrorMessage(), Does.Contain("Internal Server Error"),
            "The actual error message: " + UploadPage.GetErrorMessage() + " does not match the expected error message: 'Internal Server Error'");
    }

    [Test, Description("Tests the replacement of a selected file with another file before uploading and verifies the success message and uploaded file name.")]
    public void TC003_FileReplacement()
    {
        UploadPage.BrowseFileUpload(Valid_PdfFile);
        UploadPage.BrowseFileUpload(Valid_XlsFile);
        UploadPage.ClickUploadButton();

        //Asserts that the file was uploaded successfully by checking the presence of the "File Uploaded!" message
        Assert.That(UploadPage.GetFileUploadedMessage(), Does.Contain("File Uploaded!"),
            "The actual text: " + UploadPage.GetFileUploadedMessage() + " does not match the expected text: 'File Uploaded!'");

        //Asserts that the uploaded file name is correct by checking the presence of the expected file name in the actual uploaded file name
        Assert.That(UploadPage.GetUploadedFileName(), Does.Contain(Path.GetFileName(Valid_XlsFile)),
            "The actual uploaded file name: " + UploadPage.GetUploadedFileName() + " does not match the expected file name: '" + Path.GetFileName(Valid_XlsFile) + "'");        
    }

    [Test, Description("Tests the upload of a single PDF file using drag and drop and verifies the error message.")]
    public void TC004_UploadDragDropSingleFile()
    {
        UploadPage.DragAndDropFileUpload(Valid_PdfFile);
        UploadPage.ClickUploadButton();

        //Asserts that the error message is correct by checking the presence of the expected error message in the actual error message
        Assert.That(UploadPage.GetErrorMessage(), Does.Contain("Internal Server Error"),
            "The actual error message: " + UploadPage.GetErrorMessage() + " does not match the expected error message: 'Internal Server Error'");
    }

    [Test, Description("Tests the upload of multiple files using drag and drop and verifies the error message.")]
    public void TC005_UploadDragDropMultipleFiles()
    {
        UploadPage.DragAndDropFileUpload(Valid_PdfFile, Valid_JpgFile, Valid_XlsFile);
        UploadPage.ClickUploadButton();

        //Asserts that the error message is correct by checking the presence of the expected error message in the actual error message
        Assert.That(UploadPage.GetErrorMessage(), Does.Contain("Internal Server Error"),
            "The actual error message: " + UploadPage.GetErrorMessage() + " does not match the expected error message: 'Internal Server Error'");
    }

    [Test, Description("This test is expected to fail because no file is supplied, but it is included to demonstrate the screenshot capture functionality in case of test failures.")]
    public void TC006_UploadFileBrowse()
    {
        UploadPage.BrowseFileUpload(Valid_PdfFile);
        UploadPage.ClickUploadButton();

        //Asserts that the file was uploaded successfully by checking the presence of the "File Submitted!" message
        Assert.That(UploadPage.GetFileUploadedMessage(), Does.Contain("File Submitted!"),
            "The actual text: " + UploadPage.GetFileUploadedMessage() + " does not match the expected text: 'File Submitted!'");

        //Asserts that the uploaded file name is correct by checking the presence of the expected file name in the actual uploaded file name
        Assert.That(UploadPage.GetUploadedFileName(), Does.Contain(Path.GetFileName(Valid_PdfFile)),
            "The actual uploaded file name: " + UploadPage.GetUploadedFileName() + " does not match the expected file name: '" + Path.GetFileName(Valid_PdfFile) + "'");        
    }
}