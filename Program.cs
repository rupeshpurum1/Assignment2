﻿/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;
using System.Linq;
using System.Collections;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int[] numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(String.Join(",", numberOfUniqueNumbers));
            

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);
            
            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);
            

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);
            
            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3,6,9,1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);
            
            
            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2,1,2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);
            
            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }
            

            /*

            Question 1:
            Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

            Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

            Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
            Return k.

            Example 1:

            Input: nums = [1,1,2]
            Output: 2, nums = [1,2,_]
            Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
            It does not matter what you leave beyond the returned k (hence they are underscores).
            Example 2:

            Input: nums = [0,0,1,1,1,2,2,3,3,4]
            Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
            Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
            It does not matter what you leave beyond the returned k (hence they are underscores).


            Constraints:

            1 <= nums.length <= 3 * 104
            -100 <= nums[i] <= 100
            nums is sorted in non-decreasing order.
            */

            static int[] RemoveDuplicates(int[] nums)
            {
                //Here, after the k unique values, i am putting 0 for the remaining values.

                // Create a new array with the same size as the original
                int[] resultArray = new int[nums.Length];
                try
                {
                    // Write your code here and you can modify the return value according to the requirements
                    resultArray[0] = nums[0];
                    int uniqueIndex = 1;
                    for (int i = 1; i<nums.Length;i++)
                    {
                        if (!resultArray.Contains(nums[i])) 
                        {
                            resultArray[uniqueIndex] = nums[i];
                            uniqueIndex++;
                        }

                    }

                    // Fill the remaining elements with zeros
                    // The below code is commented as it is not required
                    // In C# by default the array will be intialized with all zeros if not explicitly intialized.
                    /*for (int i = uniqueIndex; i < nums.Length; i++)
                    {
                        resultArray[i] = 0;
                    }
                    */

                }
                catch (Exception)
                {
                    throw;
                }
                return resultArray;
            }

            /*

            Question 2:
            Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

            Note that you must do this in-place without making a copy of the array.

            Example 1:

            Input: nums = [0,1,0,3,12]
            Output: [1,3,12,0,0]
            Example 2:

            Input: nums = [0]
            Output: [0]

            Constraints:

            1 <= nums.length <= 104
            -231 <= nums[i] <= 231 - 1
            */

         static IList<int> MoveZeroes(int[] nums)
            {
                try
                {
                    int nonZeroIndex = 0; // Index to store non-zero elements

                    // Iterate through the array
                    for (int i = 0; i < nums.Length; i++)
                    {
                        // If the current element is non-zero
                        if (nums[i] != 0)
                        {
                            // Swap the current element with the element at nonZeroIndex
                            if (i != nonZeroIndex) // Avoid unnecessary swaps
                            {
                                (nums[i], nums[nonZeroIndex]) = (nums[nonZeroIndex], nums[i]);  // Swap using tuple deconstruction
                            }
                            nonZeroIndex++; // Increment nonZeroIndex for the next non-zero element

                        }
                      }
                }
                catch (Exception)
                {
                    throw;
                }
                return nums;
            }

            /*

            Question 3:
            Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

            Notice that the solution set must not contain duplicate triplets.



            Example 1:

            Input: nums = [-1,0,1,2,-1,-4]
            Output: [[-1,-1,2],[-1,0,1]]
            Explanation: 
            nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
            nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
            nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
            The distinct triplets are [-1,0,1] and [-1,-1,2].
            Notice that the order of the output and the order of the triplets does not matter.
            Example 2:

            Input: nums = [0,1,1]
            Output: []
            Explanation: The only possible triplet does not sum up to 0.
            Example 3:

            Input: nums = [0,0,0]
            Output: [[0,0,0]]
            Explanation: The only possible triplet sums up to 0.


            Constraints:

            3 <= nums.length <= 3000
            -105 <= nums[i] <= 105

            */

            static IList<IList<int>> ThreeSum(int[] nums)
            {
                IList<IList<int>> threeSum = new List<IList<int>>();
                try
                {
                 
                    //Sort the array
                    Array.Sort(nums);
                    for (int i = 0; i < nums.Length; i++) {
                        
                        //To skip the value if it matches the previous value to avoid duplicates.
                        if (i > 0 && nums[i] == nums[i - 1]) {
                            continue;
                        }
                        int a = nums[i];
                        
                        //left pointer
                        int left = i + 1; 
                        //right pointer
                        int right = nums.Length - 1;

                        while  (left < right) {
                            int sum = a + nums[left] + nums[right];
                            if (sum < 0)
                            {
                                left += 1;
                            }
                            else if (sum > 0)
                            {
                                right -= 1;
                            }
                            else {
                                List<int> currentTriplet = new List<int>();
                                currentTriplet.Add(a);
                                currentTriplet.Add(nums[left]);
                                currentTriplet.Add(nums[right]);
                                threeSum.Add(currentTriplet);
                                left++;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                return threeSum;
            }

            /*

            Question 4:
            Given a binary array nums, return the maximum number of consecutive 1's in the array.

            Example 1:

            Input: nums = [1,1,0,1,1,1]
            Output: 3
            Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
            Example 2:

            Input: nums = [1,0,1,1,0,1]
            Output: 2

            Constraints:

            1 <= nums.length <= 105
            nums[i] is either 0 or 1.

            */

            static int FindMaxConsecutiveOnes(int[] nums)
            {
                List<int> max = new List<int>();
                try
                {        
                    int sum = 0;
                //Looping through the elements to find the maximum consecutive ones
                    foreach (int num in nums) {
                        if (num == 1)
                        {
                            sum += 1;
                        }
                        else {
                            max.Add(sum);
                            sum = 0;
                        }
                    }
                    max.Add(sum);
                }
                catch (Exception)
                {
                    throw;
                }
                return max.Max();
            }

            /*

            Question 5:
            You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

            Requirements:
            1. Your program should prompt the user to input a binary number as an integer. 
            2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
            3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
            4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
            5. Ensure the program displays the input binary number and its corresponding decimal value.

            Example 1:
            Input: num = 101010
            Output: 42


            Constraints:

            1 <= num <= 10^9

            */

            static int BinaryToDecimal(int binary)
            {
                int decimalValue = 0;
                try
                {
                    
                    int placeValue = 1;
                    while (binary > 0) {
                        int lastDigit = binary % 10;

                        // Check if the digit is valid (0 or 1)
                        if (lastDigit != 0 && lastDigit != 1)
                        {
                            throw new ArgumentException("Invalid binary number. Only 0s and 1s allowed.");
                        }

                        // Add the digit's contribution to the decimal value
                        decimalValue += placeValue * lastDigit;

                        // Update place value for the next digit
                        placeValue *= 2;

                        // Remove the last digit from the binary number
                        binary/= 10;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return decimalValue;
            }

            /*

            Question:6
            Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
            You must write an algorithm that runs in linear time and uses linear extra space.

            Example 1:

            Input: nums = [3,6,9,1]
            Output: 3
            Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
            Example 2:

            Input: nums = [10]
            Output: 0
            Explanation: The array contains less than 2 elements, therefore return 0.


            Constraints:

            1 <= nums.length <= 105
            0 <= nums[i] <= 109

            */

            static int MaximumGap(int[] nums)
            {
                int max = 0;
                
                try
                {
                    if (nums.Length < 2)
                    {
                        return 0;
                    }
                    //sorting the array using inbuilt function
                    Array.Sort(nums);
                //Math.Abs inbuilt function to find the distance
                    for (int i =1; i <nums.Length; i++) {
                        int diff = Math.Abs(nums[i] - nums[i - 1]);
                    //if distance is greater than the current max, max value is updated
                        if (diff > max) {
                            max = diff;
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return max;
            }

            /*

            Question:7
            Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

            Example 1:

            Input: nums = [2,1,2]
            Output: 5
            Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
            Example 2:

            Input: nums = [1,2,1,10]
            Output: 0
            Explanation: 
            You cannot use the side lengths 1, 1, and 2 to form a triangle.
            You cannot use the side lengths 1, 1, and 10 to form a triangle.
            You cannot use the side lengths 1, 2, and 10 to form a triangle.
            As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

            Constraints:

            3 <= nums.length <= 104
            1 <= nums[i] <= 106

            */

            static int LargestPerimeter(int[] nums)
            {
                try
                {
                //sorting the array to ease the operation
                    Array.Sort(nums);
                // adding the values from largest since we are aiming the largest perimiter
                    for (int i = nums.Length - 1; i >= 2; --i)
                    {
                    //only when the third element(smaller than the remaing two) is greater than the sum of two, it is considered for the traingle.
                        int c = nums[i - 1] + nums[i - 2];
                        if (c > nums[i])
                        {
                            return c + nums[i];
                        }
                    }

                    // Write your code here and you can modify the return value according to the requirements
                    
                }
                catch (Exception)
                {
                    throw;
                }
                return 0;
            }

            /*

            Question:8

            Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

            Find the leftmost occurrence of the substring part and remove it from s.
            Return s after removing all occurrences of part.

            A substring is a contiguous sequence of characters in a string.



            Example 1:

            Input: s = "daabcbaabcbc", part = "abc"
            Output: "dab"
            Explanation: The following operations are done:
            - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
            - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
            - s = "dababc", remove "abc" starting at index 3, so s = "dab".
            Now s has no occurrences of "abc".
            Example 2:

            Input: s = "axxxxyyyyb", part = "xy"
            Output: "ab"
            Explanation: The following operations are done:
            - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
            - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
            - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
            - s = "axyb", remove "xy" starting at index 1 so s = "ab".
            Now s has no occurrences of "xy".

            Constraints:

            1 <= s.length <= 1000
            1 <= part.length <= 1000
            s​​​​​​ and part consists of lowercase English letters.

            */

            static string RemoveOccurrences(string s, string part)
            {
                try{

                int n = part.Length;
                while (s.Contains(part))
                {
                    //identify the first occurence of part in s    i.e, the index
                    int i = s.IndexOf(part);

                    //slicing the string based on the obtained index 
                    s = s.Substring(0, i) + s.Substring(i + n);
                }
                }
                catch (Exception)
                {
                    throw;
                }
            return s;
            }

            /* Inbuilt Functions - Don't Change the below functions */
            static string ConvertIListToNestedList(IList<IList<int>> input)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("["); // Add the opening square bracket for the outer list

                for (int i = 0; i < input.Count; i++)
                {
                    IList<int> innerList = input[i];
                    sb.Append("[" + string.Join(",", innerList) + "]");

                    // Add a comma unless it's the last inner list
                    if (i < input.Count - 1)
                    {
                        sb.Append(",");
                    }
                }

                sb.Append("]"); // Add the closing square bracket for the outer list

                return sb.ToString();
            }


            static string ConvertIListToArray(IList<int> input)
            {
                // Create an array to hold the strings in input
                string[] strArray = new string[input.Count];

                for (int i = 0; i < input.Count; i++)
                {
                    strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
                }

                // Join the strings in strArray with commas and enclose them in square brackets
                string result = "[" + string.Join(",", strArray) + "]";

                return result;
            }
        }
    }
