﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Lab.EF.WebAPI.Models.RickAndMortyAPI
{
    public class Character
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("species")]
        public string Species { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("origin")]
        public Origin Origin { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("episode")]
        public List<string> Episode { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }
}