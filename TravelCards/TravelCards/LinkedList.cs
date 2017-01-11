using System.Collections.Generic;

namespace TravelCards
{
    /// <summary>
    /// Связанный список
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T>
    {
        #region Props

        public Node<T> Head { get; private set; }
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
        /// Добавить элемент в начало
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
        /// Добавить элемент в конец
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
        /// Конверитровать в список (с содержимым элементов)
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
        /// Связать два списка
        /// </summary>
        /// <param name="otherList">Привязываемый список</param>
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