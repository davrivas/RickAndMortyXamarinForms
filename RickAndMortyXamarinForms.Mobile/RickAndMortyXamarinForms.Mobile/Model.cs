using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace RickAndMortyXamarinForms.Mobile
{
    public class Info
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("pages")]
        public int Pages { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("prev")]
        public object Prev { get; set; }
    }

    public class Location
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Origin
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Result
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonIgnore]
        public Color StatusColor
        {
            get
            {
                switch (Status.ToLower())
                {
                    case "alive":
                        return Color.Green;
                    case "dead":
                        return Color.Red;
                    case "unknown":
                        return Color.Gray;
                    default:
                        return Color.Default;
                }
            }
        }

        [JsonProperty("species")]
        public string Species { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("origin")]
        public Origin Origin { get; set; }

        [JsonIgnore]
        public string PlaceOfOrigin => Origin?.Name ?? "unknown";

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonIgnore]
        public string LocationName => Location?.Name ?? "unknown";

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("episode")]
        public List<string> Episode { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }

    public class Model
    {
        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }
}
