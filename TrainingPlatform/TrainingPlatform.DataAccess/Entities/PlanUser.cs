using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.DataAccess.Entities
{
    public class PlanUser
    {
        public int PlanId { get; set; }
        public Plan Plan { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
