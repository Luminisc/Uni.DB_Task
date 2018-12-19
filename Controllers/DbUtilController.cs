using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using Uni.DB_Task.Models;

namespace Uni.DB_Task.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DbUtilsController : ControllerBase
    {
        public bool PopulateGames(string gamesFile = @"D:\Git\University\Uni.DB_Task\wwwroot\games.json")
        {
            if (!System.IO.File.Exists(gamesFile)) return false;
            var gamesText = System.IO.File.ReadAllText(gamesFile);
            dynamic jgames = JsonConvert.DeserializeObject(gamesText);

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("SteamDB");
            
            database.DropCollection("Games");
            database.CreateCollection("Games");
            var collection = database.GetCollection<GameInfo>("Games");
            var count = (int)jgames.response.game_count;
            var games = jgames.response.games;
            for (int i = 0; i < count; i++)
            {
                var jgame = games[i];
                var game = new GameInfo()
                {
                    AppId = jgame.appid,
                    Name = jgame.name,
                    IconUrl = jgame.img_icon_url,
                    LogoUrl = jgame.img_logo_url
                };
                collection.InsertOne(game);
            }

            return true;
        }
    }
}