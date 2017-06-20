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

    [TestMethod]
    public void SquaresForSizeFour()
    {
      Assert.AreEqual(30, TotalNumberOfSquares(4));
    }

    [TestMethod]
    public void SquaresForSizeFive()
    {
      Assert.AreEqual(55, TotalNumberOfSquares(5));
    }

    [TestMethod]
    public void SquaresForSizeSix()
    {
      Assert.AreEqual(91, TotalNumberOfSquares(6));
    }

    [TestMethod]
    public void SquaresForSizeSeven()
    {
      Assert.AreEqual(140, TotalNumberOfSquares(7));
    }

    [TestMethod]
    public void SquaresForSizeEight()
    {
      Assert.AreEqual(204, TotalNumberOfSquares(8));
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
