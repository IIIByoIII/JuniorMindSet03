using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cube
{
  [TestClass]
  public class CubeTests
  {
    [TestMethod]
    public void Ending888CubeOne()
    {
      Assert.AreEqual(192d, The888EndingCube(1));
    }

    double The888EndingCube(int nth)
    {
      double result = ((250 * (nth - 1)) + 192);
      return result;
    }
  }
}
