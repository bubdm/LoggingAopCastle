namespace LoggingAopCastle.Workers.Interfaces
{
    public interface IDoStuff
    {
        void DoSomething();

        void DoMoreStuff(string stuffToDo);

        void BlowUp(int numberOfThingsToBlow);

        int GetMoney(int amountOfMoney);

        void DoLots(string stuffToDo, string yes);
    }
}
