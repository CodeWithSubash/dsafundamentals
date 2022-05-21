using NUnit.Framework;
using search;

namespace dsa.tests
{
    public class BinarySearchTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SearchForAvailableElement_ShouldReturn_True()
        {
            BinarySearch bs = new BinarySearch(new int[] { 2, 3, 4, 5, 6 });

            //Act
            var result = bs.Search(4);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void SearchForAvailableLeftEdgeElement_ShouldReturn_True()
        {
            BinarySearch bs = new BinarySearch(new int[] { 2, 3, 4, 5, 6 });

            //Act
            var result = bs.Search(2);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void SearchForAvailableRightEdgeElement_ShouldReturn_True()
        {
            BinarySearch bs = new BinarySearch(new int[] { 2, 3, 4, 5, 6 });

            //Act
            var result = bs.Search(6);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void SearchForAvailableRightEdgeElement_EvenElements_ShouldReturn_True()
        {
            BinarySearch bs = new BinarySearch(new int[] { 2, 3, 4, 5, 6, 12 });

            //Act
            var result = bs.Search(12);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void SearchForAvailableWithNegativeElements_ShouldReturn_True()
        {
            BinarySearch bs = new BinarySearch(new int[] { -12, -3, 0, 5, 6, 12 });

            //Act
            var result = bs.Search(-12);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void SearchForNonAvailableWithNegativeElements_ShouldReturn_False()
        {
            BinarySearch bs = new BinarySearch(new int[] { -12, -3, 0, 5, 6, 12 });

            //Act
            var result = bs.Search(-15);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void SearchForAvailableLeftEdge_WithTwoElements_ShouldReturn_True()
        {
            BinarySearch bs = new BinarySearch(new int[] { 6, 12 });

            //Act
            var result = bs.Search(6);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void SearchForAvailableRightEdge_WithTwoElements_ShouldReturn_True()
        {
            BinarySearch bs = new BinarySearch(new int[] { 6, 12 });

            //Act
            var result = bs.Search(12);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void SearchForNotAvailable_WithTwoElements_ShouldReturn_False()
        {
            BinarySearch bs = new BinarySearch(new int[] { 6, 12 });

            //Act
            var result1 = bs.Search(5);

            //Assert
            Assert.IsFalse(result1);

            //Act2
            var result2 = bs.Search(13);

            //Assert2
            Assert.IsFalse(result2);
        }
    }
}