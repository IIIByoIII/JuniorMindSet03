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

    [TestMethod]
    public void Convert26FromB2toB10()
    {
      Assert.AreEqual(26, ChangeToBaseTen(new int[] {0, 0, 0, 1, 1, 0, 1, 0}, 2));
    }

    int IntPow(int nr, int pow)
    {
      int result = 1;
      if (pow == 0)
        return 1;
      for (int i = 0; i < pow; i++)
        result *= nr;
      return result;
    }

    int ChangeToBaseTen(int[] numberArray, int theBase)
    {
      int result = 0;
      int j = numberArray.Length - 1;
      for (int i = 0; i < numberArray.Length; i++)
      {
        result += numberArray[i] * IntPow(theBase, j);
        j--;
      }
      return result;
    }

    [TestMethod]
    public void NOT26()
    {
      CollectionAssert.AreEqual(new int[] {1, 1, 1, 0, 0, 1, 0, 1}, BinaryNOT(new int[] {0, 0, 0, 1, 1, 0, 1, 0}));
    }

    int[] BinaryNOT(int[] numberArray)
    {
      for (int i = 0; i < 8; i++)
        numberArray[i] = (numberArray[i] == 0) ? 1 : 0;
      return numberArray;
    }

    [TestMethod]
    public void AND26With86()
    {
      CollectionAssert.AreEqual(new int[] {0, 0, 0, 1, 0, 0, 1, 0}, BinaryAND(new int[] {0, 0, 0, 1, 1, 0, 1, 0}, new int[] {0, 1, 0, 1, 0, 1, 1, 0}));
    }

    int[] BinaryAND(int[] firstArray, int[] secondArray)
    {
      int[] result = new int[8];
      for (int i = 0; i < 8; i++)
        if ((firstArray[i] == 1) && (secondArray[i] == 1))
          result[i] = 1;
      return result;
    }

    [TestMethod]
    public void OR26With86()
    {
      CollectionAssert.AreEqual(new int[] {0, 1, 0, 1, 1, 1, 1, 0}, BinaryOR(new int[] {0, 0, 0, 1, 1, 0, 1, 0}, new int[] {0, 1, 0, 1, 0, 1, 1, 0}));
    }

    int[] BinaryOR(int[] firstArray, int[] secondArray)
    {
      int[] result = new int[8];
      for (int i = 0; i < 8; i++)
        if ((firstArray[i] == 1) || (secondArray[i] == 1))
          result[i] = 1;
      return result;
    }

    [TestMethod]
    public void NOR26With86()
    {
      CollectionAssert.AreEqual(new int[] {1, 0, 1, 0, 0, 0, 0, 1}, BinaryNOR(new int[] {0, 0, 0, 1, 1, 0, 1, 0}, new int[] {0, 1, 0, 1, 0, 1, 1, 0}));
    }

    int[] BinaryNOR(int[] firstArray, int[] secondArray)
    {
      return BinaryNOT(BinaryOR(firstArray, secondArray));
    }
  }
}
