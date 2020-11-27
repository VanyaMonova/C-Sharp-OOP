using NUnit.Framework;

using System.Linq;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldBeWith16Elements()
        {
            int[] numbers = Enumerable.Range(1, 16).ToArray();

            Database database = new Database(numbers);

            int expectedResult = 16;
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ConstructorShouldThrowExceptionIfElementsAreNot16()
        {
            int[] numbers = Enumerable.Range(1, 10).ToArray();

            Database database = new Database(numbers);

            int expectedResult = 10;
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void AddElementAtNextFreeCellWhenSuccessful()
        {
            int[] numbers = Enumerable.Range(1, 10).ToArray();

            Database database = new Database(numbers);

            database.Add(5);
            var allElements = database.Fetch();

            int expectedValue = 5;
            int actualValue = allElements[10];

            int expectedCount = 11;
            int actualCount = database.Count;

            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowExceptionWhenElementsAreAbove16()
        {
            int[] numbers = Enumerable.Range(1, 16).ToArray();

            Database database = new Database(numbers);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(10);
            });
        }
        [Test]
        public void RemoveShouldDecreaseCountWhenSuccessful()
        {
            int[] numbers = Enumerable.Range(1, 10).ToArray();

            Database database = new Database(numbers);

            database.Remove();

            int expectedValue = 9;
            int actualValue = database.Fetch()[8];

            int expectedCount = 9;
            int actualCount = database.Count;

            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenDatabaseIsEmpty()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
                          database.Remove());

        }

        [Test]
        public void FetchShouldReturnAllElements()
        {
            int[] numbers = Enumerable.Range(1, 5).ToArray();

            Database database = new Database(numbers);

            var allElements = database.Fetch();

            int[] expectedValue = { 1, 2, 3, 4, 5 };

            CollectionAssert.AreEqual(expectedValue, allElements);

        }
    }
}