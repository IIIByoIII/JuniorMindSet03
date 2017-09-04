using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BaseTwoOperations
{
  [TestClass]
  public class BaseTwoOperationTests
  {
    [TestMethod]
    public void Convert26FromB10toB2() // {{{
    {
      CollectionAssert.AreEqual(new List<byte> {1, 1, 0, 1, 0}, ChangeToBase(26, 2));
    } // }}}

    List<byte> ChangeToBase(ulong number, byte theBase) // {{{
    {
      List<byte> result = new List<byte>();
      ulong quotient = number;
      byte remainder;
      while (quotient != 0)
      {
        remainder = (byte) (quotient % theBase);
        quotient /= theBase;
        result.Add(remainder);
      }
      result.Reverse();
      return result;
    } // }}}

    [TestMethod]
    public void Convert26FromB2toB10() // {{{
    {
      Assert.AreEqual(26ul, ChangeToBaseTen(new List<byte> {1, 1, 0, 1, 0}, 2));
    } // }}}

    ulong UIntPow(ulong nr, byte pow) // {{{
    {
      ulong result = 1;
      if (pow == 0)
        return 1;
      for (byte i = 0; i < pow; i++)
        result *= nr;
      return result;
    } // }}}

    ulong ChangeToBaseTen(List<byte> numberList, byte theBase) // {{{
    {
      ulong result = 0;
      int j = numberList.Count - 1;
      for (int i = 0; i < numberList.Count; i++)
      {
        result += numberList[i] * UIntPow(theBase, (byte) j);
        j--;
      }
      return result;
    } // }}}

    [TestMethod]
    public void RemoveLeadingZeroes26() // {{{
    {
      CollectionAssert.AreEqual(new List<byte> {1, 1, 0, 1, 0}, TrimLeadigZeroes(new List<byte> {0, 0, 1, 1, 0, 1, 0}));
    } // }}}

    List<byte> TrimLeadigZeroes(List<byte> numberList) // {{{
    {
      while (numberList[0] == 0)
        numberList.RemoveAt(0);
      return numberList;
    } // }}}

    [TestMethod]
    public void NOT26() // {{{
    {
      CollectionAssert.AreEqual(new List<byte> {1, 0, 1}, BinaryNOT(ChangeToBase(26, 2)));
    } // }}}

    List<byte> BinaryNOT(List<byte> numberList) // {{{
    {
      for (int i = 0; i < numberList.Count; i++)
        numberList[i] = (byte)((numberList[i] == 0) ? 1 : 0);
      return TrimLeadigZeroes(numberList);
    } // }}}

    [TestMethod]
    public void AND26With86() // {{{
    {
      CollectionAssert.AreEqual(new List<byte> {1, 0, 0, 1, 0}, BinaryAND(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    } // }}}

    List<byte> BinaryAND(List<byte> firstList, List<byte> secondList) // {{{
    {
      firstList.Reverse();
      secondList.Reverse();
      List<byte> result = new List<byte>();
      int shortest = firstList.Count < secondList.Count ? firstList.Count : secondList.Count;
      for (int i = 0 ; i < shortest; i++)
      {
        if ((firstList[i] == 1) && (secondList[i] == 1))
          result.Add(1);
        else
          result.Add(0);
      }
      result.Reverse();
      return TrimLeadigZeroes(result);
    } // }}}

    [TestMethod]
    public void OR26With86() // {{{
    {
      CollectionAssert.AreEqual(new List<byte> {1, 0, 1, 1, 1, 1, 0}, BinaryOR(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    } // }}}

    List<byte> BinaryOR(List<byte> firstList, List<byte> secondList) // {{{
    {
      firstList.Reverse();
      secondList.Reverse();
      List<byte> result = new List<byte>();
      int longest = firstList.Count > secondList.Count ? firstList.Count : secondList.Count;
      while (firstList.Count < longest)
        firstList.Add(0);
      while (secondList.Count < longest)
        secondList.Add(0);
      for (int i = 0; i < longest; i++)
      {
        if ((firstList[i] == 1) || (secondList[i] == 1))
          result.Add(1);
        else
          result.Add(0);
      }
      result.Reverse();
      return TrimLeadigZeroes(result);
    } // }}}

    [TestMethod]
    public void NOR26With86() // {{{
    {
      CollectionAssert.AreEqual(new List<byte> {1, 0, 0, 0, 0, 1}, BinaryNOR(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    } // }}}

    List<byte> BinaryNOR(List<byte> firstList, List<byte> secondList) // {{{
    {
      return TrimLeadigZeroes(BinaryNOT(BinaryOR(firstList, secondList)));
    } // }}}

    [TestMethod]
    public void XOR26With86() // {{{
    {
      CollectionAssert.AreEqual(new List<byte> {1, 0, 0, 1, 1, 0, 0}, BinaryXOR(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    } // }}}

    List<byte> BinaryCommonORXOR(List<byte> firstList, List<byte> secondList) // {{{
    {
      firstList.Reverse();
      secondList.Reverse();
      List<byte> result = new List<byte>();
      int longest = firstList.Count > secondList.Count ? firstList.Count : secondList.Count;
      while (firstList.Count < longest)
        firstList.Add(0);
      while (secondList.Count < longest)
        secondList.Add(0);
      for (int i = 0; i < longest; i++)
      {
        if (firstList[i] != secondList[i])
          result.Add(1);
        else
          result.Add(0);
      }
      result.Reverse();
      return TrimLeadigZeroes(result);
    } // }}}

    List<byte> BinaryXOR(List<byte> firstList, List<byte> secondList) // {{{
    {
      firstList.Reverse();
      secondList.Reverse();
      List<byte> result = new List<byte>();
      int longest = firstList.Count > secondList.Count ? firstList.Count : secondList.Count;
      while (firstList.Count < longest)
        firstList.Add(0);
      while (secondList.Count < longest)
        secondList.Add(0);
      for (int i = 0; i < longest; i++)
      {
        if (firstList[i] != secondList[i])
          result.Add(1);
        else
          result.Add(0);
      }
      result.Reverse();
      return TrimLeadigZeroes(result);
    } // }}}

    [TestMethod]
    public void Bitshift26Right2() // {{{
    {
      CollectionAssert.AreEqual(new List<byte> {1, 1, 0}, BitshiftRight(ChangeToBase(26, 2), 2));
    } // }}}

    List<byte> BitshiftRight(List<byte> numberList, int bits) // {{{
    {
      List<byte> result = numberList;
      result.Reverse();
      for (int i = 0; i < bits; i++)
        result.RemoveAt(0);
      result.Reverse();
      return TrimLeadigZeroes(result);
    } // }}}

    [TestMethod]
    public void Bitshift26Left2() // {{{
    {
      CollectionAssert.AreEqual(new List<byte> {1, 1, 0, 1, 0, 0, 0}, BitshiftLeft(ChangeToBase(26, 2), 2));
    } // }}}

    List<byte> BitshiftLeft(List<byte> numberList, int bits) // {{{
    {
      List<byte> result = numberList;
      for (int i = 0; i < bits; i++)
        result.Add(0);
      return TrimLeadigZeroes(result);
    } // }}}

    [TestMethod]
    public void Is26LessThan86InB2() // {{{
    {
      Assert.AreEqual(true, LessThan(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    } // }}}

    [TestMethod]
    public void Is27LessThan26InB2() // {{{
    {
      Assert.AreEqual(false, LessThan(ChangeToBase(27, 2), ChangeToBase(26, 2)));
    } // }}}

    [TestMethod]
    public void Is26LessThan26InB2() // {{{
    {
      Assert.AreEqual(false, LessThan(ChangeToBase(26, 2), ChangeToBase(26, 2)));
    } // }}}

    bool LessThan(List<byte> firstList, List<byte> secondList) // {{{
    {
      List<byte> firstListCopy = new List<byte>(firstList);
      List<byte> secondListCopy = new List<byte>(secondList);
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
    } // }}}

    [TestMethod]
    public void Add26With86InB2() // {{{
    {
      CollectionAssert.AreEqual(ChangeToBase(26 + 86, 2), AddLists(ChangeToBase(26, 2), ChangeToBase(86, 2), 2));
    } // }}}

    [TestMethod]
    public void Add86With86InB2() // {{{
    {
      CollectionAssert.AreEqual(ChangeToBase(86 + 86, 2), AddLists(ChangeToBase(86, 2), ChangeToBase(86, 2), 2));
    } // }}}

    [TestMethod]
    public void Add26With26InB2() // {{{
    {
      CollectionAssert.AreEqual(ChangeToBase(26 + 26, 2), AddLists(ChangeToBase(26, 2), ChangeToBase(26, 2), 2));
    } // }}}

    List<byte> AddLists(List<byte> firstList, List<byte> secondList, byte theBase) // {{{
    {
      List<byte> firstListCopy = new List<byte>(firstList);
      List<byte> secondListCopy = new List<byte>(secondList);
      firstListCopy.Reverse();
      secondListCopy.Reverse();
      int longest = firstListCopy.Count > secondListCopy.Count ? firstListCopy.Count : secondListCopy.Count;
      while (firstListCopy.Count < longest)
        firstListCopy.Add(0);
      while (secondListCopy.Count < longest)
        secondListCopy.Add(0);
      List<byte> result = new List<byte>();
      byte overValue = 0;
      int indexValue;
      for (int i = 0; i < longest; i++)
      {
        indexValue = firstListCopy[i] + secondListCopy[i] + overValue;
        result.Add((byte)(indexValue % theBase));
        overValue = (byte)(indexValue / theBase);
      }
      result.Add(overValue);
      result.Reverse();
      return TrimLeadigZeroes(result);
    } // }}}

    [TestMethod]
    public void Substract26From86InB2() // {{{
    {
      CollectionAssert.AreEqual(ChangeToBase(86 - 26, 2), SubstractLists(ChangeToBase(26, 2), ChangeToBase(86, 2), 2));
    } // }}}

    // works only for positive result (second array must be greater)!!!
    List<byte> SubstractLists(List<byte> firstList, List<byte> secondList, byte theBase) // {{{
    {
      List<byte> firstListCopy = new List<byte>(firstList);
      List<byte> secondListCopy = new List<byte>(secondList);
      firstListCopy.Reverse();
      secondListCopy.Reverse();
      int longest = firstListCopy.Count > secondListCopy.Count ? firstListCopy.Count : secondListCopy.Count;
      while (firstListCopy.Count < longest)
        firstListCopy.Add(0);
      while (secondListCopy.Count < longest)
        secondListCopy.Add(0);
      List<byte> result = new List<byte>();
      byte overValue = 0;
      int indexValue;
      for (int i = 0; i < longest; i++)
      {
        indexValue = theBase + secondListCopy[i] - firstListCopy[i] - overValue;
        result.Add((byte)(indexValue % theBase));
        overValue = (byte)((indexValue / theBase) == 0 ? 1 : 0);
      }
      result.Reverse();
      return TrimLeadigZeroes(result);
    } // }}}

    [TestMethod]
    public void ProductOf26And6InB2Easy() // {{{
    {
      CollectionAssert.AreEqual(ChangeToBase(26 * 6, 2), MultiplyListsEasy(ChangeToBase(26, 2), ChangeToBase(6, 2), 2));
    } // }}}

    List<byte> MultiplyListsEasy(List<byte> firstList, List<byte> secondList, byte theBase) // {{{
    {
      ulong firstNumber = ChangeToBaseTen(firstList, theBase);
      ulong secondNumber = ChangeToBaseTen(secondList, theBase);
      ulong product = firstNumber * secondNumber;
      List<byte> result = ChangeToBase(product, theBase);
      return result;
    } // }}}

    [TestMethod]
    public void ProductOf26And6InB2Medium() // {{{
    {
      CollectionAssert.AreEqual(ChangeToBase(26 * 6, 2), MultiplyListsMedium(ChangeToBase(26, 2), ChangeToBase(6, 2), 2));
    } // }}}

    [TestMethod]
    public void ProductOf26And2InB2Medium() // {{{
    {
      CollectionAssert.AreEqual(ChangeToBase(26 * 2, 2), MultiplyListsMedium(ChangeToBase(26, 2), ChangeToBase(2, 2), 2));
    } // }}}

    List<byte> MultiplyListsMedium(List<byte> firstList, List<byte> secondList, byte theBase) // {{{
    {
      ulong secondNumber = ChangeToBaseTen(secondList, theBase);
      List<byte> result = new List<byte>(firstList);
      for (ulong i = 1; i < secondNumber; i++)
        result = new List<byte>(AddLists(result, firstList, theBase));
      return result;
    } // }}}

    [TestMethod]
    public void Divide86With26InB2Easy() // {{{
    {
      CollectionAssert.AreEqual(ChangeToBase(86 / 26, 2), DivideListsEasy(ChangeToBase(86, 2), ChangeToBase(26, 2), 2));
    } // }}}

    List<byte> DivideListsEasy(List<byte> firstList, List<byte> secondList, byte theBase) // {{{
    {
      ulong firstNumber = ChangeToBaseTen(firstList, theBase);
      ulong secondNumber = ChangeToBaseTen(secondList, theBase);
      ulong quotient = firstNumber / secondNumber;
      List<byte> result = ChangeToBase(quotient, theBase);
      return result;
    } // }}}

    [TestMethod]
    public void Divide86With26InB2Medium() // {{{
    {
      CollectionAssert.AreEqual(ChangeToBase(86 / 26, 2), DivideListsMedium(ChangeToBase(86, 2), ChangeToBase(26, 2), 2));
    } // }}}

    List<byte> DivideListsMedium(List<byte> firstList, List<byte> secondList, byte theBase) // {{{
    {
      ulong i = 0;
      List<byte> firstListCopy = new List<byte>(firstList);
      List<byte> secondListCopy = new List<byte>(secondList);
      while (LessThan(secondListCopy, firstListCopy))
      {
        firstListCopy = SubstractLists(secondListCopy, firstListCopy, theBase);
        i++;
      }
      List<byte> result = ChangeToBase(i, theBase);
      return result;
    } // }}}

    [TestMethod]
    public void Is26EqualTo26InB2() // {{{
    {
      Assert.AreEqual(true, EqualTo(ChangeToBase(26, 2), ChangeToBase(26, 2)));
    } // }}}

    [TestMethod]
    public void Is27EqualTo26InB2() // {{{
    {
      Assert.AreEqual(false, EqualTo(ChangeToBase(27, 2), ChangeToBase(26, 2)));
    } // }}}

    bool EqualTo(List<byte> firstList, List<byte> secondList) // {{{
    {
      bool firstTest = true;
      bool secondTest = true;
      bool result = false;
      firstTest = LessThan(firstList, secondList);
      secondTest = LessThan(secondList, firstList);
      if (!firstTest && !secondTest)
        result = true;
      return result;
    } // }}}

    [TestMethod]
    public void Is26GreaterThan86InB2() // {{{
    {
      Assert.AreEqual(false, GreaterThan(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    } // }}}

    [TestMethod]
    public void Is86GreaterThan26InB2() // {{{
    {
      Assert.AreEqual(true, GreaterThan(ChangeToBase(86, 2), ChangeToBase(26, 2)));
    } // }}}

    bool GreaterThan(List<byte> firstList, List<byte> secondList) // {{{
    {
      bool firstTest = false;
      bool secondTest = true;
      bool result = false;
      firstTest = EqualTo(firstList, secondList);
      secondTest = LessThan(firstList, secondList);
      if (!firstTest && !secondTest)
        result = true;
      return result;
    } // }}}

    [TestMethod]
    public void Is26NotEqualTo26InB2() // {{{
    {
      Assert.AreEqual(false, NotEqualTo(ChangeToBase(26, 2), ChangeToBase(26, 2)));
    } // }}}

    [TestMethod]
    public void Is26NotEqualTo86InB2() // {{{
    {
      Assert.AreEqual(true, NotEqualTo(ChangeToBase(26, 2), ChangeToBase(86, 2)));
    } // }}}

    bool NotEqualTo(List<byte> firstList, List<byte> secondList) // {{{
    {
      return !EqualTo(firstList, secondList);
    } // }}}

    [TestMethod]
    public void GetAt10B2Index1() // {{{
    {
      Assert.AreEqual(1, GetAt(ChangeToBase(10, 2), 1));
    } // }}}

    [TestMethod]
    public void GetAt10B2Index2() // {{{
    {
      Assert.AreEqual(0, GetAt(ChangeToBase(10, 2), 2));
    } // }}}

    [TestMethod]
    public void GetAt10B2Index5() // {{{
    {
      Assert.AreEqual(0, GetAt(ChangeToBase(10, 2), 5));
    } // }}}

    byte GetAt(List<byte> theList, int i) // {{{
    {
      int theLength = theList.Count;
      byte result = theLength > i ? theList[theLength - i - 1] : (byte)0;
      return result;
    } // }}}
  }
}
