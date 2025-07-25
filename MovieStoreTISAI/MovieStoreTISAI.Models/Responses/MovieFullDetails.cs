﻿using MovieStoreTISAI.Models.DTO;

namespace MovieStoreTISAI.Models.Responses
{
    public class FullMovieDetails
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public DateTime DateInserted { get; set; }

        public List<Actor> Actors { get; set; }
    }
}
