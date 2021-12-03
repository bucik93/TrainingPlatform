using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.API.Domain.Models
{
    public class ContentFile
    {
        public int Id { get; set; }
        public byte[] FileContent { get; set; }
        public File File { get; set; }
        public int FileId { get; set; }
    }
}