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
    public class Box_Of_Drops
    {
        string key = "m_-vHr7OATkAAAAAAAAAAXOLt_FmWQ29Y5mHNVVbPUbLwsECJt_lklvbm95DTq8N";

        public IRestResponse Upload(string p0)
        {
            var client = new RestClient("https://content.dropboxapi.com/2/files/upload");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Dropbox-API-Arg", "{\"path\": \"" + p0 + "\",\"mode\": \"add\",\"autorename\": true,\"mute\": false,\"strict_conflict\": false}");
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddHeader("Authorization", "Bearer " + key);
            var body = @"Test-Test";
            request.AddParameter("application/octet-stream", body, ParameterType.RequestBody);
            IRestResponse Response = client.Execute(request);
            return Response;
        }


        public IRestResponse Get_File_MetaData(string ID)
        {
            var client = new RestClient("https://api.dropboxapi.com/2/sharing/get_file_metadata");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + key);
            request.AddParameter("application/json", "{\r\n    \"file\": \"" + ID + "\",\r\n    \"actions\": []\r\n}", ParameterType.RequestBody);
            IRestResponse Response = client.Execute(request);
            return Response;
        }

        public string Func()
        {
            var client = new RestClient("https://api.dropboxapi.com/2/files/get_metadata");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + key);
            var body = @"{
" + "\n" +
            @"    ""path"": ""/Test.txt"",
" + "\n" +
            @"    ""include_media_info"": false,
" + "\n" +
            @"    ""include_deleted"": false,
" + "\n" +
            @"    ""include_has_explicit_shared_members"": false
" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse Response = client.Execute(request);
            var json = (JObject)JsonConvert.DeserializeObject(Response.Content);
            return json["id"].Value<string>();
        }

        public IRestResponse Delete_File(string p0)
        {
            var client = new RestClient("https://api.dropboxapi.com/2/files/delete_v2");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + key);
            request.AddParameter("application/json", "{\r\n    \"path\":\"" + p0 + "\"\r\n}", ParameterType.RequestBody);
            IRestResponse Response = client.Execute(request);
            return Response;
        }

    }
}
