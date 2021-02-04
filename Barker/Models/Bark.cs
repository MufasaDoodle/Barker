using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Barker.Models
{
    public class Bark
    {
        [JsonPropertyName("BarkID")]
        public int BarkID { get; set; }
        [JsonPropertyName("Text")]
        public string Text { get; set; }
        [JsonPropertyName("UserID")]
        public int UserID { get; set; }
        [JsonPropertyName("Timestamp")]
        public DateTime TimeStamp { get; set; }
        [JsonPropertyName("Visibility")]
        public string Visibility { get; set; }
        [JsonPropertyName("QuotingTweetID")]
        public int? QuotingTweetID { get; set; }
        [JsonPropertyName("CommentTweetID")]
        public int? CommentTweetID { get; set; }
    }
}
