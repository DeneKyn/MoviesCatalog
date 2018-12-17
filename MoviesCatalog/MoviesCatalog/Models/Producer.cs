using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesCatalog.Models
{
    public class Producer
    {
        public string Name { get; set; }
        public CustomCollection<Movie> ListOfFilms { get; set; } = new CustomCollection<Movie>();
    }
}
