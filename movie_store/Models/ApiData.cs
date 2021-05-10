using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace movie_store.Migrations
{
  public class ApiData
  {
    [JsonProperty("Title")]
    public string Title { get; set; }
    [JsonProperty("Director")]
    public string Director { get; set; }
    [JsonProperty("Year")]
    public int ReleaseYear { get; set; }
    [JsonProperty("imdbRating")]
    public double ImdbRating { get; set; }
    [JsonProperty("imdbID")]
    public string ImdbId { get; set; }
    [JsonProperty("Rated")]
    public string ImdbRated { get; set; }
    [JsonProperty("Plot")]
    public string Plot { get; set; }
    [JsonProperty("Poster")]
    public string imgUrl { get; set; }
  }
}