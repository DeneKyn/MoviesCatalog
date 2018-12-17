using System;
using System.IO;
using System.Net;
using MoviesCatalog.Models;
using Newtonsoft.Json;

namespace MoviesCatalog.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Movie Movie { get; set; }
        public ItemDetailViewModel(Movie movie = null)
        {
            /*movie.Id;
            string str;            
            string uri = $"{AppSettings.ApiUrl}movie/{movie.Id}?api_key={AppSettings.ApiKey}&language=ru";
            using (StreamReader strr = new StreamReader(WebRequest.Create(uri).GetResponse().GetResponseStream()))
                str = strr.ReadToEnd();
            var info = JsonConvert.DeserializeObject<MovieCastMember>(str);
            */
            Title = movie?.Name;
            Movie = movie;
        }
    }
}
