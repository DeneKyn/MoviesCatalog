using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace MoviesCatalog.Models
{
    [DataContract]
    public class Genre
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get;  set; }
    }


    [DataContract]
    public class GenreCollection
    {
        [DataMember(Name = "genres")]
        public ObservableCollection<Genre> Genres { get; set; }
    }
}
