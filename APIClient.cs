
namespace TroyaRest.ApiClient
{
    public class APIClient
    {
        public APIClient() { }

        public WebAPIResponse Availibility(AvailibilityRequest.AvailibilityRequestModel availibility)
        {
            string BaseURL = $"{WebSettings.TroyaRest.BaseURL}/getAvailability";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string postData = new JsonHelper().ModelToJson(availibility);

            var client = new RestClient(BaseURL);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", WebSettings.TroyaRest.BasicAuth);
            request.AddHeader("Accept-Encoding", "gzip");

            request.AddParameter("application/json", postData, ParameterType.RequestBody);

            var response = client.Execute<AvailibilityResponse.AvailibilityResponse>(request);

            if (WebSettings.TroyaRest.LogAvailibilityResponse == true)
            {
                LogHelper.Save($"RS-{DataCollectionType.TroyaAvailibility.ToString()}", availibility.RequestHeader.ClientTransactionId, response.Content);
            }


            WebAPIResponse model = new WebAPIResponse() { Message = "", Response = "", Success = false };
            model.Response = response.Content;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (response.Content.Contains("\"SUCCESS\""))
                {
                    AvailibilityResponse.AvailibilityResponse data = new JsonHelper().JsonToModel<AvailibilityResponse.AvailibilityResponse>(response.Content);
                    model.Success = true;
                    model.DynamicData = data;
                }
                else
                {
                    if (response.Content.Contains("\"FAILURE\""))
                    {
                        FailedResponse.FailedRespone data = new JsonHelper().JsonToModel<FailedResponse.FailedRespone>(response.Content);
                        model.Success = false;
                        model.DynamicData = data;
                    }

                }
            }

            return model;
        }

}
