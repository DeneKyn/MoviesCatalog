﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;

namespace MoviesCatalog.Models
{
    [DataContract]
    public class Cast
    {
        [DataMember(Name = "id")]
        public int PersonId { get; set; }

        [DataMember(Name = "cast_id")]
        public int CastId { get; set; }

        [DataMember(Name = "credit_id")]
        public string CreditId { get; set; }

        [DataMember(Name = "character")]
        public string Character { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "order")]
        public int Order { get; set; }

        [DataMember(Name = "profile_path")]
        public string ProfilePath { get; set; }
    }

    [DataContract]
    public class MovieCastMember
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "cast")]
        public ObservableCollection<Cast> Casts { get; set; }
    }
}