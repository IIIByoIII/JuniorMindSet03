using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagrams
{
  [TestClass]
  public class AnagramsTests
  {
    [TestMethod]
    public void AnagramsForThreeUnique()
    {
      Assert.AreEqual(6d, AvailableAnagrams("ABC"));
    }

    double Factorial (double number)
    {
      double factorialForNumber = number;
      for (double i = number; i > 2; i--)
      {
        factorialForNumber *= i-1;
      }
      return factorialForNumber;
    }

    double AvailableAnagrams(string inputWord)
    {
      double inputWordLength = inputWord.Length;
      return Factorial(inputWordLength);
    }
  }
}
