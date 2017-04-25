﻿using System.Configuration;

namespace StrategyCorps.CodeSample.Dispatchers
{
    public class TheMovieDbDispatcherBase
    {
        protected readonly string TheMovieDBApiKey = ConfigurationManager.AppSettings.Get("TheMovieDBApiKey");
        protected string TheMovieDbBaseUrl = ConfigurationManager.AppSettings.Get("TheMovieDBBaseUrl");
    }
}