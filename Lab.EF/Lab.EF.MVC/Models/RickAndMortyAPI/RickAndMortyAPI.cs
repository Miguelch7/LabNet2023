using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Lab.EF.MVC.Models.RickAndMortyAPI
{
    public class RickAndMortyAPI
    {
        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("results")]
        public List<Character> Results { get; set; }
    }
}