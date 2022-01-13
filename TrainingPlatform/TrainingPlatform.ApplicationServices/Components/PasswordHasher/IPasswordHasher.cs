using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.Components.PasswordHasher
{
    public interface IPasswordHasher
    {
        Task<string> GenerateSalt();
        Task<string> HashPassword(string password, string salt);
        Task<bool> IsPasswordConfirmed(string firstPassword, string secondPassword);
    }
}
