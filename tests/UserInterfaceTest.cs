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
            Assert.AreEqual(1, _consoleMock.numTimesCalled);

        } 
        
        [Test]
        public void PrintBoardIsCalledWithUiOutput()
        {
            var board = new Board();
            _ui.PrintBoard(board);
            Assert.AreEqual(1, _consoleMock.numTimesCalled);

        } 
        
        private class ConsoleMock : IUserInterface 
        {
            public int numTimesCalled = 0;

            public void Output(string message)
            {
                numTimesCalled++;
            }
        }
    }
}