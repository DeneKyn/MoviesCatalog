using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace MoviesCatalog.Models
{
    [DataContract]
    public class Movies
    {
        [DataMember(Name = "page")]
        public int Page { get; set; }

        [DataMember(Name = "results")]
        public ObservableCollection<Movie> Results { get; set; }

        [DataMember(Name = "total_pages")]
        public int TotalPages { get; set; }

        [DataMember(Name = "total_results")]
        public int TotalResults { get; set; }
    }

    [DataContract]
    public class Movie
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Name { get; set; }

        [DataMember(Name = "adult")]
        public bool IsAdultThemed { get; set; }

        [DataMember(Name = "backdrop_path")]
        public string BackdropPath { get; set; }        

        [DataMember(Name = "genre_ids")]
        public int[] Genres { get; set; }
     

        [DataMember(Name = "original_language")]
        public string OriginalLanguage { get; set; }

        [DataMember(Name = "original_title")]
        public string OriginalTitle { get; set; }

        [DataMember(Name = "overview")]
        public string Overview { get; set; }

        [DataMember(Name = "popularity")]
        public float Popularity { get; set; }

        [DataMember(Name = "poster_path")]
        public string PosterPath { get; set; }

        [DataMember(Name = "release_date")]
        public string ReleaseDate { get; set; }        
        
        [DataMember(Name = "video")]
        public bool IsVideo { get; set; }

        [DataMember(Name = "vote_average")]
        public double VoteAverage { get; set; }

        [DataMember(Name = "vote_count")]
        public int VoteCount { get; set; }

        [JsonIgnore]
        public string GenresNames { get; set; }

    }
}
