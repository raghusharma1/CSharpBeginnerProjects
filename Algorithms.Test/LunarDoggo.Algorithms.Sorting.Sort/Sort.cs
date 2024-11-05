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
  Assert: Verify that the array remains in the same order after sorting.
Validation:
  This test ensures that the algorithm doesn't unnecessarily modify an already sorted array, which is an important efficiency consideration.

Scenario 2: Sort a Reverse-Sorted Array

Details:
  TestName: SortReverseSortedArray
  Description: Test the Sort method's ability to correctly sort an array that is in descending order.
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
  Description: Verify that the Sort method handles an empty array without errors.
Execution:
  Arrange: Create an empty array of integers.
  Act: Call the Sort method on the empty array.
  Assert: Verify that the method completes without throwing any exceptions and the array remains empty.
Validation:
  This test ensures that the algorithm gracefully handles edge cases, such as empty arrays.

Scenario 5: Sort a Single-Element Array

Details:
  TestName: SortSingleElementArray
  Description: Test the Sort method's behavior when given an array with only one element.
Execution:
  Arrange: Create an array with a single integer element.
  Act: Call the Sort method on the single-element array.
  Assert: Verify that the array remains unchanged and no exceptions are thrown.
Validation:
  This test checks another edge case, ensuring the algorithm works correctly with minimal input.

Scenario 6: Sort an Array of Custom Objects

Details:
  TestName: SortArrayOfCustomObjects
  Description: Verify that the Sort method can correctly sort an array of custom objects that implement IComparable<T>.
Execution:
  Arrange: Create an array of custom objects (e.g., Person objects with age as the comparison criteria) that implement IComparable<T>.
  Act: Call the Sort method on the array of custom objects.
  Assert: Verify that the array is sorted correctly based on the custom comparison logic.
Validation:
  This test ensures that the algorithm works correctly with generic types and respects custom comparison logic.

Scenario 7: Sort a Large Array

Details:
  TestName: SortLargeArray
  Description: Test the Sort method's performance and correctness with a large array of elements.
Execution:
  Arrange: Create a large array (e.g., 10,000 elements) of random integers.
  Act: Call the Sort method on the large array.
  Assert: Verify that the array is correctly sorted in ascending order.
Validation:
  This test checks the algorithm's performance and correctness with a significant amount of data, which is important for real-world usage scenarios.

Scenario 8: Sort an Array with Negative Numbers

Details:
  TestName: SortArrayWithNegativeNumbers
  Description: Ensure that the Sort method correctly handles arrays containing negative numbers.
Execution:
  Arrange: Create an array of integers that includes both positive and negative numbers.
  Act: Call the Sort method on the array.
  Assert: Verify that the array is sorted correctly, with negative numbers appearing before positive numbers in ascending order.
Validation:
  This test confirms that the algorithm correctly handles the full range of integer values, including negatives.

These test scenarios cover various aspects of the InsertionSort<T> class, including edge cases, different input types, and performance considerations. They should provide a comprehensive test suite for the Sort method.


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
            int[] array = { 1 };
            int[] expected = { 1 };

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
            var random = new Random(42);
            int[] array = new int[10000];
            for (int i = 0; i < array.Length; i++)
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
