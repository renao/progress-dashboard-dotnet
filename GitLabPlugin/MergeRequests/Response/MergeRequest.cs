using System;
namespace GitLabPlugin.MergeRequests.Response
{
    public class MergeRequest
    {
        public string title { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string target_branch { get; set; }
        public string source_branch { get; set; }
        public UserInfo author { get; set; }
        public UserInfo assignee { get; set; }
        public string web_url { get; set; }
    }
}
