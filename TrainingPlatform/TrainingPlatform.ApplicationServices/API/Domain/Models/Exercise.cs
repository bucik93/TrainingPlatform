using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.API.Domain.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }

        //public File File { get; set; }
        //public int FileId { get; set; }
        public int Series { get; set; }
        public int Repeat { get; set; }
        public int Weight { get; set; }
        //public TimeSpan Time { get; set; }
        //public bool OneHanded { get; set; }
        //public bool BothHands { get; set; }
    }
}
