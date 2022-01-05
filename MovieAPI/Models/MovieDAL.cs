using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class MovieDAL
    {
        public SearchParent SearchMoviesByType(string title)
        {
            string url = $"http://www.omdbapi.com/?apikey={Secret.movieKey}&s={title}";

            // Next: Create our request
            HttpWebRequest request = WebRequest.CreateHttp(url);

            // Next: If your API needs any kind of login or key,
            // that may go here.
            // SWAPI doesn't need anything special

            // Now we are ready to send off our request and grab the servers
            // response. Inside out response, the resulting data lives.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Pull result into a stream reader which will then give us a string.
            StreamReader rd = new StreamReader(response.GetResponseStream());

            // Grab out response string
            // ReadToEnd starts at the top of our file and returns each line
            // until it hits the end.
            string result = rd.ReadToEnd();
            rd.Close();
            // This line converts out Json string
            // into a person object automatically
            SearchParent p = JsonConvert.DeserializeObject<SearchParent>(result);

            // Later we'll convert our string into a model which makes it much easier to 
            // use for .net
            return p;
        }
    }
}
