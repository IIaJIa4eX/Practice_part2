using System;
using System.Collections.Generic;

namespace Timesheets.Models 
{
    public class Task
    {
        private long _id;
        private List<long> _employees;
        private DateTimeOffset _start;
        private DateTimeOffset _end;
        private decimal _priceperhour;
        private bool _isclosed;

        public long id
        {
            get => _id;
            set => _id = value;
        }
        public List<long> employees
        {
            get => _employees;
            set => _employees = value;
        }
        public DateTimeOffset start
        {
            get => _start;
            set => _start = value;
        }
        public DateTimeOffset end
        {
            get => _end;
            set => _end = value;
        }
        public decimal priceperhour
        {
            get => _priceperhour;
            set => _priceperhour = value;
        }
        public bool isclosed
        {
            get => _isclosed;
            set => _isclosed = value;
        }

        internal Task(long id, decimal priceperhour, ICurrentTime time)
        {
            _id = id;
            _start = time.UtcNow();
            _priceperhour = priceperhour;
            employees = new List<long>();
            _isclosed = false;
        }

        internal Task() { }

        public void Close(ICurrentTime time)
        {
            if (isclosed)
            {
                throw new AlreadyClosedException();
            }

            isclosed = true;
            end = time.UtcNow();
        }

        public decimal GetCost()
        {
            if (!isclosed)
            {
                throw new NeedToBeClosedException();
            }

            return (decimal)((_end - _start).TotalSeconds / 3600) * _priceperhour;
        }

        public void AddEmployee(long employeeId)
        {
            _employees.Add(employeeId);
        }

        public void RemoveEmployee(long employeeId)
        {
            _employees.Remove(employeeId);
        }
    }

    public class AlreadyClosedException : Exception { }
    public class NeedToBeClosedException : Exception { }

    public class TaskFactory
    {
        public Task Create(long id, decimal pricePerHour, ICurrentTime time) => new Task(id, pricePerHour, time);
    }
}
