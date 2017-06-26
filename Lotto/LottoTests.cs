using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lotto
{
  [TestClass]
  public class LottoTests
  {
    [TestMethod]
    public void FactorialFour()
    {
      Assert.AreEqual(24, Factorial(4));
    }

    [TestMethod]
    public void CategoryOne()
    {
      Assert.AreEqual(13983816d, CalculateChance(6, 49), 1d);
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

    double CalculateChance (double maxNumbers, double totalNumbers)
    {
      double chance = Factorial(totalNumbers) / Factorial(maxNumbers) / Factorial(totalNumbers - maxNumbers);
      return chance;
    }
  }
}
