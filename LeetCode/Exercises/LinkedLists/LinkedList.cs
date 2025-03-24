using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Exercises.LinkedLists
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Next { get; set; }

        public Node<T> Prev { get; set; }
    }

    public class DoublyLinkedList<T>
    {
        public Node<T> Head { get; set; }

        public Node<T> Tail { get; set; }

        public void AddToFront(T value)
        {
            var node = new Node<T>()
            {
                Value = value
            };

            if (Head is null || Tail is null)
            {
                Head = node;
                Tail = node;
                return;
            }

            node.Next = Head;
            Head.Prev = node;
            Head = node;
        }

        public void AddToTail(T value)
        {
            var node = new Node<T>()
            {
                Value = value
            };

            if (Head is null || Tail is null)
            {
                Head = node;
                Tail = node;
                return;
            }

            Tail.Next = node;
            node.Prev = Tail;
            Tail = node;
        }

        public void RemoveFromTail()
        {
            if (Tail is null)
            {
                return;
            }

            if (Tail == Head)
            {
                Tail = null;
                Head = null;
                return;
            }

            Tail.Prev.Next = null;
            Tail = Tail.Prev;
        }

        public void RemoveFromHead()
        {
            if (Head is null)
            {
                return;
            }

            if (Head.Next is null)
            {
                Head = null;
                return;
            }

            Head.Next.Prev = null;
            Head = Head.Next;
        }

        public T[] PrintFromHead()
        {
            var list = new List<T>();
            if (Head is null)
            {
                return list.ToArray();
            }

            var next = Head;
            while (next is not null)
            {
                list.Add(next.Value);
                next = next.Next;
            }

            return list.ToArray();
        }

        public T[] PrintFromTail()
        {
            var list = new List<T>();
            if (Tail is null)
            {
                return list.ToArray();
            }

            var prev = Tail;
            while (prev is not null)
            {
                list.Add(prev.Value);
                prev = prev.Prev;
            }

            return list.ToArray();
        }
    }

    [TestClass]
    public class DoublyLinkedListTests
    {
        [TestMethod]
        public void AddToFront_ShouldAddToFront()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            list.AddToFront(3);
            list.AddToFront(2);
            list.AddToFront(1);

            // Act
            var fromHead = list.PrintFromHead();

            // Assert
            Assert.IsNotNull(list.Head);
            Assert.IsNotNull(list.Tail);

            CollectionAssert.AreEqual(new[] {1, 2, 3}, fromHead);
        }

        [TestMethod]
        public void AddToTail_ShouldAddToTail()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            list.AddToTail(1);
            list.AddToTail(2);
            list.AddToTail(3);

            // Act
            var fromHead = list.PrintFromHead();

            // Assert
            Assert.IsNotNull(list.Head);
            Assert.IsNotNull(list.Tail);

            CollectionAssert.AreEqual(new[] {1, 2, 3}, fromHead);
        }

        [TestMethod]
        [DataRow(new[] {1, 2, 3}, new[] {1, 2})]
        [DataRow(new[] {1}, new int[0])]
        public void RemoveFromTail_ShouldRemoveFromTail(int[] input, int[] expected)
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            foreach (var i in input)
            {
                list.AddToTail(i);
            }

            list.RemoveFromTail();

            // Act
            var fromHead = list.PrintFromHead();

            CollectionAssert.AreEqual(expected, fromHead);
        }

        [TestMethod]
        [DataRow(new[] {1, 2, 3}, new[] {2, 3})]
        [DataRow(new[] {1}, new int[0])]
        public void RemoveFromHead_ShouldRemoveFromHead(int[] input, int[] expected)
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            foreach (var i in input)
            {
                list.AddToTail(i);
            }

            list.RemoveFromHead();

            // Act
            var fromHead = list.PrintFromHead();

            CollectionAssert.AreEqual(expected, fromHead);
        }

        [TestMethod]
        [DataRow(new[] {1, 2, 3}, new[] {3, 2, 1})]
        [DataRow(new[] {1}, new[] {1})]
        public void PrintFromTail_ShouldPrintFromTail(int[] input, int[] expected)
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            foreach (var i in input)
            {
                list.AddToTail(i);
            }

            // Act
            var fromTail = list.PrintFromTail();

            CollectionAssert.AreEqual(expected, fromTail);
        }
    }
}