using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExcelColumns
{
  [TestClass]
  public class ExcelColumnsTests
  {
    [TestMethod]
    public void ColumnF()
    {
      Assert.AreEqual("F", ExcelColumn(6));
    }

    string ExcelColumn (int columnNumber)
    {
      string allLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      return allLetters[columnNumber - 1].ToString();
    }
  }
}
