namespace GitLabPlugin.MergeRequests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MergeRequestsReceiver
    {
        private readonly RestSharpHelper RestSharpHelper;

        private string GitLabProjectId;
        private string GitLabUrl;

        private string MergeRequestsUrl
            => $"{this.GitLabUrl}/api/v4/projects/{this.GitLabProjectId}/merge_requests?state=opened&wip=no";

        public MergeRequestsReceiver(string gitlabUrl, string projectId)
        {
            this.GitLabUrl = gitlabUrl;
            this.GitLabProjectId = projectId;

            this.RestSharpHelper = new RestSharpHelper();
        }

        public async Task<List<Response.MergeRequest>> ReceiveAsync()
        {
            var restClient = this.RestSharpHelper.CreateRestClient(this.MergeRequestsUrl);
            var request = this.RestSharpHelper.CreateJsonRestRequest();

            var response = await restClient.ExecuteAsync<List<Response.MergeRequest>>(request);

            if (response.IsSuccessful && response.Data != null)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }
    }
}
