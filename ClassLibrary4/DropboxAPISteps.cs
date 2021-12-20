using System;
using TechTalk.SpecFlow;
using System.IO;
using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;

namespace ClassLibrary4
{
    [Binding]
    public class DropboxAPISteps
    {

        string path;
        DropBoxRestAPI obj = new DropBoxRestAPI();
        static RandomString rndstr = new RandomString();
        string random;
        IRestResponse response;

        [Given(@"I have a file")]
        public void GivenIHaveAFileCalledTest_Txt()
        {
            random = rndstr.RandomStr();
            path = "Test_" + random + ".txt";
        }

        [When(@"I upload file to Dropbox")]
        public void WhenIUploadFileTest_TxtToDropbox()
        {
            response = obj.Upload(path);
        }
        
        [When(@"I request a file metadata by id")]
        public void WhenIRequestAFileTest_TxtMetadataById()
        {
            response = obj.Get_File_MetaData(obj.Get_File_ID(path));
        }
        
        [When(@"I delete file from Dropbox")]
        public void WhenIDeleteFileTest_TxtFromDropbox()
        {
            response = obj.Delete_File(path);
        }
        
        [Then(@"The file should be uploaded on Dropbox")]
        public void TheFileShouldBeUploadedOnDropbox()
        {
            response = obj.Get_List_Folder();
            var json = JsonConvert.DeserializeObject(response.Content);
            
            json.ToString().Should().Contain(path);
        }

        [Then(@"I should get File Name")]
        public void ThenIShouldGetFileName()
        {
            var json = JsonConvert.DeserializeObject(response.Content);
            json.ToString().Should().Contain(path);
        }

        [Then(@"File should not exist")]
        public void ThenFileShouldNotExist()
        {
            response = obj.Get_List_Folder();
            var json = (JObject)JsonConvert.DeserializeObject(response.Content);
            json.ToString().Should().NotContain(path);
        }

    }
}
