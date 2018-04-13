namespace ChickenDinnerNumber1.Database
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
