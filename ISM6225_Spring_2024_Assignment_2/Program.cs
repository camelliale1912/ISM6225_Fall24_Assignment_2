// Tra Le Nguyen Huong

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }
        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Step 1: Find the length of the input array
                int n = nums.Length;

                // Edge case: If the array is empty, return an empty list of missing numbers
                if (n == 0)
                {
                    return new List<int>();  // No numbers in the array, so no missing numbers
                }

                // Step 2: Create a HashSet to store unique numbers from the input array
                HashSet<int> seen = new HashSet<int>(nums);

                // Step 3: Initialize a list to store the missing numbers
                List<int> missing = new List<int>();

                // Step 4: Loop through all numbers from 1 to n to check for missing numbers
                for (int i = 1; i <= n; i++)
                {
                    // If the number is not present in the HashSet, it is missing
                    if (!seen.Contains(i))
                    {
                        missing.Add(i);
                    }
                }
                return missing;
            }
            catch (Exception)
            {
                throw;
            }

        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Step 1: Handle edge case for an empty array
                if (nums.Length == 0)
                {
                    return new int[0];  // No elements to process, return an empty array
                }

                // Step 2: Initialize two lists to hold even and odd numbers
                List<int> evens = new List<int>();
                List<int> odds = new List<int>();

                // Step 3: Iterate through the input array and separate the numbers by parity
                foreach (int num in nums)
                {
                    // If the number is even (num % 2 == 0), add it to the evens list
                    if (num % 2 == 0)
                    {
                        evens.Add(num);
                    }
                    // If the number is odd, add it to the odds list
                    else
                    {
                        odds.Add(num);
                    }
                }

                // Step 4: Combine the even and odd numbers in the correct order (evens first, then odds)
                evens.AddRange(odds);  // Add all odd numbers after the even numbers

                // Step 5: Convert the list back to an array and return it
                return evens.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Edge case: Handle empty array
                if (nums.Length == 0)
                {
                    return new int[0];  // No elements to process, return an empty array
                }

                // Step 1: Get the length of the array
                int n = nums.Length;

                // Step 2: Use a brute-force approach with two nested loops
                // Outer loop goes through each element
                for (int i = 0; i < n; i++)
                {
                    // Inner loop checks all elements that come after the current element (i)
                    for (int j = i + 1; j < n; j++)
                    {
                        // Step 3: Check if the sum of nums[i] and nums[j] equals the target
                        if (nums[i] + nums[j] == target)
                        {
                            // If we find a match, return the indices as a result
                            return new int[] { i, j };
                        }
                    }
                }

                // Edge case: If no pair is found that adds up to the target, return an empty array
                return new int[0];  // Placeholder: No valid pair found
            }
            catch (Exception)
            {
                throw;  // Re-throw the caught exception for further handling outside this method
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Edge case: Handle edge case for arrays with less than 3 elements
                if (nums.Length < 3)
                {
                    throw new ArgumentException("Array must contain at least 3 numbers to find a product.");
                }

                // Step 1: Sort the array to easily find the largest and smallest numbers
                Array.Sort(nums);

                // Step 2: Get the length of the array
                int n = nums.Length;

                // Step 3: Calculate the two possible maximum products:
                // 1. The product of the three largest numbers (this handles the case when all numbers are positive or when there are large negative numbers).
                int product1 = nums[n - 1] * nums[n - 2] * nums[n - 3];

                // 2. The product of the largest number and the two smallest numbers (this handles the case where negative numbers can lead to a larger product).
                int product2 = nums[n - 1] * nums[0] * nums[1];

                // Step 4: Return the maximum of the two products
                return Math.Max(product1, product2);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Edge case: If the number is 0, the binary representation is "0"
                if (decimalNumber == 0)
                {
                    return "0";
                }

                // Step 1: Initialize an empty string to build the binary representation
                string binary = "";

                // Step 2: Loop to divide the decimal number by 2 and build the binary string
                while (decimalNumber > 0)
                {
                    // Get the remainder when dividing by 2 (this gives the current binary digit)
                    int remainder = decimalNumber % 2;

                    // Add the remainder (binary digit) to the front of the binary string
                    binary = remainder + binary;

                    // Update the decimal number by dividing it by 2 (integer division)
                    decimalNumber = decimalNumber / 2;
                }

                // Step 3: Return the resulting binary string
                return binary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted 
        public static int FindMin(int[] nums)
        {
            try
            {
                // Edge Case 1: If the array is empty, throw an exception
                if (nums.Length == 0)
                {
                    throw new ArgumentException("Array cannot be empty.");
                }

                // Edge Case 2: If the array has only one element, that is the minimum
                if (nums.Length == 1)
                {
                    return nums[0];
                }

                // Initialize the minimum value as the first element in the array
                int min = nums[0];

                // Step 1: Iterate through the array to find the minimum element
                for (int i = 1; i < nums.Length; i++)
                {
                    // Update the minimum value if a smaller element is found
                    if (nums[i] < min)
                    {
                        min = nums[i];
                    }
                }

                // Step 2: Return the minimum value found in the array
                return min;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Edge Case 1: Negative numbers are not palindromes
                if (x < 0)
                {
                    return false;
                }

                // Edge Case 2: A single digit number or 0 is always a palindrome
                if (x < 10)
                {
                    return true;
                }

                // Convert the number to string
                string original = x.ToString();

                // Step 1: Convert the string to a char array
                char[] reversedChars = original.ToCharArray();

                // Step 2: Reverse the char array
                Array.Reverse(reversedChars);

                // Step 3: Create a new string from the reversed char array
                string reversed = new string(reversedChars);

                // Step 4: Compare the reversed string with the original string
                return reversed == original;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Enforce the constraint: 0 <= n <= 30
                if (n < 0 || n > 30)
                {
                throw new ArgumentOutOfRangeException(nameof(n), "Input must be between 0 and 30 inclusive.");
                }

                // Base cases: if n is 0 or 1, return the corresponding Fibonacci number
                if (n == 0) return 0;
                if (n == 1) return 1;

                // Initialize variables for the two previous Fibonacci numbers
                int prev = 0;
                int curr = 1;

                // Start the loop from 2 up to n to calculate the Fibonacci numbers
                for (int i = 2; i <= n; i++)
                {
                    int next = prev + curr;  // The next Fibonacci number is the sum of the previous two
                    prev = curr;             // Move curr to prev
                    curr = next;             // Update curr to the next Fibonacci number
                }

                // Return the n-th Fibonacci number
                return curr;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}
