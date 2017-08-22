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

    ulong ChangeToBaseTen(List<uint> numberList, uint theBase)
    {
      ulong result = 0;
      int j = numberList.Count - 1;
      for (int i = 0; i < numberList.Count; i++)
      {
        result += numberList[i] * UIntPow(theBase, (uint) j);
        j--;
      }
      return result;
    }

    [TestMethod]
    public void RemoveLeadingZeroes26()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 1, 0, 1, 0}, TrimLeadigZeroes(new List<uint> {0, 0, 1, 1, 0, 1, 0}));
    }

    List<uint> TrimLeadigZeroes(List<uint> numberList)
    {
      while (numberList[0] == 0)
        numberList.RemoveAt(0);
      return numberList;
    }

    [TestMethod]
    public void NOT26()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 0, 1}, BinaryNOT(ChangeToBase(26, 2)));
    }

    List<uint> BinaryNOT(List<uint> numberList)
    {
      for (int i = 0; i < numberList.Count; i++)
        numberList[i] = (numberList[i] == 0) ? 1u : 0;
      return TrimLeadigZeroes(numberList);
    }

    [TestMethod]
    public void AND26With86()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 0, 0, 1, 0}, BinaryAND(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    }

    List<uint> BinaryAND(List<uint> firstList, List<uint> secondList)
    {
      firstList.Reverse();
      secondList.Reverse();
      List<uint> result = new List<uint>();
      int shortest = firstList.Count < secondList.Count ? firstList.Count : secondList.Count;
      for (int i = 0 ; i < shortest; i++)
      {
        if ((firstList[i] == 1u) && (secondList[i] == 1u))
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

    List<uint> BinaryOR(List<uint> firstList, List<uint> secondList)
    {
      firstList.Reverse();
      secondList.Reverse();
      List<uint> result = new List<uint>();
      int longest = firstList.Count > secondList.Count ? firstList.Count : secondList.Count;
      while (firstList.Count < longest)
        firstList.Add(0);
      while (secondList.Count < longest)
        secondList.Add(0);
      for (int i = 0; i < longest; i++)
      {
        if ((firstList[i] == 1u) || (secondList[i] == 1u))
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

    List<uint> BinaryNOR(List<uint> firstList, List<uint> secondList)
    {
      return TrimLeadigZeroes(BinaryNOT(BinaryOR(firstList, secondList)));
    }

    [TestMethod]
    public void XOR26With86()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 0, 0, 1, 1, 0, 0}, BinaryXOR(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    }

    List<uint> BinaryXOR(List<uint> firstList, List<uint> secondList)
    {
      firstList.Reverse();
      secondList.Reverse();
      List<uint> result = new List<uint>();
      int longest = firstList.Count > secondList.Count ? firstList.Count : secondList.Count;
      while (firstList.Count < longest)
        firstList.Add(0);
      while (secondList.Count < longest)
        secondList.Add(0);
      for (int i = 0; i < longest; i++)
      {
        if (firstList[i] != secondList[i])
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

    List<uint> BitshiftRight(List<uint> numberList, int bits)
    {
      List<uint> result = numberList;
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

    List<uint> BitshiftLeft(List<uint> numberList, int bits)
    {
      List<uint> result = numberList;
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

    [TestMethod]
    public void Is26LessThan26InB2()
    {
      Assert.AreEqual(false, LessThan(ChangeToBase(26, 2), ChangeToBase(26, 2)));
    }

    bool LessThan(List<uint> firstList, List<uint> secondList)
    {
      List<uint> firstListCopy = new List<uint>(firstList);
      List<uint> secondListCopy = new List<uint>(secondList);
      firstListCopy.Reverse();
      secondListCopy.Reverse();
      bool result = false;
      int longest = firstListCopy.Count > secondListCopy.Count ? firstListCopy.Count : secondListCopy.Count;
      while (firstListCopy.Count < longest)
        firstListCopy.Add(0);
      while (secondListCopy.Count < longest)
        secondListCopy.Add(0);
      for (int i = 0; i < longest; i++)
        if (firstListCopy[i] != secondListCopy[i])
          result = firstListCopy[i] < secondListCopy[i] ? true : false;
      return result;
    }

    [TestMethod]
    public void Add26With86InB2()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 1, 1, 0, 0, 0, 0}, AddLists(ChangeToBase(26, 2), ChangeToBase(86, 2), 2));
    }

    [TestMethod]
    public void Add86With86InB2()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 0, 1, 0, 1, 1, 0, 0 }, AddLists(ChangeToBase(86, 2), ChangeToBase(86, 2), 2));
    }

    [TestMethod]
    public void Add26With26InB2()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 1, 0, 1, 0, 0}, AddLists(ChangeToBase(26, 2), ChangeToBase(26, 2), 2));
    }

    List<uint> AddLists(List<uint> firstList, List<uint> secondList, uint theBase)
    {
      List<uint> firstListCopy = new List<uint>(firstList);
      List<uint> secondListCopy = new List<uint>(secondList);
      firstListCopy.Reverse();
      secondListCopy.Reverse();
      int longest = firstListCopy.Count > secondListCopy.Count ? firstListCopy.Count : secondListCopy.Count;
      while (firstListCopy.Count < longest)
        firstListCopy.Add(0);
      while (secondListCopy.Count < longest)
        secondListCopy.Add(0);
      List<uint> result = new List<uint>();
      uint overValue = 0;
      uint indexValue;
      for (int i = 0; i < longest; i++)
      {
        indexValue = firstListCopy[i] + secondListCopy[i] + overValue;
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
      CollectionAssert.AreEqual(new List<uint> {1, 1, 1, 1, 0, 0}, SubstractLists(ChangeToBase(26, 2), ChangeToBase(86, 2), 2));
    }

    // works only for positive result (second array must be greater)!!!
    List<uint> SubstractLists(List<uint> firstList, List<uint> secondList, uint theBase)
    {
      List<uint> firstListCopy = new List<uint>(firstList);
      List<uint> secondListCopy = new List<uint>(secondList);
      firstListCopy.Reverse();
      secondListCopy.Reverse();
      int longest = firstListCopy.Count > secondListCopy.Count ? firstListCopy.Count : secondListCopy.Count;
      while (firstListCopy.Count < longest)
        firstListCopy.Add(0);
      while (secondListCopy.Count < longest)
        secondListCopy.Add(0);
      List<uint> result = new List<uint>();
      uint overValue = 0;
      uint indexValue;
      for (int i = 0; i < longest; i++)
      {
        indexValue = theBase + secondListCopy[i] - firstListCopy[i] - overValue;
        result.Add(indexValue % theBase);
        overValue = (indexValue / theBase) == 0 ? 1u : 0;
      }
      result.Reverse();
      return TrimLeadigZeroes(result);
    }

    [TestMethod]
    public void ProductOf26And6InB2Easy()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 0, 0, 1, 1, 1, 0, 0}, MultiplyListsEasy(ChangeToBase(26, 2), ChangeToBase(6, 2), 2));
    }

    List<uint> MultiplyListsEasy(List<uint> firstList, List<uint> secondList, uint theBase)
    {
      ulong firstNumber = ChangeToBaseTen(firstList, theBase);
      ulong secondNumber = ChangeToBaseTen(secondList, theBase);
      ulong product = firstNumber * secondNumber;
      List<uint> result = ChangeToBase(product, theBase);
      return result;
    }

    [TestMethod]
    public void ProductOf26And6InB2Medium()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 0, 0, 1, 1, 1, 0, 0}, MultiplyListsMedium(ChangeToBase(26, 2), ChangeToBase(6, 2), 2));
    }

    [TestMethod]
    public void ProductOf26And2InB2Medium()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 1, 0, 1, 0, 0}, MultiplyListsMedium(ChangeToBase(26, 2), ChangeToBase(2, 2), 2));
    }

    List<uint> MultiplyListsMedium(List<uint> firstList, List<uint> secondList, uint theBase)
    {
      ulong secondNumber = ChangeToBaseTen(secondList, theBase);
      List<uint> result = new List<uint>(firstList);
      for (ulong i = 1; i < secondNumber; i++)
        result = new List<uint>(AddLists(result, firstList, theBase));
      return result;
    }

    [TestMethod]
    public void Divide86With26InB2Easy()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 1}, DivideListsEasy(ChangeToBase(86, 2), ChangeToBase(26, 2), 2));
    }

    List<uint> DivideListsEasy(List<uint> firstList, List<uint> secondList, uint theBase)
    {
      ulong firstNumber = ChangeToBaseTen(firstList, theBase);
      ulong secondNumber = ChangeToBaseTen(secondList, theBase);
      ulong quotient = firstNumber / secondNumber;
      List<uint> result = ChangeToBase(quotient, theBase);
      return result;
    }

    [TestMethod]
    public void Divide86With26InB2Medium()
    {
      CollectionAssert.AreEqual(new List<uint> {1, 1}, DivideListsMedium(ChangeToBase(86, 2), ChangeToBase(26, 2), 2));
    }

    List<uint> DivideListsMedium(List<uint> firstList, List<uint> secondList, uint theBase)
    {
      ulong i = 0;
      List<uint> firstListCopy = new List<uint>(firstList);
      List<uint> secondListCopy = new List<uint>(secondList);
      while (LessThan(secondListCopy, firstListCopy))
      {
        firstListCopy = SubstractLists(secondListCopy, firstListCopy, theBase);
        i++;
      }
      List<uint> result = ChangeToBase(i, theBase);
      return result;
    }

    [TestMethod]
    public void Is26EqualTo26InB2()
    {
      Assert.AreEqual(true, EqualTo(ChangeToBase(26, 2), ChangeToBase(26, 2)));
    }

    bool EqualTo(List<uint> firstList, List<uint> secondList)
    {
      bool firstTest = true;
      bool secondTest = true;
      bool result = false;
      firstTest = LessThan(firstList, secondList);
      secondTest = LessThan(secondList, firstList);
      if (!firstTest && !secondTest)
        result = true;
      return result;
    }
  }
}
