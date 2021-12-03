using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.API.Domain.Models
{
    public class File
    {
        public int Id { get; set; }
        public virtual ContentFile ContentFile { get; set; }
        public virtual Exercise Exercise { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
    }
}
