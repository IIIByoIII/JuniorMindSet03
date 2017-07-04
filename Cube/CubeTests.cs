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

    [TestMethod]
    public void Ending888CubeTwo()
    {
      Assert.AreEqual(442d, The888EndingCube(2));
    }

    double The888EndingCube(int nth)
    {
      double result = ((250 * (nth - 1)) + 192);
      return result;
    }
  }
}
