using System;
using NUnit.Framework;
using ttt_csharp;

namespace tests
{
    [TestFixture]
    public class BoardTest
    {
        [Test]
        public void Creation()
        {
            var board = new Board();
            Assert.AreEqual(9, board.Spots.Count);
        }
    }
}
