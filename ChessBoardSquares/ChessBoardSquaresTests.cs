using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessBoardSquares
{
  [TestClass]
  public class ChessBoardSquaresTests
  {
    [TestMethod]
    public void SquaresForSizeOne()
    {
      Assert.AreEqual(1, TotalNumberOfSquares(1));
    }

    int TotalNumberOfSquares (int sizeOfBoard)
    {
      int totalSquares = sizeOfBoard * sizeOfBoard;
      return totalSquares;
    }
  }
}
