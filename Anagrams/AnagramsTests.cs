using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagrams
{
  [TestClass]
  public class AnagramsTests
  {
    [TestMethod]
    public void LettersProductABB()
    {
      Assert.AreEqual(2d, LettersRepeatProduct("ABB"));
    }

    [TestMethod]
    public void AnagramsForThreeUnique()
    {
      Assert.AreEqual(6d, AvailableAnagrams("ABC"));
    }

    [TestMethod]
    public void AnagramsForThreeCombined()
    {
      Assert.AreEqual(3d, AvailableAnagrams("ABB"));
    }

    [TestMethod]
    public void AnagramsForThreeSame()
    {
      Assert.AreEqual(1d, AvailableAnagrams("BBB"));
    }

    [TestMethod]
    public void AnagramsForABCDEF()
    {
      Assert.AreEqual(720d, AvailableAnagrams("ABCDEF"));
    }

    [TestMethod]
    public void AnagramsForAAABB()
    {
      Assert.AreEqual(10d, AvailableAnagrams("AAABB"));
    }

    double Factorial (double number)
    {
      double factorialForNumber = number;
      for (double i = number; i > 2; i--)
      {
        factorialForNumber *= i-1;
      }
      if (number < 2)
        return 1d;
      else
        return factorialForNumber;
    }
    
    // calculates the number each letter ocurs and returns the product of the ocurences
    double LettersRepeatProduct(string inputWord)
    {
      double products = 1d;
      while (inputWord.Length > 0)
      {
        char currentLetter = inputWord[0];
        int startIndex = 0;
        int hitCount = 0;
        while (true)
        {
          startIndex = inputWord.IndexOf(currentLetter, startIndex);
          if (startIndex < 0)
            break;
          hitCount++;
          inputWord = inputWord.Remove(startIndex, 1);
        }
        products *= Factorial(hitCount);
      }
      return products;
    }

    double AvailableAnagrams(string inputWord)
    {
      double numberOfAnagrams = Factorial(inputWord.Length) / LettersRepeatProduct(inputWord);
      return numberOfAnagrams;
    }
  }
}
