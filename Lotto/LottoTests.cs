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
    public void CategoryOne6of49()
    {
      Assert.AreEqual(13983816d, WinningChance(6, 6, 49), 1d);
    }

    [TestMethod]
    public void CategoryTwo6of49()
    {
      Assert.AreEqual(54200.8d, WinningChance(5, 6, 49), 1d);
    }

    [TestMethod]
    public void CategoryThree6of49()
    {
      Assert.AreEqual(1032.4d, WinningChance(4, 6, 49), 1d);
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

    double WinningChance(double winningNumbers, double maxNumbers, double totalNumbers)
    {
      double winChance;
      if (winningNumbers != maxNumbers)
        winChance = 1 / (CalculateChance(winningNumbers, maxNumbers) * CalculateChance((maxNumbers - winningNumbers), (totalNumbers - maxNumbers)) / CalculateChance(maxNumbers, totalNumbers));
      else
        winChance = CalculateChance(winningNumbers, totalNumbers);
      return winChance;
    }
  }
}
