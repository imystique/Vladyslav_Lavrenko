using System;
using TechTalk.SpecFlow;
using System.IO;
using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary4
{
    [Binding]
    public class DropboxAPISteps
    {

        string path;
        Box_Of_Drops obj = new Box_Of_Drops();
        IRestResponse response;

        [Given(@"I have a file called Test\.txt")]
        public void GivenIHaveAFileCalledTest_Txt()
        {
            path = "/Test.txt";
        }

        [When(@"I upload file Test\.txt to Dropbox")]
        public void WhenIUploadFileTest_TxtToDropbox()
        {
            response = obj.Upload(path);
        }

        [Given(@"I have an uploaded file Test\.txt")]
        public void GivenIHaveAnUploadedFileTest_Txt()
        {
            path = "/Test.txt";
        }
        
        [When(@"I request a file Test\.txt metadata by id")]
        public void WhenIRequestAFileTest_TxtMetadataById()
        {
            response = obj.Get_File_MetaData(obj.Func());
        }
        
        [When(@"I delete file Test\.txt from Dropbox")]
        public void WhenIDeleteFileTest_TxtFromDropbox()
        {
            response = obj.Delete_File(path);
        }
        
        [Then(@"I should get Status Code OK")]
        public void ThenIShouldGetStatusCode()
        {
            Assert.IsTrue(response.IsSuccessful);
        }

    }
}
