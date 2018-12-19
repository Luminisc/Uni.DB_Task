using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uni.DB_Task.Models
{
    public class GameDetailsViewModel
    {
        public string AppId { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string LogoUrl { get; set; }

        public int Price { get; set; }
        public string PriceText => $"{Price / 100.0f} руб.";
        public string Description { get; set; }
        public List<ScreenshotInfo> Screens { get; set; }
    }
}
