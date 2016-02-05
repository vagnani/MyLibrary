using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace MyLibrary.Maths.NumericExtension
{
    public static partial class Factors
    {
        public static Dictionary<int, int> PrimeFactorization(int n)
        {
            Dictionary<int, int> primeFactors = Factorization(n, null);
            return primeFactors;
        }

        //to recheck the method below
        private static Dictionary<int, int> Factorization(int n, Tuple<bool, bool> rootMade_isPrime)
        {
            throw new NotImplementedException();
        }

        public static bool IsPrime(int n)
        {
            bool isPrime = true;

            for (int divisore = 2; divisore <= (Math.Sqrt(n)); divisore++)
            {
                if (n % divisore == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            return isPrime;
        }
    }
}

//modificare completamente tutto
//1-mettere tutto in inglese
//2-eliminare ogni campo statico e migliorare algoritmo (anche guardando qualche algoritmo online)
//3-trasferire tutto su github