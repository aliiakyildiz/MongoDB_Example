using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB_Example.Models;
using MongoDB_Example.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly UserMusicFavoriteService _musicService;
        public MusicController(UserMusicFavoriteService musicService)
        {
            _musicService = musicService;
        }

        [HttpGet]
        public IEnumerable<UserMusicFavorite> Get()
        {
            return _musicService.Get();
        }
        // GET: api/Music/GetUserById/5
        [HttpGet("{userId}")]
        public UserMusicFavorite GetByUserId(int userId)
        {
            return _musicService.GetByUserId(userId);
        }
        // POST: api/Music/Post
        [HttpPost]
        public void Post([FromBody] UserMusicFavorite value)
        {
            _musicService.Create(value);
        }
        // PUT: api/Music/Put
        [HttpPut]
        public void Put([FromBody] UserMusicFavorite value)
        {
            _musicService.Update(value.id, value);
        }
        // DELETE: api/Music/Delete/id
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _musicService.Remove(id);
        }
    }
}
