using System.Collections.Generic;
namespace Observer_CS_2
{
    abstract class Subject
    {
        List<Observer> observers = new List<Observer>();
        public void Attach(Observer obs) => observers.Add(obs);
        public void Deatch(Observer obs) => observers.Remove(obs);
        public void Notify() 
        {
            foreach(var observer in observers)
                observer.Update(this);
        }
    }
}
