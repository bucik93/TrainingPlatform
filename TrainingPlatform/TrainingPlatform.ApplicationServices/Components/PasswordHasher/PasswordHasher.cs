using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.Components.PasswordHasher
{
    public class PasswordHasher : IPasswordHasher
    {
        public Task<string> HashPassword(string password, string salt)
        {
            var convertedSalt = Convert.FromBase64String(salt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: convertedSalt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
                ));

            return Task.FromResult(hashed);
        }
        public async Task<string> GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return await Task.FromResult(Convert.ToBase64String(salt));
        }

        public async Task<bool> IsPasswordConfirmed(string firstPassword, string secondPassword)
        {
            return await Task.FromResult(firstPassword == secondPassword ? true : false);
        }
    }
}
