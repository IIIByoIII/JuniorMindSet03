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

    [TestMethod]
    public void ColumnAZ()
    {
      Assert.AreEqual("AZ", ExcelColumn(52));
    }

    [TestMethod]
    public void ColumnABF()
    {
      Assert.AreEqual("ABF", ExcelColumn(734));
    }

    [TestMethod]
    public void ColumnCIYY()
    {
      Assert.AreEqual("CIYY", ExcelColumn(59487));
    }

    string allLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    string ExcelColumn (int columnNumber)
    {
      string columnLetter = "";
      while (columnNumber > 0)
      {
        if ((columnNumber % 26) != 0)
        {
          columnLetter = columnLetter.Insert(0, CurrentColumn(columnNumber % 26));
          columnNumber /= 26;
        }
        else
        {
          columnLetter = columnLetter.Insert(0, CurrentColumn(26));
          columnNumber = (columnNumber / 26) - 1;
        }
      }
      return columnLetter;
    }

    string CurrentColumn (int columnNumber)
    {
      return allLetters[columnNumber - 1].ToString();
    }
  }
}
