// ********RoostGPT********
/*
Test generated by RoostGPT for test sampleCSharpEnv using AI Type  and AI Model 

ROOST_METHOD_HASH=Sort_e91a00f5b4
ROOST_METHOD_SIG_HASH=Sort_77d77f7e8e

   ########## Test-Scenarios ##########  

Based on the provided InsertionSort<T> class and its Sort method, here are several test scenarios:

Scenario 1: Sort an Already Sorted Array

Details:
  TestName: SortAlreadySortedArray
  Description: Verify that the Sort method correctly handles an array that is already in sorted order.
Execution:
  Arrange: Create an array of integers that is already sorted in ascending order.
  Act: Call the Sort method on the array.
  Assert: Verify that the array remains in the same order after sorting.
Validation:
  This test ensures that the algorithm doesn't unnecessarily modify an already sorted array, which is an important efficiency consideration.

Scenario 2: Sort a Reverse Sorted Array

Details:
  TestName: SortReverseSortedArray
  Description: Test the Sort method's ability to correctly sort an array that is in reverse order.
Execution:
  Arrange: Create an array of integers sorted in descending order.
  Act: Call the Sort method on the array.
  Assert: Verify that the array is now sorted in ascending order.
Validation:
  This test checks the algorithm's performance in a worst-case scenario, where every element needs to be moved.

Scenario 3: Sort an Array with Duplicate Elements

Details:
  TestName: SortArrayWithDuplicates
  Description: Ensure that the Sort method correctly handles arrays containing duplicate elements.
Execution:
  Arrange: Create an array of integers with several duplicate values.
  Act: Call the Sort method on the array.
  Assert: Verify that the array is sorted correctly, with duplicate elements appearing together in the correct order.
Validation:
  This test confirms that the algorithm maintains stability and correctly positions duplicate elements.

Scenario 4: Sort an Empty Array

Details:
  TestName: SortEmptyArray
  Description: Verify that the Sort method handles an empty array without throwing exceptions.
Execution:
  Arrange: Create an empty array.
  Act: Call the Sort method on the empty array.
  Assert: Verify that no exception is thrown and the array remains empty.
Validation:
  This test ensures that the method gracefully handles edge cases like empty arrays without crashing.

Scenario 5: Sort an Array with a Single Element

Details:
  TestName: SortSingleElementArray
  Description: Test the Sort method's behavior when given an array containing only one element.
Execution:
  Arrange: Create an array with a single element.
  Act: Call the Sort method on the single-element array.
  Assert: Verify that the array remains unchanged and no exceptions are thrown.
Validation:
  This test checks another edge case, ensuring the method works correctly with minimal input.

Scenario 6: Sort an Array of Custom Objects

Details:
  TestName: SortCustomObjectArray
  Description: Verify that the Sort method can correctly sort an array of custom objects that implement IComparable<T>.
Execution:
  Arrange: Create an array of custom objects (e.g., Person objects with age as the comparison criteria).
  Act: Call the Sort method on the array of custom objects.
  Assert: Verify that the array is sorted correctly based on the custom object's comparison logic.
Validation:
  This test ensures that the generic implementation works correctly with custom types, not just primitive types.

Scenario 7: Sort a Large Array

Details:
  TestName: SortLargeArray
  Description: Test the Sort method's performance and correctness with a large array of elements.
Execution:
  Arrange: Create a large array (e.g., 10,000 elements) with random values.
  Act: Call the Sort method on the large array.
  Assert: Verify that the array is correctly sorted and measure the time taken.
Validation:
  This test checks the algorithm's efficiency and correctness when dealing with a large dataset, which is important for performance considerations.

Scenario 8: Sort an Array of Negative Numbers

Details:
  TestName: SortNegativeNumberArray
  Description: Ensure that the Sort method correctly handles arrays containing negative numbers.
Execution:
  Arrange: Create an array of integers including negative numbers.
  Act: Call the Sort method on the array.
  Assert: Verify that the array is sorted correctly with negative numbers in the correct position.
Validation:
  This test confirms that the algorithm correctly handles negative values, which can sometimes cause issues in sorting algorithms.

These scenarios cover a range of cases including edge cases, performance considerations, and different types of input, providing a comprehensive test suite for the InsertionSort<T> class.


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
            var array = new Person[]
            {
                new Person("Alice", 30),
                new Person("Bob", 25),
                new Person("Charlie", 35)
            };
            var expected = new Person[]
            {
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
            Random rnd = new Random(42); // Use seed for reproducibility
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(1, 1000000);
            }

            _intSorter.Sort(array);

            Assert.That(array, Is.Ordered);
        }

        [Test, Category("valid")]
        public void SortNegativeNumberArray()
        {
            int[] array = { -5, -2, -8, -1, -9 };
            int[] expected = { -9, -8, -5, -2, -1 };

            _intSorter.Sort(array);

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
