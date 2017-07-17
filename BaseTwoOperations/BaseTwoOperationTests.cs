﻿using System;
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

    [TestMethod]
    public void XOR26With86()
    {
      CollectionAssert.AreEqual(new int[] {0, 1, 0, 0, 1, 1, 0, 0}, BinaryXOR(new int[] {0, 0, 0, 1, 1, 0, 1, 0}, new int[] {0, 1, 0, 1, 0, 1, 1, 0}));
    }

    int[] BinaryXOR(int[] firstArray, int[] secondArray)
    {
      int[] result = new int[8];
      for (int i = 0; i < 8; i++)
        if (firstArray[i] != secondArray[i])
          result[i] = 1;
      return result;
    }

    [TestMethod]
    public void Bitshift26Right2()
    {
      CollectionAssert.AreEqual(new int[] {0, 0, 0, 0, 0, 1, 1, 0}, BitshiftRight(new int[] {0, 0, 0, 1, 1, 0, 1, 0}, 2));
    }

    int[] BitshiftRight(int[] numberArray, int bits)
    {
      int[] result = new int[8];
      for (int i = 0; i < 8 - bits; i++)
        if (numberArray[i] == 1)
          result[i + bits] = 1;
      return result;
    }

    [TestMethod]
    public void Bitshift26Left2()
    {
      CollectionAssert.AreEqual(new int[] {0, 1, 1, 0, 1, 0, 0, 0}, BitshiftLeft(new int[] {0, 0, 0, 1, 1, 0, 1, 0}, 2));
    }

    int[] BitshiftLeft(int[] numberArray, int bits)
    {
      int[] result = new int[8];
      for (int i = bits; i < 8; i++)
        if (numberArray[i] == 1)
          result[i - bits] = 1;
      return result;
    }

    [TestMethod]
    public void Is26LessThan86InB2()
    {
      Assert.AreEqual(true, LessThan(new int[] {0, 0, 0, 1, 1, 0, 1, 0}, new int[] {0, 1, 0, 1, 0, 1, 1, 0}));
    }

    [TestMethod]
    public void Is27LessThan26InB2()
    {
      Assert.AreEqual(false, LessThan(new int[] {0, 0, 0, 1, 1, 0, 1, 1}, new int[] {0, 0, 0, 1, 1, 0, 1, 0}));
    }

    bool LessThan(int[] firstArray, int[] secondArray)
    {
      bool result = false;
      for (int i = 7; i >= 0; i--)
        if (firstArray[i] != secondArray[i])
          result = firstArray[i] < secondArray[i] ? true : false;
      return result;
    }

    [TestMethod]
    public void Add26With86InB2()
    {
      CollectionAssert.AreEqual(new int[] {0, 1, 1, 1, 0, 0, 0, 0}, Add(new int[] {0, 0, 0, 1, 1, 0, 1, 0}, new int[] {0, 1, 0, 1, 0, 1, 1, 0}, 2));
    }

    int[] Add(int[] firstArray, int[] secondArray, int theBase)
    {
      int[] result = new int[8];
      int overValue = 0;
      int indexValue;
      int finalValue;
      for (int i = 7; i >= 0 ; i--)
      {
        indexValue = firstArray[i] + secondArray[i] + overValue;
        if (indexValue >= theBase)
        {
          finalValue = indexValue - theBase;
          overValue = 1;
        }
        else
        {
          finalValue = indexValue;
          overValue = 0;
        }
        result[i] = finalValue;
      }
      return result;
    }

    [TestMethod]
    public void Substract26From86InB2()
    {
      CollectionAssert.AreEqual(new int[] {0, 0, 1, 1, 1, 1, 0, 0}, Substract(new int[] {0, 0, 0, 1, 1, 0, 1, 0}, new int[] {0, 1, 0, 1, 0, 1, 1, 0}, 2));
    }

    int[] Substract(int[] firstArray, int[] secondArray, int theBase)
    {
      int[] result = new int[8];
      int overValue = 0;
      int indexValue;
      int finalValue;
      for (int i = 7; i >= 0 ; i--)
      {
        indexValue = secondArray[i] - firstArray[i] - overValue;
        if (indexValue < 0)
        {
          finalValue = theBase + indexValue;
          overValue = 1;
        }
        else
        {
          finalValue = indexValue;
          overValue = 0;
        }
        result[i] = finalValue;
      }
      return result;
    }

    [TestMethod]
    public void ProductOf26And6InB2()
    {
      CollectionAssert.AreEqual(new int[] {1, 0, 0, 1, 1, 1, 0, 0}, Product(new int[] {0, 0, 0, 1, 1, 0, 1, 0}, new int[] {0, 0, 0, 0, 0, 1, 1, 0}, 2));
    }

    int[] Product(int[] firstArray, int[] secondArray, int theBase)
    {
      int[] result = new int[8];
      int[] previousProduct = new int[8];
      int overValue = 0;
      int indexValue;
      int finalValue;
      for (int i = 7; i >= 0 ; i--)
      {
        Array.Clear(previousProduct, 0, 8);
        for (int j = 7; j >= 0 ; j--)
        {
          indexValue = firstArray[i] * secondArray[j] + overValue;
          if (indexValue >= theBase)
          {
            finalValue = indexValue % theBase;
            overValue = indexValue / theBase;
          }
          else
          {
            finalValue = indexValue;
            overValue = 0;
          }
          if ((j - (7 - i)) < 0)
            break;
          previousProduct[j - (7 - i)] = finalValue;
        }
        result = Add(result, previousProduct, theBase);
      }
      return result;
    }
  }
}
