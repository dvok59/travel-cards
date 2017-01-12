namespace TravelCards
{
    /// <summary>
    /// Represents a single entity within a linked list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Reference to another node.
        /// </summary>
        public Node<T> Next;

        /// <summary>
        /// Content.
        /// </summary>
        public T Value;
    }
}