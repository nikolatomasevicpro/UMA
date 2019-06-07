using System;
using UMA.Infrastructure.Crypto;

namespace UMA.App.Common.Utility
{
    public static class Utility
    {
        public static bool SameAs(this string left, string right)
        {
            return left.Equals(right, StringComparison.InvariantCulture);
        }

        //Convenience method since expression trees can't call on methods with optional parameters
        public static bool SameAs(this string hashed, string raw, string salt)
        {
            return hashed.SameAs(raw, salt, 256, 10000);
        }

        public static bool SameAs(this string hashed, string raw, string salt, int hashLength, int iterations)
        {
            return hashed.Equals(PasswordEncrypter.Hash(raw, salt, hashLength, iterations), StringComparison.InvariantCulture);
        }
    }
}
