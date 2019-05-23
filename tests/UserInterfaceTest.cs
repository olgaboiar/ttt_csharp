using System;
using NUnit.Framework;
using ttt_csharp;

namespace tests
{
    public class UserInterfaceTest
    {
        private UserInterface _ui;
        private ConsoleMock _consoleMock;
        
        [SetUp]
        public void Setup()
        {
            _consoleMock = new ConsoleMock();
            _ui = new UserInterface(_consoleMock);
        }
        
        [Test]
        public void GreetIsCalledWithUiOutput()
        {
            _ui.Greet();
            Assert.AreEqual(1, _consoleMock.numTimesOutputCalled);

        } 
        
        [Test]
        public void PrintBoardIsCalledWithUiOutput()
        {
            var board = new Board();
            _ui.PrintBoard(board);
            Assert.AreEqual(1, _consoleMock.numTimesOutputCalled);

        }

        [Test]
        public void ReadInputIsCalledWithUiReadInput()
        {
            _ui.ReadInput();
            Assert.AreEqual(1, _consoleMock.numTimesReadInputCalled);
        }
        
        [Test]
        public void ReadInputReturnsInteger()
        {
            var actual = _ui.ReadInput();
            Assert.IsInstanceOf(typeof(int), actual);
        }
        
        private class ConsoleMock : IUserInterface 
        {
            public int numTimesOutputCalled = 0;
            public int numTimesReadInputCalled = 0;

            public void Output(string message)
            {
                numTimesOutputCalled++;
            }

            public String ReadInput()
            {
                numTimesReadInputCalled++;
                return "0";
            }
        }
    }
}