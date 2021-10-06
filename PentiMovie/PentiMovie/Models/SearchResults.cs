using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PentiMovie.Models
{
    public class SearchResults
    {
        [JsonPropertyName("Search")]
        public List<Search> Searches { get; set; }

        public string TotalResults { get; set; }
    }
}
