using System;
using System.Linq;

namespace Unleashed_Solution.Utilities
{
    public class StringHelper
    {
        private static Random random = new Random();

        public static string GenerateRandomString(int stringLength)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, stringLength).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}