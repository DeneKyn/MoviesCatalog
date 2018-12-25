using System;
using System.IO;
using System.Net;
using MoviesCatalog.Models;
using Newtonsoft.Json;
using static MoviesCatalog.Models.DeteilFilms;

namespace MoviesCatalog.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Movie Movie { get; set; }
        public Root DetailMovie { get; set; }
        public ItemDetailViewModel(Movie movie = null)
        {
            string str;
            using (StreamReader strr = new StreamReader(WebRequest.Create($"{AppSettings.ApiUrl}movie/{movie.Id}?api_key={AppSettings.ApiKey}&language={AppSettings.Language}").GetResponse().GetResponseStream()))
                str = strr.ReadToEnd();
            var temp = JsonConvert.DeserializeObject<Root>(str);

            temp.poster_path = "https://image.tmdb.org/t/p/w500/" + temp.poster_path;

            Title = movie?.Name;
            Movie = movie;
            DetailMovie = temp;

        }
    }
}
