using System.Collections.Generic;

namespace TravelCards
{
    /// <summary>
    /// Represents a linked collection of nodes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T>
    {
        #region Props

        /// <summary>
        /// First node of collection.
        /// </summary>
        public Node<T> Head { get; private set; }

        /// <summary>
        /// Last node of collection.
        /// </summary>
        public Node<T> Tail { get; private set; }

        #endregion

        #region Ctor

        public LinkedList(Node<T> node)
        {
            Head = Tail = node;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Append node at the beginning of the collection.
        /// </summary>
        /// <param name="node"></param>
        public void AddFirst(Node<T> node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            node.Next = Head;
            Head = node;
        }

        /// <summary>
        /// Append node at the end of the collection.
        /// </summary>
        /// <param name="node"></param>
        public void AddLast(Node<T> node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            Tail.Next = node;
            Tail = node;
        }

        /// <summary>
        /// Creates a List of values.
        /// </summary>
        /// <returns></returns>
        public List<T> ToList()
        {
            var result = new List<T>();
            if (Head == null) return result;

            var current = Head;
            while (current != null)
            {
                result.Add(current.Value);
                current = current.Next;
            }
            return result;
        }

        /// <summary>
        /// Concatenates two linked lists.
        /// </summary>
        /// <param name="otherList">List to be appended.</param>
        public void Concat(LinkedList<T> otherList)
        {
            if (Head == null)
            {
                Head = otherList.Head;
                return;
            }

            Tail.Next = otherList.Head;
            Tail = otherList.Tail;
        }

        #endregion
    }
}