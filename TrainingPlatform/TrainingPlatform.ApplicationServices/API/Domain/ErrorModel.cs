using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.API.Domain
{
    public class ErrorModel
    {
        public string Error { get; }
      
        public ErrorModel(string error)
        {
            this.Error = error;
        }
    }
}
