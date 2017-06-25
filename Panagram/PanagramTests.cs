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

    [TestMethod]
    public void CheckForNoPanagram()
    {
      Assert.AreEqual(false, IsPanagram("The old brown fox jumps over the lazy dog"));
    }

    bool IsPanagram (string inputString)
    {
      for (char letter = 'a'; letter <= 'z'; letter++)
      {
        if (inputString.ToLower().IndexOf(letter) == -1)
          return false;
      }
      return true;
    }
  }
}
