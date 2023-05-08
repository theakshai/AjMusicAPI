using AjMusicApi.Controllers.Admin;
using AjMusicApi.Data;
using AjMusicApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AjMusicApi.Controllers.Admin
{
    [ApiController]
    public class AdminController : ControllerBase
    {
        public IConfiguration? _configuration;
        public ApplicationContext? _acontext;
        public AdminController(IConfiguration _configuration, ApplicationContext _acontext)
        {
            this._configuration = _configuration;
            this._acontext = _acontext;
        }

        //Get
        [HttpGet]
        [Route("ajfy/admin/")]
        public async Task<ActionResult> Get()
        {

            if (_acontext?.Users == null && _acontext?.Tracks == null && _acontext.Artists == null)
            {
                var data = new { userCount = 0, tracksCount = 0, artistsCount = 0 };
                return Ok(JsonConvert.SerializeObject(data));

            }
            else
            {
                var UsersCount = await _acontext!.Users.CountAsync();
                var TracksCount = await _acontext!.Tracks.CountAsync();
                var ArtistsCount = await _acontext!.Artists.CountAsync();
                var data = new { userCount = UsersCount, tracksCount = TracksCount, artistsCount = ArtistsCount };
                return Ok(JsonConvert.SerializeObject(data));
            }
        }

        [HttpGet]
        [Route("ajfy/admin/searchArtists")]
        public async Task<ActionResult> GetArtist(string query)
        {
            if (query == null)
            {
                return BadRequest();
            }
            else
            {
                HelperController NewSearch = new HelperController();
                var body = await NewSearch.Search(query);
                var SingleArtist = NewSearch.SingleArtist(body);
                return Ok(SingleArtist);

            }
        }

        [HttpGet]
        [Route("ajfy/admin/searchTracks")]
        public async Task<ActionResult> GetTrack(string? title)
        {
            if (title == null)
            {
                return BadRequest();
            }
            else
            {
                HelperController NewSearch = new HelperController();
                var body = await NewSearch.Search(title!);
                var SingleTrack = NewSearch.SingleTrack(body);
                return Ok(SingleTrack);

            }
        }


        [HttpGet]
        [Route("ajfy/admin/getallartist")]

        public async Task<IActionResult> GetAllArtists()
        {
            if (_acontext != null)
            {
                var AllArtists = await _acontext.Artists.ToListAsync();
                return Ok(AllArtists);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("ajfy/admin/getalltracks")]

        public async Task<IActionResult> GetAllTracks()
        {
            if (_acontext != null)
            {
                var result = from artist in _acontext?.Artists
                             join track in _acontext!.Tracks on artist.Id equals track.ArtistId
                             select new
                             {
                                 track.TrackId,
                                 track.ImgUrl,
                                 track.Likes,
                                 track.Duration,
                                 track.Title,
                                 track.PreviewUrl,
                                 track.AddedOn,
                                 artist.Name,
                                 artist.Followers,

                             };
                return Ok(await result.ToListAsync());
            }
            return NotFound();
        }

        [HttpGet]
        [Route("ajfy/admin/gettrackbyid")]

        public async Task<IActionResult> GetTrackById(string? track_id)
        {
            if (_acontext != null)
            {
                var result = from artist in _acontext?.Artists
                             join track in _acontext!.Tracks on artist.Id equals track.ArtistId
                             where track.TrackId == track_id
                             select new
                             {
                                 track.TrackId,
                                 track.ImgUrl,
                                 track.Likes,
                                 track.Duration,
                                 track.Title,
                                 track.PreviewUrl,
                                 track.AddedOn,
                                 artist.Name,
                                 artist.Followers,

                             };
                return Ok(await result.ToListAsync());
            }
            return NotFound();
        }


        [HttpPost]
        [Route("ajfy/user/addnewsong")]

        public async Task<IActionResult> AddNewSong([FromBody] dynamic song)
        {
                var artistId = song.GetProperty("artist_id").GetInt32();
                var trackId = song.GetProperty("track_id").GetInt32();
            var IsArtistPresent = await _acontext!.Artists.FindAsync(artistId.ToString());
            var IsTrackPresent = await _acontext!.Tracks.FindAsync(trackId.ToString());
                if (IsTrackPresent == null)
                {
                    if (IsArtistPresent == null)
                    {

                        var Artist = new Artists
                        {
                            Id = artistId.ToString(),
                            ImgUrl = song?.GetProperty("artist_img").GetString(),
                            Followers = 0,
                            Name = song?.GetProperty("artist_name").GetString(),

                        };
                    Console.WriteLine(Artist);
                        try
                        {
                            _acontext?.Artists.AddAsync(Artist);
                            await _acontext!.SaveChangesAsync();
                        }
                        catch (Exception e)
                        {
                            return BadRequest(e.Message);
                        }
                    }

                var Track = new Tracks
                {
                    TrackId = trackId.ToString(),
                    Title = song?.GetProperty("title").GetString(),
                    ArtistId = artistId.ToString(),
                    ImgUrl = song?.GetProperty("img_url").GetString(),
                    PreviewUrl = song?.GetProperty("preview_url").GetString(),
                    Duration = song?.GetProperty("duration").GetInt32().ToString(),
                    AddedOn = DateTime.Now,
                    Likes = 0,

                        };
                        try
                        {
                            _acontext?.Tracks.AddAsync(Track);
                            await _acontext!.SaveChangesAsync();

                        }
                        catch (Exception e)
                        {
                            return BadRequest(e.Message);
                        }
                }
                else
                {
                return BadRequest("Track is already Present");
                }
            return Ok();

        }

        [HttpPost]
        [Route("ajfy/user/addnewuser")]
        public async Task<IActionResult> AddNewUser([FromBody] dynamic user)
        {

            if (user != null)
            {
                var _UserId = Guid.NewGuid().ToString() ;
                var Auth = new Auth
                {
                    UserId = _UserId,
                    Email = user?.GetProperty("email").GetString(),
                    Password = user?.GetProperty("password").GetString()

                };

                var User = new Users
                {
                    UserId = _UserId,
                    Name = user?.GetProperty("name").GetString(),
                    Dob = user?.GetProperty("dob").GetString(),
                    Country = user?.GetProperty("country").GetString(),
                    CreatedOn = DateTime.Now,
                };

                try
                {
                    _acontext?.Auth.AddAsync(Auth);
                    _acontext?.SaveChangesAsync();
                    _acontext?.Users.AddAsync(User);
                    _acontext?.SaveChangesAsync();

                    return new ObjectResult(new { message = "User Created Successfully" }) { StatusCode = 201 };

                }catch(Exception e)
                {
                return new ObjectResult(new { message = "Unable to create User" }) { StatusCode = 422 };
                }
            }
                    return new ObjectResult(new { message = "Unable to create User" }) { StatusCode = 422 };
        }
        }
    }

