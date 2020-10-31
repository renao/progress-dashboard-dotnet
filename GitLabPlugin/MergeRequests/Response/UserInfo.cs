using System;
namespace GitLabPlugin.MergeRequests.Response
{
    public class UserInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string avatar_url { get; set; }
        public string web_url { get; set; }
    }
}
