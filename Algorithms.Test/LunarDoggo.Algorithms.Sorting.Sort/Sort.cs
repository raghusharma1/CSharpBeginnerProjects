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
  Description: Verify that the Sort method handles an already sorted array correctly without making unnecessary swaps.
Execution:
  Arrange: Create an array of integers that is already in ascending order.
  Act: Call the Sort method on the array.
  Assert: Verify that the array remains in the same order after sorting.
Validation:
  This test ensures that the algorithm is efficient when dealing with pre-sorted data, which is a common edge case for sorting algorithms.

Scenario 2: Sort a Reverse-Sorted Array

Details:
  TestName: SortReverseSortedArray
  Description: Test the Sort method's ability to correctly sort an array that is in descending order.
Execution:
  Arrange: Create an array of integers in descending order.
  Act: Call the Sort method on the array.
  Assert: Check that the resulting array is in ascending order.
Validation:
  This test verifies the algorithm's performance in a worst-case scenario, where every element needs to be moved.

Scenario 3: Sort an Array with Duplicate Elements

Details:
  TestName: SortArrayWithDuplicates
  Description: Ensure that the Sort method correctly handles arrays containing duplicate values.
Execution:
  Arrange: Create an array of integers with several duplicate values.
  Act: Call the Sort method on the array.
  Assert: Verify that the resulting array is sorted and all duplicates are in the correct position.
Validation:
  This test checks the algorithm's stability and correct handling of equal elements.

Scenario 4: Sort an Empty Array

Details:
  TestName: SortEmptyArray
  Description: Verify that the Sort method handles an empty array without throwing exceptions.
Execution:
  Arrange: Create an empty array of integers.
  Act: Call the Sort method on the empty array.
  Assert: Check that the method completes without errors and the array remains empty.
Validation:
  This test ensures proper handling of edge cases, specifically an empty input.

Scenario 5: Sort a Single-Element Array

Details:
  TestName: SortSingleElementArray
  Description: Test the Sort method's behavior when given an array with only one element.
Execution:
  Arrange: Create an array with a single integer.
  Act: Call the Sort method on the single-element array.
  Assert: Verify that the array remains unchanged.
  Validation:
  This test checks the algorithm's handling of minimal input, ensuring it doesn't produce errors or unnecessary operations.

Scenario 6: Sort Array of Custom Objects

Details:
  TestName: SortArrayOfCustomObjects
  Description: Verify that the Sort method can correctly sort an array of custom objects that implement IComparable<T>.
Execution:
  Arrange: Create an array of custom objects (e.g., Person objects with age as the comparison criteria).
  Act: Call the Sort method on the array of custom objects.
  Assert: Check that the resulting array is sorted based on the custom object's comparison logic.
Validation:
  This test ensures that the generic implementation works correctly with custom types, adhering to their specific comparison logic.

Scenario 7: Sort Large Array

Details:
  TestName: SortLargeArray
  Description: Test the Sort method's performance and correctness with a large array of elements.
Execution:
  Arrange: Create a large array (e.g., 100,000 elements) with random integers.
  Act: Call the Sort method on the large array.
  Assert: Verify that the resulting array is correctly sorted.
Validation:
  This test checks the algorithm's efficiency and correctness when dealing with a large dataset, which is important for performance considerations.

Scenario 8: Sort Array with Negative Numbers

Details:
  TestName: SortArrayWithNegativeNumbers
  Description: Ensure that the Sort method correctly handles arrays containing both positive and negative numbers.
Execution:
  Arrange: Create an array of integers including both positive and negative numbers.
  Act: Call the Sort method on the array.
  Assert: Check that the resulting array is sorted correctly with negative numbers preceding positive ones.
Validation:
  This test verifies the correct ordering of elements when the range includes negative values, ensuring the comparison logic works as expected.

These scenarios cover various aspects of the InsertionSort<T> implementation, including edge cases, performance considerations, and different types of input data.


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
        private InsertionSort<int> _sorter;

        [SetUp]
        public void Setup()
        {
            _sorter = new InsertionSort<int>();
        }

        [Test, Category("valid")]
        public void SortAlreadySortedArray()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            int[] expected = { 1, 2, 3, 4, 5 };

            _sorter.Sort(array);

            Assert.That(array, Is.EqualTo(expected));
        }

        [Test, Category("valid")]
        public void SortReverseSortedArray()
        {
            int[] array = { 5, 4, 3, 2, 1 };
            int[] expected = { 1, 2, 3, 4, 5 };

            _sorter.Sort(array);

            Assert.That(array, Is.EqualTo(expected));
        }

        [Test, Category("valid")]
        public void SortArrayWithDuplicates()
        {
            int[] array = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
            int[] expected = { 1, 1, 2, 3, 3, 4, 5, 5, 5, 6, 9 };

            _sorter.Sort(array);

            Assert.That(array, Is.EqualTo(expected));
        }

        [Test, Category("boundary")]
        public void SortEmptyArray()
        {
            int[] array = { };

            _sorter.Sort(array);

            Assert.That(array, Is.Empty);
        }

        [Test, Category("boundary")]
        public void SortSingleElementArray()
        {
            int[] array = { 42 };
            int[] expected = { 42 };

            _sorter.Sort(array);

            Assert.That(array, Is.EqualTo(expected));
        }

        [Test, Category("valid")]
        public void SortArrayOfCustomObjects()
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

            var sorter = new InsertionSort<Person>();
            sorter.Sort(array);

            Assert.That(array, Is.EqualTo(expected));
        }

        [Test, Category("valid")]
        public void SortLargeArray()
        {
            const int size = 100000;
            int[] array = new int[size];
            Random random = new Random(42); // Seed for reproducibility

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next();
            }

            _sorter.Sort(array);

            Assert.That(array, Is.Ordered);
        }

        [Test, Category("valid")]
        public void SortArrayWithNegativeNumbers()
        {
            int[] array = { -3, 5, -1, 0, 2, -4 };
            int[] expected = { -4, -3, -1, 0, 2, 5 };

            _sorter.Sort(array);

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
