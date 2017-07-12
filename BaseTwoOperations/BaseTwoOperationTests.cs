using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BaseTwoOperations
{
  [TestClass]
  public class BaseTwoOperationTests
  {
    [TestMethod]
    public void Convert26FromB10toB2()
    {
      CollectionAssert.AreEqual(new int[8] {0, 0, 0, 1, 1, 0, 1, 0}, ChangeToBase(26, 2));
    }

    int[] ChangeToBase(int number, int theBase)
    {
      int[] result = new int[8];
      int quotient = number;
      int remainder;
      int i = 7;
      while (quotient != 0)
      {
        remainder = quotient % theBase;
        quotient /= theBase;
        result[i] = remainder;
        i--;
      }
      return result;
    }
  }
}
