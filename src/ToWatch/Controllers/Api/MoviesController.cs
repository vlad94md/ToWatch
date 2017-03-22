using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ToWatch.ViewModels;

namespace ToWatch.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    public class MoviesController : Controller
    {
        private IConfigurationRoot _config;

        public MoviesController(IConfigurationRoot config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> Upcomming()
        {
            try
            {
                var movies = await GetMovieByCategory("upcoming");

                return Ok(movies);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpGet]
        public async Task<IActionResult> TopRated()
        {
            try
            {
                var movies = await GetMovieByCategory("top_rated");

                return Ok(movies);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        public async Task<MovieSetApiResponse> GetMovieByCategory(string category)
        {
            var apiKey = _config["Keys:ImdbApiKey"];
            var queryString = $"{category}?api_key={apiKey}&language=en-US&page=1";
            var url = $"https://api.themoviedb.org/3/movie/{queryString}";

            try
            {
                var client = new HttpClient();
                var json = await client.GetStringAsync(url);

                var movies = JsonConvert.DeserializeObject<MovieSetApiResponse>(json.Replace("_",""));

                return movies;
            }
            catch (Exception)
            {
                //Log
                throw;
            }
        }
    }
}
