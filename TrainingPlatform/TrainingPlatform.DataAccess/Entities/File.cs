using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.DataAccess.Entities
{
    public class File : EntityBase
    {
        public virtual ContentFile ContentFile { get; set; }
        public virtual Exercise Exercise { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(5)]
        public string Extension { get; set; }

    }
}
