namespace ChickenDinnerNumber1.Database
{
    public class BaseEntity<T> : IEntity<T>
    {
        public T Id { get; set; }
    }

    public class BaseEntity : IEntity<int>
    {
        public int Id { get; set; }
    }
}
