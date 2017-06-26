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

    int Factorial (int number)
    {
      int factorialForNumber = number;
      for (int i = number; i > 2; i--)
      {
        factorialForNumber *= i-1;
      }
      return factorialForNumber;
    }
  }
}
