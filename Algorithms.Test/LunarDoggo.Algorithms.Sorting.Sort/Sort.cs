// ********RoostGPT********
/*
Test generated by RoostGPT for test sampleCSharpEnv using AI Type Claude AI and AI Model claude-3-5-sonnet-20240620

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
  Assert: Verify that the resulting array is sorted in ascending order.
Validation:
  This test checks the algorithm's performance on a worst-case scenario input, ensuring it can handle completely reversed arrays.

Scenario 3: Sort an Array with Duplicate Elements

Details:
  TestName: SortArrayWithDuplicates
  Description: Ensure the Sort method correctly handles arrays containing duplicate elements.
Execution:
  Arrange: Create an array of integers with several duplicate values.
  Act: Call the Sort method on the array.
  Assert: Verify that the resulting array is sorted correctly with duplicates in the correct positions.
Validation:
  This test confirms that the algorithm maintains stability and correctly positions duplicate elements.

Scenario 4: Sort an Empty Array

Details:
  TestName: SortEmptyArray
  Description: Verify that the Sort method handles an empty array without throwing exceptions.
Execution:
  Arrange: Create an empty array of integers.
  Act: Call the Sort method on the empty array.
  Assert: Verify that no exception is thrown and the array remains empty.
Validation:
  This test ensures the algorithm gracefully handles edge cases like empty arrays without crashing.

Scenario 5: Sort an Array with a Single Element

Details:
  TestName: SortSingleElementArray
  Description: Test the Sort method's behavior when given an array containing only one element.
Execution:
  Arrange: Create an array with a single integer element.
  Act: Call the Sort method on the single-element array.
  Assert: Verify that the array remains unchanged.
Validation:
  This test checks that the algorithm correctly handles the minimal case of a single-element array without unnecessary operations.

Scenario 6: Sort an Array of Custom Objects

Details:
  TestName: SortCustomObjectArray
  Description: Verify that the Sort method can correctly sort an array of custom objects that implement IComparable<T>.
Execution:
  Arrange: Create an array of custom objects (e.g., Person objects with age as the comparison criteria) that implement IComparable<T>.
  Act: Call the Sort method on the array of custom objects.
  Assert: Verify that the resulting array is sorted according to the custom object's comparison logic.
Validation:
  This test ensures that the algorithm works correctly with custom types, demonstrating its generic capabilities.

Scenario 7: Sort a Large Array

Details:
  TestName: SortLargeArray
  Description: Test the Sort method's performance and correctness when sorting a large array of elements.
Execution:
  Arrange: Create a large array (e.g., 10,000 elements) of randomly generated integers.
  Act: Call the Sort method on the large array.
  Assert: Verify that the resulting array is correctly sorted in ascending order.
Validation:
  This test checks the algorithm's ability to handle larger datasets, which is important for performance considerations.

Scenario 8: Sort an Array of Minimum and Maximum Values

Details:
  TestName: SortArrayWithExtremeValues
  Description: Ensure the Sort method correctly handles arrays containing extreme values (minimum and maximum of the data type).
Execution:
  Arrange: Create an array of integers including int.MinValue and int.MaxValue along with other values.
  Act: Call the Sort method on the array.
  Assert: Verify that the resulting array is correctly sorted with extreme values in the correct positions.
Validation:
  This test confirms that the algorithm can handle the full range of values for the given data type without overflow or underflow issues.

These test scenarios cover various aspects of the InsertionSort<T> implementation, including edge cases, performance considerations, and different data types. They aim to ensure the correctness and robustness of the sorting algorithm across different scenarios.


*/

// ********RoostGPT********
using NUnit.Framework;
using LunarDoggo.Algorithms.Sorting;
using System;

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

            var sorter = new InsertionSort<Person>();
            sorter.Sort(array);

            Assert.That(array, Is.EqualTo(expected));
        }

        [Test, Category("valid")]
        public void SortLargeArray()
        {
            const int size = 10000;
            int[] array = new int[size];
            Random random = new Random(42);

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next();
            }

            _sorter.Sort(array);

            Assert.That(array, Is.Ordered);
        }

        [Test, Category("boundary")]
        public void SortArrayWithExtremeValues()
        {
            int[] array = { int.MaxValue, 0, int.MinValue, 100, -100 };
            int[] expected = { int.MinValue, -100, 0, 100, int.MaxValue };

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
