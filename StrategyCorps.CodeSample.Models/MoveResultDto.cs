using System;

namespace StrategyCorps.CodeSample.Models
{
    public class MovieResultDto
    {
        public bool Adult { get; set; }

        public string BackdropPath { get; set; }       
        
        public int Id { get; set; }

        public string OriginalLanguage { get; set; }

        public string OriginalTitle { get; set; }

        public string Overview { get; set; }

        public decimal Popularity { get; set; }

        public string PosterPath { get; set; }

        public DateTime ReleaseDate { get; set;  }

        public string Title { get; set; }

        public bool Video { get; set; }

        public decimal VoteAverage { get; set; }

        public int  VoteCount { get; set; }
    }
}
