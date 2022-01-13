using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.DataAccess.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }

        public List<Role> Roles { get; set; }
        public List<Plan> Plans { get; set; }

    }
}
