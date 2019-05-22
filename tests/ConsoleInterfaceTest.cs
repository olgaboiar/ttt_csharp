using System;
using NUnit.Framework;
using ttt_csharp;
using System.IO;

namespace tests
{
    public class ConsoleInterfaceTest
    {
        private ConsoleInterface _userInterface;
        
        [SetUp]
        public void Setup()
        {
            _userInterface = new ConsoleInterface();
        }
        
        [Test]
        public void OutputsMessageToConsole()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);
            var message = "test";
            _userInterface.Output(message);
            var actual = sw.ToString().Replace(Environment.NewLine, "");
            
            Assert.AreEqual(message, actual);
        } 
    }
}