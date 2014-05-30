using System;
using Castle.Core;
using LoggingAopCastle.Aspects;
using LoggingAopCastle.Workers.Interfaces;

namespace LoggingAopCastle.Workers
{
    [Interceptor(typeof(MyInterceptor))]
    public class DoStuff : IDoStuff
    {
        public void DoSomething()
        {
            Console.WriteLine("Formatted");  
        }

        public void DoMoreStuff(string stuffToDo)
        {
            Console.WriteLine("Doing more stuff");
        }

        public void BlowUp(int numberOfThingsToBlow)
        {
            Console.WriteLine("Couldnt blow up {0} things",numberOfThingsToBlow);
            throw new InvalidCastException("Error");
        }
         
        public int GetMoney(int amountOfMoney)
        {
            int money = amountOfMoney*10;
            Console.WriteLine("You have just recieved " + money);
            return money;
        }

        public void DoLots(string stuffToDo, string yes)
        {
            DoMoreStuff(stuffToDo);
            DoMoreStuff(yes);
        }
    }
}
