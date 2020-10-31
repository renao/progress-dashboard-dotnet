using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitLabPlugin
{
    public class Plugin
    {

        public event Action<List<MergeRequests.Response.MergeRequest>> UpdateMergeRequestData;

        private List<MergeRequests.MergeRequestsReceiver> Receivers
            = new List<MergeRequests.MergeRequestsReceiver>();

        public void Initialize(string gitlabUrl, params string[] projectIds)
        {
            this.CreateReceivers(gitlabUrl, projectIds);
        }

        public async Task RunAsync()
        {
            var allMergeRequests = new List<MergeRequests.Response.MergeRequest>();

            foreach (var receiver in this.Receivers)
            {
                var requests  = await receiver.ReceiveAsync();

                if (requests != null)
                {
                    allMergeRequests.AddRange(requests);
                }
            }

            this.UpdateMergeRequestData?.Invoke(allMergeRequests);
        }

        private void CreateReceivers(string gitlabUrl, string[] projectIds)
        {
            foreach (var projectId in projectIds)
            {
                var receiver = new MergeRequests.MergeRequestsReceiver(gitlabUrl, projectId);
                this.Receivers.Add(receiver);
            }
        }
    }
}
