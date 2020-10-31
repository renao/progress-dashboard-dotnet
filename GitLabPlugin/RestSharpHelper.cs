namespace GitLabPlugin
{
    using RestSharp;

    public class RestSharpHelper
    {
        public RestSharpHelper()
        {
        }

        public IRestClient CreateRestClient(string baseUrl)
            => new RestClient(baseUrl);

        public IRestRequest CreateJsonRestRequest(
            DataFormat requestFormat = DataFormat.Json)
                => new RestRequest
                {
                    RequestFormat = requestFormat
                };
    }
}
