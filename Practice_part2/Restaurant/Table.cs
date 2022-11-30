using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    //for review
    public enum State
    {
        Free = 0,
        Booked = 1
    }

    public class Table
    {
        
        public State state { get; private set; }

        public int SeatsCount { get; }
        public int Id { get; }

        public Table(int id)
        {
            Id = id;
            state = State.Free;
            Random rnd = new Random();
            SeatsCount = rnd.Next(2, 5);
        }

        public bool SetState(State instate)
        {
            if(instate == state)
            {
                return false;
            }

            state= instate;

            return true;
        }

    }
}
