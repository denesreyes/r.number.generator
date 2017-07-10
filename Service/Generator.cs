using System;
using System.Collections.Generic;
using System.Linq;

namespace n.random.generator.Service
{
    public class Generator
    {
        // Private fields
        private static Random _pseudoRandom;

        // Constructor
        public Generator()
        {
            // Utilize the .net random class to generate our "Random" numbers. Note: the random class is termed as a pseudo random due to the use of the CPU clock as its trigger seed.
            // For a more secure random number, check out the RNGCryptoServiceProvider.
            _pseudoRandom = new Random();
        }


        /// <summary>
        /// Handler - Generate a collection of unique integers in random order within the provided bound.
        /// </summary>
        /// <param name="lowerBound">Lower bound</param>
        /// <param name="upperBound">Upper bound</param>
        /// <returns>Collection of integers</returns>
        public int[] GenerateUniqueRandomNumberList(int lowerBound, int upperBound)
        {
            // Make sure lower bound value is lesser than the upper bound value.
            if (lowerBound > upperBound)
                throw new Exception($"The provided upper bound value ({upperBound}) must be greater than or equal to the provided lower bound value ({lowerBound}).");
            var cap = upperBound - lowerBound + 1; // Determine array size 
            var result = new int[cap];
            var ol = GenerateOrderedList(lowerBound, upperBound).ToList(); // Convert to list to utilize the listing wrapper
            var index = 0;

            // Iterate from cap bound in decrement of 1. These will allow us to generate a random value per challenge.
            for (var x = cap; x > 0; x--)
            {
                // Get a random number then use that number to get the associated index value from the ordered list and append it to the result array and finally remove that index from the ordered list.
                var rn = GetRandomNumber(0, x);
                result[index] = ol[rn];
                ol.RemoveAt(rn);
                index++; // Increment index
            }


            return result;
        }


        /// <summary>
        /// Handler - Retrieve a random integer within the provided range.
        /// </summary>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns></returns>
        private static int GetRandomNumber(int min, int max)
        {
            // Make sure min value is lesser than the provided max value
            if (min > max)
                throw new Exception($"The provided maximum value ({max}) must be greater than or equal to the provided minimum value ({min}).");
            return _pseudoRandom.Next(min, max);
        }


        /// <summary>
        /// Handler - Generate an array (int) based on the passed in lower and upper bound.
        /// </summary>
        /// <param name="lowerBound">Lower bound (starting value)</param>
        /// <param name="upperBound">Upper bound (maximum value)</param>
        /// <returns>Array</returns>
        private static IEnumerable<int> GenerateOrderedList(int lowerBound, int upperBound)
        {
            var cap = upperBound - lowerBound + 1;
            var ol = new int[cap];
            for (var x = 0; x < cap; x++)
                ol[x] = lowerBound + x;
            return ol;
        }

    }
}
