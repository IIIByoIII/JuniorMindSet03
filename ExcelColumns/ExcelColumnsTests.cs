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

    [TestMethod]
    public void ColumnAF()
    {
      Assert.AreEqual("AF", ExcelColumn(32));
    }

    string allLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    string ExcelColumn (int columnNumber)
    {
      string columnLetter = "";
      while (columnNumber > 26)
      {
        int columnQuotient = columnNumber / 26;
        int columnRemainder = columnNumber % 26;
        columnLetter += CurrentColumn(columnQuotient);
        columnNumber = columnRemainder;
      }
      return columnLetter += CurrentColumn(columnNumber);
    }

    string CurrentColumn (int columnNumber)
    {
      return allLetters[columnNumber - 1].ToString();
    }
  }
}
