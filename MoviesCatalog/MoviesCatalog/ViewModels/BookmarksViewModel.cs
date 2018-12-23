using MoviesCatalog.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static MoviesCatalog.Services.WorkWithFiles;

namespace MoviesCatalog.ViewModels
{
    public class BookmarksViewModel : BaseViewModel
    {
        public ObservableCollection<Movie> BookmarksMovies { get; set; }
        public BookmarksViewModel()
        {
            Title = Resource.Bookmarks;
            LoadBookmarks();            
        }
        public void LoadBookmarks()
        {
            ObservableCollection<Movie> _movies = new ObservableCollection<Movie>();
            string str;
            List<string> MoviesIds = GetIds();
            
            foreach (string id in MoviesIds)
            {
               // $"{AppSettings.ApiUrl}search/movie?api_key={AppSettings.ApiKey}&language={AppSettings.Language}&query={EntrySearch.Text}&page=1&include_adult=false";
                using (StreamReader strr = new StreamReader(WebRequest.Create($"{AppSettings.ApiUrl}movie/{id}?api_key={AppSettings.ApiKey}&language={AppSettings.Language}").GetResponse().GetResponseStream()))
                    str = strr.ReadToEnd();
                var info = JsonConvert.DeserializeObject<Movie>(str);
                info.PosterPath = "https://image.tmdb.org/t/p/w500/" + info.PosterPath;
                _movies.Add(info);
            }
            BookmarksMovies = _movies;   
        }
        
        
    }

}
