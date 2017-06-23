using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panagram
{
  [TestClass]
  public class PanagramTests
  {
    [TestMethod]
    public void CheckForPanagram()
    {
      Assert.AreEqual(true, IsPanagram("The quick brown fox jumps over the lazy dog"));
    }

    bool IsPanagram (string inputString)
    {
       string allLetters = "abcdefghijklmnopqrstuvwxyz";
      foreach (char letter in allLetters)
      {
        if (inputString.ToLower().IndexOf(letter) == -1)
          return false;
      }
      return true;
    }
  }
}
