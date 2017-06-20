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

    [TestMethod]
    public void SquaresForSizeTwo()
    {
      Assert.AreEqual(5, TotalNumberOfSquares(2));
    }

    [TestMethod]
    public void SquaresForSizeThree()
    {
      Assert.AreEqual(14, TotalNumberOfSquares(3));
    }

    int TotalNumberOfSquares (int sizeOfBoard)
    {
      int totalSquares = 0;
      for (int i = sizeOfBoard; i > 0; i--)
      {
        totalSquares += i * i;
      }
      return totalSquares;
    }
  }
}
