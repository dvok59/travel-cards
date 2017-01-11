namespace TravelCards
{
    /// <summary>
    /// Элемент связанного списка
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Следующий элемент
        /// </summary>
        public Node<T> Next;

        /// <summary>
        /// Содержимое элемента
        /// </summary>
        public T Value;
    }
}