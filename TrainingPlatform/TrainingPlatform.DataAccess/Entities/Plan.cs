﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.DataAccess.Entities
{
    public class Plan : EntityBase
    {
        public string Name { get; set; }
        //public List<User> Users { get; set; }
        public IList<ExercisePlan> ExercisePlans;
        public ICollection<PlanUser> PlanUsers { get; set; }


    }
}