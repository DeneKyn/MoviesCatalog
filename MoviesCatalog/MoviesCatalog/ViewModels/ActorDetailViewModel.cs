using MoviesCatalog.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MoviesCatalog.ViewModels
{
    public class ActorDetailViewModel : BaseViewModel
    {
        public Cast Cast { get; set; }
        public Actor Actor { get; set; }
        public ActorDetailViewModel(Cast cast = null)
        {            
            Title = cast?.Name;
            Cast = cast;

            string str;
            using (StreamReader strr = new StreamReader(WebRequest.Create($"{AppSettings.ApiUrl}person/{Cast.PersonId}/?api_key={AppSettings.ApiKey}&language=ru").GetResponse().GetResponseStream()))
                str = strr.ReadToEnd();
            Actor = JsonConvert.DeserializeObject<Actor>(str);
            Actor.ProfilePath = "https://image.tmdb.org/t/p/w500" + Actor.ProfilePath;
        }
    }
}
