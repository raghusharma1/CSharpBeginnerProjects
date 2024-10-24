// ********RoostGPT********
/*
Test generated by RoostGPT for test sampleCSharpEnv using AI Type  and AI Model 

ROOST_METHOD_HASH=Sort_e91a00f5b4
ROOST_METHOD_SIG_HASH=Sort_77d77f7e8e

   ########## Test-Scenarios ##########  

Based on the provided method and context, here are several test scenarios for the InsertionSort<T> class:

Scenario 1: Sort an Already Sorted Array

Details:
  TestName: SortAlreadySortedArray
  Description: Verify that the Sort method correctly handles an array that is already in sorted order.
Execution:
  Arrange: Create an array of integers that is already sorted in ascending order.
  Act: Call the Sort method on the array.
  Assert: Verify that the array remains unchanged after sorting.
Validation:
  This test ensures that the algorithm doesn't unnecessarily modify an already sorted array, which is an important edge case for efficiency.

Scenario 2: Sort a Reverse Sorted Array

Details:
  TestName: SortReverseSortedArray
  Description: Test the Sort method's ability to correctly sort an array that is in reverse order.
Execution:
  Arrange: Create an array of integers sorted in descending order.
  Act: Call the Sort method on the array.
  Assert: Check that the resulting array is sorted in ascending order.
Validation:
  This test verifies the algorithm's effectiveness in handling a worst-case scenario for insertion sort.

Scenario 3: Sort an Array with Duplicate Elements

Details:
  TestName: SortArrayWithDuplicates
  Description: Ensure that the Sort method correctly handles arrays containing duplicate elements.
Execution:
  Arrange: Create an array of integers with several duplicate values.
  Act: Call the Sort method on the array.
  Assert: Verify that the resulting array is sorted and all duplicates are correctly positioned.
Validation:
  This test checks the algorithm's ability to handle non-unique elements, which is crucial for real-world data sets.

Scenario 4: Sort an Empty Array

Details:
  TestName: SortEmptyArray
  Description: Verify that the Sort method handles an empty array without throwing exceptions.
Execution:
  Arrange: Create an empty array of integers.
  Act: Call the Sort method on the empty array.
  Assert: Check that the method completes without errors and the array remains empty.
Validation:
  This test ensures the algorithm gracefully handles edge cases like empty arrays without crashing.

Scenario 5: Sort an Array with a Single Element

Details:
  TestName: SortSingleElementArray
  Description: Test the Sort method's behavior when given an array containing only one element.
Execution:
  Arrange: Create an array with a single integer element.
  Act: Call the Sort method on the single-element array.
  Assert: Verify that the array remains unchanged after sorting.
Validation:
  This test checks another edge case, ensuring the algorithm correctly handles minimal input without unnecessary operations.

Scenario 6: Sort an Array of Custom Objects

Details:
  TestName: SortCustomObjectArray
  Description: Verify that the Sort method can correctly sort an array of custom objects that implement IComparable<T>.
Execution:
  Arrange: Create an array of custom objects (e.g., Person objects with age as the comparison criteria).
  Act: Call the Sort method on the array of custom objects.
  Assert: Check that the resulting array is sorted based on the custom object's comparison logic.
Validation:
  This test ensures that the generic implementation of the algorithm works correctly with custom types, demonstrating its versatility.

Scenario 7: Sort a Large Array

Details:
  TestName: SortLargeArray
  Description: Test the Sort method's performance and correctness when handling a large array of elements.
Execution:
  Arrange: Create a large array (e.g., 10,000 elements) of random integers.
  Act: Call the Sort method on the large array.
  Assert: Verify that the resulting array is correctly sorted.
Validation:
  This test checks the algorithm's ability to handle larger datasets, which is important for understanding its performance characteristics.

Scenario 8: Sort an Array of Strings

Details:
  TestName: SortStringArray
  Description: Ensure that the Sort method correctly sorts an array of strings based on their natural ordering.
Execution:
  Arrange: Create an array of strings with mixed case and special characters.
  Act: Call the Sort method on the string array.
  Assert: Verify that the resulting array is sorted alphabetically, respecting string comparison rules.
Validation:
  This test demonstrates the algorithm's ability to work with different types that implement IComparable<T>, such as strings.

These scenarios cover various aspects of the InsertionSort<T> implementation, including edge cases, different data types, and potential real-world usage scenarios.


*/

// ********RoostGPT********
using NUnit.Framework;
using System;
using LunarDoggo.Algorithms.Sorting;

namespace LunarDoggo.Algorithms.Sorting.Test
{
    [TestFixture]
    public class SortTest
    {
        private InsertionSort<int> _intSorter;
        private InsertionSort<string> _stringSorter;

        [SetUp]
        public void Setup()
        {
            _intSorter = new InsertionSort<int>();
            _stringSorter = new InsertionSort<string>();
        }

        [Test, Category("valid")]
        public void SortAlreadySortedArray()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            int[] expected = { 1, 2, 3, 4, 5 };

            _intSorter.Sort(array);

            Assert.That(array, Is.EqualTo(expected));
        }

        [Test, Category("valid")]
        public void SortReverseSortedArray()
        {
            int[] array = { 5, 4, 3, 2, 1 };
            int[] expected = { 1, 2, 3, 4, 5 };

            _intSorter.Sort(array);

            Assert.That(array, Is.EqualTo(expected));
        }

        [Test, Category("valid")]
        public void SortArrayWithDuplicates()
        {
            int[] array = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
            int[] expected = { 1, 1, 2, 3, 3, 4, 5, 5, 5, 6, 9 };

            _intSorter.Sort(array);

            Assert.That(array, Is.EqualTo(expected));
        }

        [Test, Category("boundary")]
        public void SortEmptyArray()
        {
            int[] array = { };

            _intSorter.Sort(array);

            Assert.That(array, Is.Empty);
        }

        [Test, Category("boundary")]
        public void SortSingleElementArray()
        {
            int[] array = { 42 };
            int[] expected = { 42 };

            _intSorter.Sort(array);

            Assert.That(array, Is.EqualTo(expected));
        }

        [Test, Category("valid")]
        public void SortCustomObjectArray()
        {
            Person[] array = {
                new Person("Alice", 30),
                new Person("Bob", 25),
                new Person("Charlie", 35)
            };
            Person[] expected = {
                new Person("Bob", 25),
                new Person("Alice", 30),
                new Person("Charlie", 35)
            };

            var personSorter = new InsertionSort<Person>();
            personSorter.Sort(array);

            Assert.That(array, Is.EqualTo(expected));
        }

        [Test, Category("valid")]
        public void SortLargeArray()
        {
            const int size = 10000;
            int[] array = new int[size];
            Random rnd = new Random(42); // Use a seed for reproducibility
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(1, 1000);
            }

            _intSorter.Sort(array);

            Assert.That(array, Is.Ordered);
        }

        [Test, Category("valid")]
        public void SortStringArray()
        {
            string[] array = { "banana", "Apple", "cherry", "Date", "elderberry" };
            string[] expected = { "Apple", "banana", "cherry", "Date", "elderberry" };

            _stringSorter.Sort(array);

            Assert.That(array, Is.EqualTo(expected));
        }
    }

    public class Person : IComparable<Person>
    {
        public string Name { get; }
        public int Age { get; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int CompareTo(Person other)
        {
            return Age.CompareTo(other.Age);
        }

        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   Name == person.Name &&
                   Age == person.Age;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age);
        }
    }
}
