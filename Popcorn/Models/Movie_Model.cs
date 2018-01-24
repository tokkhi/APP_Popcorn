using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Popcorn.Models
{
    public class Movie_Model
    {
        public class Input_movie
        {
            public string Name_Movie { get; set; }
            public string Date_Movie { get; set; }
            public string detail { get; set; }
            public string Caster { get; set; }
            public string Directer { get; set; }
            public string img { get; set; }
            public string urlTri { get; set; }
        }


        public class Output_Update_movie
        {
            public string message { get; set; }
            public Boolean error { get; set; }

        }
        public class Output_movie
        {
            public List<Detail> Detail_AllMovie { get; set; }

        }
        public class Search_Movie
        {
            public string Name_Movie { get; set; }
        }
        public class Detail
        {
            public string Name_Movie { get; set; }
            public string Date_Movie { get; set; }
            public string detail { get; set; }
            public string Caster { get; set; }
            public string Directer { get; set; }
            public string img { get; set; }
        }
    }
}