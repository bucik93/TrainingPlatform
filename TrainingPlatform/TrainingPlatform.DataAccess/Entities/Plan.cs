using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.DataAccess.Entities
{
    public class Plan : EntityBase
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public List<Exercise> Exercises { get; set; }

    }
}