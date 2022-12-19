using Restaurant.Messages.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Messages
{
    public class InMemoryRepository<T> : IInMemoryRepository<T> where T : class
    {
        private readonly ConcurrentBag<T> _repo= new ConcurrentBag<T>();

        public void AddOrUpdate(T obj)
        {
            _repo.Add(obj);
        }

        public IEnumerable<T> Get()
        {
            return _repo;
        }

        
    }
}
