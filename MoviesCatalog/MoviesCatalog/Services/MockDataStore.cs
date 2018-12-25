using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesCatalog.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Collections.ObjectModel;

namespace MoviesCatalog.Services
{
    public class MockDataStore : IDataStore<Movie>
    {
        ObservableCollection<Movie> movies;
        ObservableCollection<Genre> genres;

        public MockDataStore()
        {
           
                movies = new ObservableCollection<Movie>();
            genres = new ObservableCollection<Genre>();
            string str;
            using (StreamReader strr = new StreamReader(WebRequest.Create($"{AppSettings.ApiUrl}movie/popular?api_key={AppSettings.ApiKey}&language={AppSettings.Language}&page=1").GetResponse().GetResponseStream()))
                str = strr.ReadToEnd();
            var info = JsonConvert.DeserializeObject<Movies>(str);

            using (StreamReader strr = new StreamReader(WebRequest.Create($"{AppSettings.ApiUrl}genre/list?api_key={AppSettings.ApiKey}&language={AppSettings.Language}").GetResponse().GetResponseStream()))
                str = strr.ReadToEnd();
            var varGenre = JsonConvert.DeserializeObject<GenreCollection>(str);

            genres = varGenre.Genres;

            foreach (var x in info.Results)
            {
                x.PosterPath = "https://image.tmdb.org/t/p/w500" + x.PosterPath;
                x.BackdropPath = "https://image.tmdb.org/t/p/w500" + x.BackdropPath;
                x.GenresNames = "";
                foreach (var movieGenre in x.Genres)
                    foreach(var genre in genres)
                    {
                        if(movieGenre == genre.Id)
                        {
                            x.GenresNames += genre.Name+" ";
                        }
                    }
                
            }

            var mockItems = info.Results;            

            foreach (var item in mockItems)
            {
                movies.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Movie item)
        {
            movies.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Movie item)
        {
            var oldItem = movies.Where((Movie arg) => arg.Name == item.Name).FirstOrDefault();
            movies.Remove(oldItem);
            movies.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string name)
        {
            var oldItem = movies.Where((Movie arg) => arg.Name == name).FirstOrDefault();
            movies.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Movie> GetItemAsync(string name)
        {
            return await Task.FromResult(movies.FirstOrDefault(s => s.Name == name));
        }

        public async Task<IEnumerable<Movie>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(movies);
        }
    }
}