namespace Restaurant.Messages.Interfaces
{
    public interface IInMemoryRepository<T>
    {

        public void AddOrUpdate(T obj);

        public IEnumerable<T> Get();

    }
}
