using System;
using System.Net;
using System.Web.Http;
using AutoMapper;
using NLog;
using StrategyCorps.CodeSample.Interfaces.Services;
using StrategyCorps.CodeSample.Models;
using StrategyCorps.CodeSample.WebApi.ViewModels;
using Swashbuckle.Swagger.Annotations;

namespace StrategyCorps.CodeSample.WebApi.Controllers
{
    /// <summary>
    /// The television controller
    /// </summary>
    public class MovieController : ApiController
    {
        private const string InternalServerErrorDefaultMessage = "There was a problem processing the request, please try again later.";

        private readonly IMovieService _movieService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// The television controller constructor
        /// </summary>
        /// <param name="movieService" cref="IMovieService">The movie service</param>
        /// <param name="logger" cref="ILogger">The NLog logger</param>
        /// <param name="mapper" cref="IMapper">The AutoMapper mapper</param>
        public MovieController(IMovieService movieService, ILogger logger, IMapper mapper)
        {
            _movieService = movieService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        ///     Get movie(s) by search
        /// </summary>
        /// <remarks>
        ///     Search for any television show
        /// </remarks>
        /// <param name="query">search query</param>
        [SwaggerResponse(HttpStatusCode.OK, "",typeof(MovieResultViewModel))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Movie search query is required.")]
        [SwaggerResponse(HttpStatusCode.NotFound, "The movie search {query} was not found.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, InternalServerErrorDefaultMessage)]
        [HttpGet]
        [Route("api/movie/{query}")]
        public IHttpActionResult MovieSearchByQuery(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return Content(HttpStatusCode.BadRequest, "Movie search query is required.");

            try
            {
                var movieSearchResponseDto = _movieService.GetMoviesByQuery(query);

                if (movieSearchResponseDto == null) return Content(HttpStatusCode.NotFound, $"The movie search {query} was not found.");

                var movieSearchResponseViewModel = _mapper.Map<MovieSearchResponseDto, MovieSearchResponseViewModel>(movieSearchResponseDto);

                return Ok(movieSearchResponseViewModel);
                
            }
            catch (Exception exception)
            {
                _logger.Error(exception);
                return Content(HttpStatusCode.InternalServerError, InternalServerErrorDefaultMessage);
            }
        }

        /// <summary>
        ///     Get similar movies
        /// </summary>
        /// <remarks>
        ///     Get similar movies
        /// </remarks>
        /// <param name="id">Movie id</param>
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(MovieResultViewModel))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Movie id is required.")]
        [SwaggerResponse(HttpStatusCode.NotFound, "The movie id {id} was not found.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, InternalServerErrorDefaultMessage)]
        [HttpGet]
        [Route("api/movie/{id}/similar")]
        public IHttpActionResult SimilarMovie(int id)
        {
            if (id <= 0) return Content(HttpStatusCode.BadRequest, "Movie id is not correct");

            try
            {
                var movieSearchResponseDto = _movieService.GetSimilarMoviesById(id);

                if (movieSearchResponseDto == null) return Content(HttpStatusCode.NotFound, $"The movie id {id} was not found.");

                var movieSearchResponseViewModel = _mapper.Map<MovieSearchResponseDto, MovieSearchResponseViewModel>(movieSearchResponseDto);

                return Ok(movieSearchResponseViewModel);

            }
            catch (Exception exception)
            {
                _logger.Error(exception);
                return Content(HttpStatusCode.InternalServerError, InternalServerErrorDefaultMessage);
            }
        }
    }
}
