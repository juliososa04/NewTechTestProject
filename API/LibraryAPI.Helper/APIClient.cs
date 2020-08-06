using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryAPI.Helper
{
   public static class ApiClient
        {
            //  private static string BaseURL = Settings.RESTUrl;
            static private async Task<ResponseContent> RequestAsync(string vBaseURL, string vUri, Dictionary<string, string> vParameters, object vContent, HttpMethod vMethod, CancellationToken vCancellationToken)
            {




                HttpRequestMessage _request = await BuildrequestAsync(vBaseURL, vUri, vParameters, vContent, vMethod);
                ResponseContent _result = new ResponseContent();

                using (HttpClient _client = new HttpClient())
                {


                    try
                    {

                        using (var _response = await _client.SendAsync(_request, vCancellationToken).ConfigureAwait(false))
                        {

                            vCancellationToken.ThrowIfCancellationRequested();
                            string _responseContent = await _response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            // string stringResponse = _responseContent.TrimStart('"').TrimEnd('"');
                            vCancellationToken.ThrowIfCancellationRequested();
                            _result.Content = _responseContent;

                            _result.Success = IsResponseCodeValid(_response);
                        }

                    }
                    catch (OperationCanceledException)
                    {
                        _result.Cancelled = true;
                        _result.Success = false;
                        _result.Error = "Cancelled request";
                    }
                    catch (AggregateException agex)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var x in agex.InnerExceptions)
                        {
                            sb.AppendLine(x.Message);
                        }
                        _result.Error = sb.ToString();
                        _result.Success = false;
                    }
                    catch (Exception ex)
                    {
                        _result.Success = false;
                        _result.Error = ex.Message.Contains("NameResolutionFailure") ? "Check internet connectivty and your server address" : ex.Message;
                    }
                }
                return _result;


            }
            static private bool IsResponseCodeValid(HttpResponseMessage vResponse)
            {
                var _statusCode = (int)vResponse.StatusCode;
                return _statusCode >= 200;
            }
            private static async Task<HttpRequestMessage> BuildrequestAsync(string vBaseURL, string vUri, Dictionary<string, string> vParameters, object vContent, HttpMethod vMethod)

            {
                HttpRequestMessage _request = new HttpRequestMessage();

                string Token = null;
                if (!String.IsNullOrWhiteSpace(Token))
                {
                    _request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                }
                _request.Headers.Add("Accept", "application/json");

                _request.Method = vMethod;
                _request.Content = vContent != null ? new StringContent(JsonConvert.SerializeObject(vContent), Encoding.UTF8, "application/json") : null;


                //  _request.Content = vContent != null ? new StringContent(JsonConvert.SerializeObject(new Message(TCryptography.mEncryptText(JsonConvert.SerializeObject(vContent)))).ToString(), Encoding.UTF8, "application/json") : null;

                //_request.RequestUri = new Uri(BaseURL + vUri + "?" + "encryptedMssg=" + TCryptography.mEncryptText(JsonConvert.SerializeObject(vContent)));
                _request.RequestUri = vParameters != null ? new Uri(vBaseURL + vUri + "?" + PrepareParametersString(vParameters)) : new Uri(vBaseURL + vUri);

                return _request;
            }
            private static string PrepareParametersString(Dictionary<string, string> vValues)
            {
                if (vValues == null || vValues.Count == 0)
                    return String.Empty;

                var _pairs = vValues.Select(x => x.Key + "=" + WebUtility.UrlEncode(x.Value));
                return String.Join("&", _pairs);
            }
        
            static public async Task<ResponseContent> GetAsync(string vBaseURL, string vUrl, Dictionary<string, string> vParameters, CancellationToken vCancellationToken)
            {
                return await RequestAsync(vBaseURL, vUrl, vParameters, null, HttpMethod.Get, vCancellationToken).ConfigureAwait(false);
            }

            static public async Task<ResponseContent> DeleteAsync(string vBaseURL, string vUrl, Dictionary<string, string> vParameters, object vContent, CancellationToken vCancellationToken)
            {
                return await RequestAsync(vBaseURL, vUrl, vParameters, vContent, HttpMethod.Delete, vCancellationToken).ConfigureAwait(false);
            }

            static public async Task<ResponseContent> PutAsync(string vBaseURL, string vUrl, Dictionary<string, string> vParameters, object vContent, CancellationToken vCancellationToken)
            {
                return await RequestAsync(vBaseURL, vUrl, vParameters, vContent, HttpMethod.Put, vCancellationToken).ConfigureAwait(false);
            }

            static public async Task<ResponseContent> PostAsync(string vBaseURL, string vUrl, Dictionary<string, string> vParameters, object vContent, CancellationToken vCancellationToken)
            {
                return await RequestAsync(vBaseURL, vUrl, vParameters, vContent, HttpMethod.Post, vCancellationToken).ConfigureAwait(false);
            }
          
        }
    
}
