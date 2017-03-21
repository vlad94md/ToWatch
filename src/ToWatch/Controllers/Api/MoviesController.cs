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
            var apiKey = _config["Keys:ImdbApiKey"];
            var url = $"https://api.themoviedb.org/3/movie/upcoming?api_key={apiKey}&language=en-US&page=1";

            try
            {
                var client = new HttpClient();
                var json = await client.GetStringAsync(url);

                var movies = JsonConvert.DeserializeObject<MovieSetApiResponse>(json);

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
            ///movie/top_rated
            var apiKey = _config["Keys:ImdbApiKey"];
            var url = $"https://api.themoviedb.org/3/movie/top_rated?api_key={apiKey}&language=en-US&page=1";

            try
            {
                var client = new HttpClient();
                var json = await client.GetStringAsync(url);

                var movies = JsonConvert.DeserializeObject<MovieSetApiResponse>(json);

                return Ok(movies);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}
