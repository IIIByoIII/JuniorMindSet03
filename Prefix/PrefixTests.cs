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

    [TestMethod]
    public void TestForPrefixTripleA()
    {
      Assert.AreEqual("aaa", CommonPrefix("aaab", "aaaabbaa"));
    }

    [TestMethod]
    public void TestForNoPrefix()
    {
      Assert.AreEqual("", CommonPrefix("baab", "aaaabbaa"));
    }

    [TestMethod]
    public void TestForPrefixQuadraB()
    {
      Assert.AreEqual("bbbb", CommonPrefix("bbbbbaaab", "bbbbab"));
    }

    string CommonPrefix (string stringOne, string stringTwo)
    {
      string commonPrefix = "";
      if (stringOne[0] == stringTwo [0])
      {
        commonPrefix += stringOne[0];
        int minimumLength = MinimumLength(stringOne, stringTwo);
        for (int i = 1; i < minimumLength; i++)
        {
          if (stringOne[i] == stringTwo[i])
          {
            commonPrefix += stringOne[i];
          }
          else
          {
            break;
          }
        }
      }
      return commonPrefix;
    }

    int MinimumLength (string stringOne, string stringTwo)
    {
      int minimumLength = (stringOne.Length > stringTwo.Length) ? stringTwo.Length : stringOne.Length;
      return minimumLength;
    }
  }
}
