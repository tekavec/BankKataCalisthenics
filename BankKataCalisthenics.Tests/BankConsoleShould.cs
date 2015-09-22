using System;
using System.IO;
using BankKataCalisthenics.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankKataCalisthenics.Tests
{
    [TestClass]
    public class BankConsoleShould
    {

        [TestMethod]
        public void WriteALineToSystemConsole()
        {
            using (var stringWriter = new StringWriter())
            {
                System.Console.SetOut(stringWriter);

                IBankConsole console = new BankConsole();
                console.WriteLine("test");

                string expected =
                    string.Format("test{0}", Environment.NewLine);
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }
         
    }
}