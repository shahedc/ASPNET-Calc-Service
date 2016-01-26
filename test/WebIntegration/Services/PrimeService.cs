using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebIntegration.Services
{
    public class PrimeService
    {
        public bool IsPrime(int numberToCheck)
        {
            // Test whether the parameter is a prime number.
            if ((numberToCheck & 1) == 0)
            {
                if (numberToCheck == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // Note:
            // ... This version was changed to test the square.
            // ... Original version tested against the square root.
            // ... Also we exclude 1 at the end.
            for (int i = 3; (i * i) <= numberToCheck; i += 2)
            {
                if ((numberToCheck % i) == 0)
                {
                    return false;
                }
            }
            return numberToCheck != 1;
        }
    }
}
