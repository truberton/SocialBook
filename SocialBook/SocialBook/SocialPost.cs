using System.Collections.Generic;

namespace SocialBook
{
    public class SocialPost
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Message { get; set; }
        public string Likes { get; set; }
        public string CommentNumber { get; set; }
        public List<CommentData> Comments { get; set; }
    }
}