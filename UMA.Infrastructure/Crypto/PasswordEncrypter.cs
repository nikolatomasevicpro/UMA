using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UMA.Infrastructure.Crypto
{
    public static class PasswordEncrypter
    {
        public class HashResult
        {
            public string Salt { get; set; }
            public string Hash { get; set; }
        }

        public static string Hash(string password, string salt, int hashLength = 256, int iterations = 10000)
        {
            try
            {
                return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: Convert.FromBase64String(salt),
                    prf: KeyDerivationPrf.HMACSHA512,
                    iterationCount: iterations,
                    numBytesRequested: hashLength
                    ));
            }
            catch
            { 
                //ignore
            }

            return string.Empty;
        }

        public static HashResult Hash(string password, int saltLength = 128, int hashLength = 256, int iterations = 10000)
        {
            try
            {

                byte[] salt = new byte[saltLength];

                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }

                string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA512,
                    iterationCount: iterations,
                    numBytesRequested: hashLength
                    ));

                return new HashResult
                {
                    Salt = Convert.ToBase64String(salt),
                    Hash = hash
                };
            }
            catch
            {
                //ignore
            }

            return default(HashResult);
        }
    }
}
