using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.DataAccess.Entities
{
    public class ContentFile : EntityBase
    {
        public byte[] FileContent { get; set; }
        public File File { get; set; }
        public int FileId { get; set; }
    }
}
