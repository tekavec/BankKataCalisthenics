namespace BankKataCalisthenics.Console
{
    public class BankConsole : IBankConsole
    {
        public void WriteLine(string value)
        {
            System.Console.WriteLine(value);
        }
    }
}