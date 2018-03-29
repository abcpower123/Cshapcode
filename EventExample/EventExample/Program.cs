using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample
{
    public class ActionEventArgs
    {
        public string Message { get; set; }

        public ActionEventArgs(string message)
        {
            Message = message;
        }
    }
    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public delegate void Action(object sender, ActionEventArgs args);
        public event Action SingEvent;
        public event Action CryEvent;
        public event Action SmileEvent;
        public event Action SpeakEvent;

        public void Sing(string ms)
        {
            if (SingEvent!=null)
            {
                this.SingEvent(this,new ActionEventArgs(ms));
            }
            else Console.WriteLine("SingEvent not subscribe");
        }
        public void Cry(string ms)
        {
            if (SingEvent != null)
            {
                this.SingEvent(this, new ActionEventArgs(ms));
            }
            else Console.WriteLine("CryEvent not subscribe");
        }
        public void Smile(string ms)
        {
            if (SingEvent != null)
            {
                this.SingEvent(this, new ActionEventArgs(ms));
            }
            else Console.WriteLine("SmileEvent not subscribe");
        }
        public void Speak(string ms)
        {
            if (SingEvent != null)
            {
                this.SingEvent(this, new ActionEventArgs(ms));
            }
            else Console.WriteLine("SpeakEvent not subscribe");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("Hong Hai");
            p.SingEvent += P_SingEvent;
            p.Sing("ASD");
            Console.ReadLine();
        }

        private static void P_SingEvent(object sender, ActionEventArgs args)
        {
            Person p = sender as Person;
            Console.WriteLine(p.Name+" singing: "+args.Message);
        }
    }
}
