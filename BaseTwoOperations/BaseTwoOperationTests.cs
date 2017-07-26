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
      CollectionAssert.AreEqual(new uint[] {1, 1, 0, 1, 0}, ChangeToBase(26, 2));
    }

    uint[] ChangeToBase(ulong number, uint theBase)
    {
      List<uint> result = new List<uint>();
      ulong quotient = number;
      uint remainder;
      while (quotient != 0)
      {
        remainder = (uint) (quotient % theBase);
        quotient /= theBase;
        result.Add(remainder);
      }
      result.Reverse();
      return result.ToArray();
    }

    [TestMethod]
    public void Convert26FromB2toB10()
    {
      Assert.AreEqual(26ul, ChangeToBaseTen(new uint[] {1, 1, 0, 1, 0}, 2));
    }

    uint UIntPow(uint nr, uint pow)
    {
      uint result = 1;
      if (pow == 0)
        return 1;
      for (uint i = 0; i < pow; i++)
        result *= nr;
      return result;
    }

    ulong ChangeToBaseTen(uint[] numberArray, uint theBase)
    {
      ulong result = 0;
      uint j = (uint) numberArray.Length - 1;
      for (uint i = 0; i < (uint) numberArray.Length; i++)
      {
        result += numberArray[i] * UIntPow(theBase, j);
        j--;
      }
      return result;
    }

    [TestMethod]
    public void NOT26()
    {
      CollectionAssert.AreEqual(new uint[] {0, 0, 1, 0, 1}, BinaryNOT(ChangeToBase(26, 2)));
    }

    uint[] BinaryNOT(uint[] numberArray)
    {
      for (uint i = 0; i < (uint) numberArray.Length; i++)
        numberArray[i] = (numberArray[i] == 0) ? 1u : 0;
      return numberArray;
    }

    [TestMethod]
    public void AND26With86()
    {
      CollectionAssert.AreEqual(new uint[] {0, 0, 1, 0, 0, 1, 0}, BinaryAND(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    }

    [TestMethod]
    public void LongestOf26And86()
    {
      Assert.AreEqual(7, LongestArrayLength(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    }

    [TestMethod]
    public void Paded26()
    {
      CollectionAssert.AreEqual(new uint[] {0, 0, 0, 1, 1, 0, 1, 0}, PadOrTrimArrayLeft(ChangeToBase(26, 2), 8));
    }

    int LongestArrayLength(uint[] firstArray, uint[] secondArray)
    {
      int result;
      result = (firstArray.Length > secondArray.Length) ? firstArray.Length : secondArray.Length;
      return result;
    }

    uint[] PadOrTrimArrayLeft(uint[] theArray, int theLength)
    {
      uint[] result = new uint[theLength];
      int j = theArray.Length - 1;
      for (int i = theLength - 1; i >= 0; i--)
      {
        if (j < 0)
          result[i] = 0;
        else
          result[i] = theArray[j];
        j--;
      }
      return result;
    }

    uint[] BinaryAND(uint[] firstArray, uint[] secondArray)
    {
      int longest = LongestArrayLength(firstArray, secondArray);
      uint[] firstPadedArray = new uint[longest]; 
      uint[] secondPadedArray = new uint[longest];
      firstPadedArray = PadOrTrimArrayLeft(firstArray, longest);
      secondPadedArray = PadOrTrimArrayLeft(secondArray, longest);
      uint[] result = new uint[longest];
      for (int i = 0; i < longest; i++)
        if ((firstPadedArray[i] == 1u) && (secondPadedArray[i] == 1u))
          result[i] = 1u;
      return result;
    }

    [TestMethod]
    public void OR26With86()
    {
      CollectionAssert.AreEqual(new uint[] {1, 0, 1, 1, 1, 1, 0}, BinaryOR(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    }

    uint[] BinaryOR(uint[] firstArray, uint[] secondArray)
    {
      int longest = LongestArrayLength(firstArray, secondArray);
      uint[] firstPadedArray = new uint[longest]; 
      uint[] secondPadedArray = new uint[longest];
      firstPadedArray = PadOrTrimArrayLeft(firstArray, longest);
      secondPadedArray = PadOrTrimArrayLeft(secondArray, longest);
      uint[] result = new uint[longest];
      for (int i = 0; i < longest; i++)
        if ((firstPadedArray[i] == 1) || (secondPadedArray[i] == 1))
          result[i] = 1u;
      return result;
    }

    [TestMethod]
    public void NOR26With86()
    {
      CollectionAssert.AreEqual(new uint[] {0, 1, 0, 0, 0, 0, 1}, BinaryNOR(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    }

    uint[] BinaryNOR(uint[] firstArray, uint[] secondArray)
    {
      return BinaryNOT(BinaryOR(firstArray, secondArray));
    }

    [TestMethod]
    public void XOR26With86()
    {
      CollectionAssert.AreEqual(new uint[] {1, 0, 0, 1, 1, 0, 0}, BinaryXOR(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    }

    uint[] BinaryXOR(uint[] firstArray, uint[] secondArray)
    {
      int longest = LongestArrayLength(firstArray, secondArray);
      uint[] firstPadedArray = new uint[longest]; 
      uint[] secondPadedArray = new uint[longest];
      firstPadedArray = PadOrTrimArrayLeft(firstArray, longest);
      secondPadedArray = PadOrTrimArrayLeft(secondArray, longest);
      uint[] result = new uint[longest];
      for (int i = 0; i < longest; i++)
        if (firstPadedArray[i] != secondPadedArray[i])
          result[i] = 1u;
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
