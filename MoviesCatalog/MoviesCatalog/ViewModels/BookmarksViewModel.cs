using MoviesCatalog.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;
using static MoviesCatalog.Services.WorkWithFiles;

namespace MoviesCatalog.ViewModels
{
    public class BookmarksViewModel : BaseViewModel
    {
        public ObservableCollection<Movie> Movies { get; set; }
        public BookmarksViewModel()
        {
            Title = "Bookmarks";
            ObservableCollection<Movie> _movies = new ObservableCollection<Movie>();
            string str;
            List<string> MoviesIds = GetIds();
            //List<string> MoviesIds = new List<string>();
            //MoviesIds.Add("100");
            foreach (string id in MoviesIds)
            {
                using (StreamReader strr = new StreamReader(WebRequest.Create(@"https://api.themoviedb.org/3/movie/" + id + "?api_key=575d4217958f8abcc637ec5ba82e347c&language=ru-RU").GetResponse().GetResponseStream()))
                    str = strr.ReadToEnd();
                var info = JsonConvert.DeserializeObject<Movie>(str);
                info.PosterPath = "https://image.tmdb.org/t/p/w500/" + info.PosterPath;
                _movies.Add(info);
            }
            Movies = _movies;
            //ItemsListView.ItemsSource = movies;
        }
    }
}
