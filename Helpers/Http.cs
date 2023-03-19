using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GezginRobotProjesi.Entity;

namespace GezginRobotProjesi.Helpers
{
    public class Http
    {
        private const string EXCEPTION_MESSAGE_FORMAT = "Exception Message: {0}, URL: ";
        private readonly HttpClient client;
        private readonly string url;
        public Http(string url){
            client = new HttpClient();
            this.url = url;
        }

        private Response<Uri> ValidateUrl(string url){
            Response<Uri> response = new Response<Uri>();
            Uri uri;
            if(string.IsNullOrWhiteSpace(url)){
                response.IsSuccess = false;
                response.ErrorMessage = "URL boş!";
                return response;
            }
            try{
                uri = new Uri(url);
            }catch(UriFormatException ex){
                response.IsSuccess = false;
                response.ErrorMessage = string.Format(EXCEPTION_MESSAGE_FORMAT, ex.Message, url);
                return response;
            }
            response.IsSuccess = true;
            response.Result = uri;
            return response;
        }

        public async Task<Response<string>> Get(string url) {
            Response<string> mapResult = new Response<string>();
            Response<Uri> urlValidation = ValidateUrl(url);
            if(!urlValidation.IsSuccess) {
                mapResult.IsSuccess = false;
                mapResult.Result = string.Empty;
                mapResult.ErrorMessage = urlValidation.ErrorMessage;
                return mapResult;
            }
            try{
                mapResult.IsSuccess = true;
                mapResult.Result = await client.GetStringAsync(urlValidation.Result);
                mapResult.ErrorMessage = string.Empty;
            }catch(AggregateException ex){
                mapResult.IsSuccess = false;
                mapResult.Result = string.Empty;
                mapResult.ErrorMessage = string.Format(EXCEPTION_MESSAGE_FORMAT, ex.InnerException is null ? ex.Message : ex.InnerException.Message, url);
            }
            return mapResult;
        }
    }
}