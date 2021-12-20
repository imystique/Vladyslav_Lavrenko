using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClassLibrary4
{
    public class DropBoxRestAPI
    {
        string key = "DFYtZ22ai9QAAAAAAAAAARz4tBkXR8V4nr3nVHRdEISYfskyk9JZyxFmaNabR-TX";
        string Base_URL = "https://api.dropboxapi.com/2";

        public IRestResponse Upload(string p0)
        {
            var client = new RestClient("https://content.dropboxapi.com/2/files/upload");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Dropbox-API-Arg", "{\"path\": \"/" + p0 + "\",\"mode\": \"add\",\"autorename\": true,\"mute\": false,\"strict_conflict\": false}");
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddHeader("Authorization", "Bearer " + key);
            var body = @"Test-Test";
            request.AddParameter("application/octet-stream", body, ParameterType.RequestBody);
            IRestResponse Response = client.Execute(request);
            return Response;
        }


        public IRestResponse Get_File_MetaData(string ID)
        {
            var client = new RestClient(Base_URL + "/sharing/get_file_metadata");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + key);
            request.AddParameter("application/json", "{\r\n    \"file\": \"" + ID + "\",\r\n    \"actions\": []\r\n}", ParameterType.RequestBody);
            IRestResponse Response = client.Execute(request);
            return Response;
        }

        public string Get_File_ID(string p0)
        {
            var client = new RestClient(Base_URL + "/files/get_metadata");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + key);
            request.AddParameter("application/json", "{\r\n    \"path\": \"/" + p0 + "\"\r\n}", ParameterType.RequestBody);
            IRestResponse Response = client.Execute(request);
            Get_File_ID_Fields json = JsonConvert.DeserializeObject<Get_File_ID_Fields>(Response.Content);
            return json.ID;
        }

        public IRestResponse Get_List_Folder()
        {
            var client = new RestClient(Base_URL + "/files/list_folder");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + key);
            var body = @"{
" + "\n" +
            @"    ""path"": """",
" + "\n" +
            @"    ""recursive"": false,
" + "\n" +
            @"    ""include_media_info"": false,
" + "\n" +
            @"    ""include_deleted"": false,
" + "\n" +
            @"    ""include_has_explicit_shared_members"": false,
" + "\n" +
            @"    ""include_mounted_folders"": true,
" + "\n" +
            @"    ""include_non_downloadable_files"": true
" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse Response = client.Execute(request);
            return Response;
        }

        public IRestResponse Delete_File(string p0)
        {
            var client = new RestClient(Base_URL + "/files/delete_v2");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + key);
            request.AddParameter("application/json", "{\r\n    \"path\":\"/" + p0 + "\"\r\n}", ParameterType.RequestBody);
            IRestResponse Response = client.Execute(request);
            return Response;
        }

    }
}
