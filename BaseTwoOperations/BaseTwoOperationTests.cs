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
      CollectionAssert.AreEqual(new List<uint> {1, 1, 0, 1, 0}, ChangeToBase(26, 2));
    }

    List<uint> ChangeToBase(ulong number, uint theBase)
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
      return result;
    }

    [TestMethod]
    public void Convert26FromB2toB10()
    {
      Assert.AreEqual(26ul, ChangeToBaseTen(new List<uint> {1, 1, 0, 1, 0}, 2));
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

    ulong ChangeToBaseTen(List<uint> numberArray, uint theBase)
    {
      ulong result = 0;
      int j = numberArray.Count - 1;
      for (int i = 0; i < numberArray.Count; i++)
      {
        result += numberArray[i] * UIntPow(theBase, (uint) j);
        j--;
      }
      return result;
    }

    [TestMethod]
    public void RemoveLeadingZeroes26()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 1, 0, 1, 0}, TrimLeadigZeroes(new List<uint> {0, 0, 1, 1, 0, 1, 0}));
    }

    List<uint> TrimLeadigZeroes(List<uint> numberArray)
    {
      while (numberArray[0] == 0)
        numberArray.RemoveAt(0);
      return numberArray;
    }

    [TestMethod]
    public void NOT26()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 0, 1}, BinaryNOT(ChangeToBase(26, 2)));
    }

    List<uint> BinaryNOT(List<uint> numberArray)
    {
      for (int i = 0; i < numberArray.Count; i++)
        numberArray[i] = (numberArray[i] == 0) ? 1u : 0;
      return TrimLeadigZeroes(numberArray);
    }

    [TestMethod]
    public void AND26With86()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 0, 0, 1, 0}, BinaryAND(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    }

    List<uint> BinaryAND(List<uint> firstArray, List<uint> secondArray)
    {
      firstArray.Reverse();
      secondArray.Reverse();
      List<uint> result = new List<uint>();
      int shortest = firstArray.Count < secondArray.Count ? firstArray.Count : secondArray.Count;
      for (int i = 0 ; i < shortest; i++)
      {
        if ((firstArray[i] == 1u) && (secondArray[i] == 1u))
          result.Add(1u);
        else
          result.Add(0);
      }
      result.Reverse();
      return TrimLeadigZeroes(result);
    }

    [TestMethod]
    public void OR26With86()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 0, 1, 1, 1, 1, 0}, BinaryOR(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    }

    List<uint> BinaryOR(List<uint> firstArray, List<uint> secondArray)
    {
      firstArray.Reverse();
      secondArray.Reverse();
      List<uint> result = new List<uint>();
      int longest = firstArray.Count > secondArray.Count ? firstArray.Count : secondArray.Count;
      while (firstArray.Count < longest)
        firstArray.Add(0);
      while (secondArray.Count < longest)
        secondArray.Add(0);
      for (int i = 0; i < longest; i++)
      {
        if ((firstArray[i] == 1u) || (secondArray[i] == 1u))
          result.Add(1u);
        else
          result.Add(0);
      }
      result.Reverse();
      return TrimLeadigZeroes(result);
    }

    [TestMethod]
    public void NOR26With86()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 0, 0, 0, 0, 1}, BinaryNOR(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    }

    List<uint> BinaryNOR(List<uint> firstArray, List<uint> secondArray)
    {
      return TrimLeadigZeroes(BinaryNOT(BinaryOR(firstArray, secondArray)));
    }

    [TestMethod]
    public void XOR26With86()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 0, 0, 1, 1, 0, 0}, BinaryXOR(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    }

    List<uint> BinaryXOR(List<uint> firstArray, List<uint> secondArray)
    {
      firstArray.Reverse();
      secondArray.Reverse();
      List<uint> result = new List<uint>();
      int longest = firstArray.Count > secondArray.Count ? firstArray.Count : secondArray.Count;
      while (firstArray.Count < longest)
        firstArray.Add(0);
      while (secondArray.Count < longest)
        secondArray.Add(0);
      for (int i = 0; i < longest; i++)
      {
        if (firstArray[i] != secondArray[i])
          result.Add(1u);
        else
          result.Add(0);
      }
      result.Reverse();
      return TrimLeadigZeroes(result);
    }

    [TestMethod]
    public void Bitshift26Right2()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 1, 0}, BitshiftRight(ChangeToBase(26, 2), 2));
    }

    List<uint> BitshiftRight(List<uint> numberArray, int bits)
    {
      List<uint> result = numberArray;
      result.Reverse();
      for (int i = 0; i < bits; i++)
        result.RemoveAt(0);
      result.Reverse();
      return TrimLeadigZeroes(result);
    }

    [TestMethod]
    public void Bitshift26Left2()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 1, 0, 1, 0, 0, 0}, BitshiftLeft(ChangeToBase(26, 2), 2));
    }

    List<uint> BitshiftLeft(List<uint> numberArray, int bits)
    {
      List<uint> result = numberArray;
      for (int i = 0; i < bits; i++)
        result.Add(0);
      return TrimLeadigZeroes(result);
    }

    [TestMethod]
    public void Is26LessThan86InB2()
    {
      Assert.AreEqual(true, LessThan(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    }

    [TestMethod]
    public void Is27LessThan26InB2()
    {
      Assert.AreEqual(false, LessThan(ChangeToBase(27, 2), ChangeToBase(26, 2)));
    }

    bool LessThan(List<uint> firstArray, List<uint> secondArray)
    {
      firstArray.Reverse();
      secondArray.Reverse();
      bool result = false;
      int longest = firstArray.Count > secondArray.Count ? firstArray.Count : secondArray.Count;
      while (firstArray.Count < longest)
        firstArray.Add(0);
      while (secondArray.Count < longest)
        secondArray.Add(0);
      for (int i = 0; i < longest; i++)
        if (firstArray[i] != secondArray[i])
          result = firstArray[i] < secondArray[i] ? true : false;
      return result;
    }

    [TestMethod]
    public void Add26With86InB2()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 1, 1, 0, 0, 0, 0}, AddArrays(ChangeToBase(26, 2), ChangeToBase(86, 2), 2));
    }

    [TestMethod]
    public void Add86With86InB2()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 0, 1, 0, 1, 1, 0, 0 }, AddArrays(ChangeToBase(86, 2), ChangeToBase(86, 2), 2));
    }

    [TestMethod]
    public void Add26With26InB2()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 1, 0, 1, 0, 0}, AddArrays(ChangeToBase(26, 2), ChangeToBase(26, 2), 2));
    }

    List<uint> AddArrays(List<uint> firstArray, List<uint> secondArray, uint theBase)
    {
      List<uint> firstList = new List<uint>(firstArray);
      List<uint> secondList = new List<uint>(secondArray);
      firstList.Reverse();
      secondList.Reverse();
      int longest = firstList.Count > secondList.Count ? firstList.Count : secondList.Count;
      while (firstList.Count < longest)
        firstList.Add(0);
      while (secondList.Count < longest)
        secondList.Add(0);
      List<uint> result = new List<uint>();
      uint overValue = 0;
      uint indexValue;
      for (int i = 0; i < longest; i++)
      {
        indexValue = firstList[i] + secondList[i] + overValue;
        result.Add(indexValue % theBase);
        overValue = indexValue / theBase;
      }
      result.Add(overValue);
      result.Reverse();
      return TrimLeadigZeroes(result);
    }

    [TestMethod]
    public void Substract26From86InB2()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 1, 1, 1, 0, 0}, SubstractArrays(ChangeToBase(26, 2), ChangeToBase(86, 2), 2));
    }

    // works only for positive result (second array must be greater)!!!
    List<uint> SubstractArrays(List<uint> firstArray, List<uint> secondArray, uint theBase)
    {
      firstArray.Reverse();
      secondArray.Reverse();
      int longest = firstArray.Count > secondArray.Count ? firstArray.Count : secondArray.Count;
      while (firstArray.Count < longest)
        firstArray.Add(0);
      while (secondArray.Count < longest)
        secondArray.Add(0);
      List<uint> result = new List<uint>();
      uint overValue = 0;
      uint indexValue;
      for (int i = 0; i < longest; i++)
      {
        indexValue = theBase + secondArray[i] - firstArray[i] - overValue;
        result.Add(indexValue % theBase);
        overValue = (indexValue / theBase) == 0 ? 1u : 0;
      }
      result.Reverse();
      return TrimLeadigZeroes(result);
    }

    [TestMethod]
    public void ProductOf26And6InB2Easy()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 0, 0, 1, 1, 1, 0, 0}, MultiplyArraysEasy(ChangeToBase(26, 2), ChangeToBase(6, 2), 2));
    }

    [TestMethod]
    public void ProductOf26And6InB2Medium()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 0, 0, 1, 1, 1, 0, 0}, MultiplyArraysMedium(ChangeToBase(26, 2), ChangeToBase(6, 2), 2));
    }

    [TestMethod]
    public void ProductOf26And2InB2Medium()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 1, 0, 1, 0, 0}, MultiplyArraysMedium(ChangeToBase(26, 2), ChangeToBase(2, 2), 2));
    }

    List<uint> MultiplyArraysEasy(List<uint> firstArray, List<uint> secondArray, uint theBase)
    {
      ulong firstNumber = ChangeToBaseTen(firstArray, theBase);
      ulong secondNumber = ChangeToBaseTen(secondArray, theBase);
      ulong product = firstNumber * secondNumber;
      List<uint> result = ChangeToBase(product, theBase);
      return result;
    }

    List<uint> MultiplyArraysMedium(List<uint> firstArray, List<uint> secondArray, uint theBase)
    {
      ulong secondNumber = ChangeToBaseTen(secondArray, theBase);
      List<uint> result = new List<uint>(firstArray);
      for (ulong i = 1; i < secondNumber; i++)
        result = new List<uint>(AddArrays(result, firstArray, theBase));
      return result;
    }
  }
}
