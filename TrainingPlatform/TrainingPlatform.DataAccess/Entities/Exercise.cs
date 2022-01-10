using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.DataAccess.Entities
{
    public class Exercise : EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public int Series { get; set; }
        public int Repeat { get; set; }
        public int Weight { get; set; }

    }
}

