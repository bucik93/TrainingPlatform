using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.API.Domain.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //IEnumerable<Exercise> Exercises { get; set; }
        public ICollection<Exercise> Exercises { get; set; }

    }
}
