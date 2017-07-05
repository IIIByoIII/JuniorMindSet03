using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

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

    [TestMethod]
    public void AnagramsForAABBCCC()
    {
      Assert.AreEqual(210d, AvailableAnagrams("aABbCCc"));
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
    
    // calculates the number each letter ocurs and returns the product of factorials of the ocurences
    double LettersFactorialProduct(string inputWord)
    {
      double products = 1d;
      int[] lettersFound = new int[26];
      for (int i = 0; i < inputWord.Length; i++)
      {
        int letter = (inputWord[i] - 'a');
        lettersFound[letter]++;
      }
      for (int i = 0; i < 26; i++)
        if (lettersFound[i] != 0)
          products *= Factorial(lettersFound[i]);
      return products;
    }

    double AvailableAnagrams(string inputWord)
    {
      inputWord = inputWord.ToLower();
      double numberOfAnagrams = Factorial(inputWord.Length) / LettersFactorialProduct(inputWord);
      return numberOfAnagrams;
    }
  }
}
