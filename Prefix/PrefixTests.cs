using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prefix
{
  [TestClass]
  public class PrefixTests
  {
    [TestMethod]
    public void TestForMinimumLenght()
    {
      Assert.AreEqual(4, MinimumLength("aaab", "aaaabbaa"));
    }

    int MinimumLength (string stringOne, string stringTwo)
    {
      int minimumLength = (stringOne.Length > stringTwo.Length) ? stringTwo.Length : stringOne.Length;
      return minimumLength;
    }
  }
}
