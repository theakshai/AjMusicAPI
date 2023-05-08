using AjMusicApi.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
namespace AjMusicApi.Controllers.Admin
{
    public class HelperController
    {


        private IConfiguration _configuration;
        public ApplicationContext? _acontext;
        private string _apiKey;
        private string _apiHost;
        public HelperController() { }

        public HelperController(IConfiguration _configuration, ApplicationContext _acontext)
        {
            this._configuration = _configuration;
            this._acontext = _acontext;
            this._apiKey = _configuration.GetSection("API_KEY").Value;
            this._apiHost =_configuration.GetSection("API_HOST").Value;
        }
        public async Task<Object> Search(string query)
        {
            Console.WriteLine(_apiKey);
            var client = new HttpClient();
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://deezerdevs-deezer.p.rapidapi.com/search?q={query}"),
                Headers =
            {

                { "X-RapidAPI-Key", "601f9739bbmshec2e64477b270a2p12d601jsnf3f1b755ff1b" },
                { "X-RapidAPI-Host", _configuration?.GetSection("API_HOST")?.Value?.ToString() },
            },
            };

            try
            {
                using var response = await client.SendAsync(requestMessage);
                if (response.IsSuccessStatusCode)
                {
                    dynamic body = await response.Content.ReadAsStringAsync();
                    return (JObject)JsonConvert.DeserializeObject(body);
                }
            } catch (Exception e)
            {

                return e.Message;
            }
            return "API is Down.Contact RAPID API";
        }

        public string SingleArtist(dynamic data)
        {
            var FirstData = data["data"][0];
            var SingleArtistData = new 
            { 
                artist_id = FirstData["artist"]["id"], 
                name = FirstData["artist"]["name"],
                img_url = FirstData["artist"]["picture_xl"] 
            };
            return JsonConvert.SerializeObject(SingleArtistData);
        }

        public string SingleTrack(dynamic data)
        {
            var TrackData = data["data"][0];
                    var SingleTrackData = new
                    {
                        track_id = TrackData["id"],
                        title = TrackData["title"],
                        artist_id = TrackData["artist"]["id"],
                        artist_name = TrackData["artist"]["name"],
                        artist_img = TrackData["artist"]["picture_xl"],
                        img_url = TrackData["album"]["cover_xl"],
                        preview_url = TrackData["preview"],
                        duration = TrackData["duration"]

                    };
                    return JsonConvert.SerializeObject(SingleTrackData);
                }
        public bool IsArtistPresent(int artistId)
        {
            Console.WriteLine(_acontext?.Artists?.FindAsync(artistId.ToString()) != null);
            return _acontext?.Artists?.FindAsync(artistId.ToString()) != null;
        }
        public bool IsTrackPresent(int trackId)
        {
            Console.WriteLine(_acontext?.Artists?.FindAsync(trackId.ToString()) != null);
            return _acontext?.Tracks?.FindAsync(trackId.ToString()) != null;
        }

            }


        }

