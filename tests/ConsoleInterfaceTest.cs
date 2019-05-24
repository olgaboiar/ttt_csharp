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
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var message = "test";
            _userInterface.Output(message);
            var actual = stringWriter.ToString().Replace(Environment.NewLine, "");
            
            Assert.AreEqual(message, actual);
        }
        
        [Test]
        public void ReadsUserInput()
        {
            var inputString = "1";
            var stringReader = new StringReader(inputString);
            Console.SetIn(stringReader);
            var actual = _userInterface.ReadInput();

            Assert.AreEqual(inputString, actual);
        } 
    }
}