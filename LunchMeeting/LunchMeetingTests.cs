using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LunchMeeting
{
  [TestClass]
  public class LunchMeetingTests
  {
    [TestMethod]
    public void NextMeeting6to4()
    {
      Assert.AreEqual(12, NextMeeting(6, 4));
    }

    int NextMeeting (int yourDays, int friendsDays)
    {
      int maxDays = yourDays > friendsDays ? yourDays : friendsDays;
      int minDays = yourDays < friendsDays ? yourDays : friendsDays;
      for (int i = 1; i < minDays; i++)
      {
        if (0d == ((maxDays * i * 1d) % minDays))
          return maxDays * i;
      }
      return maxDays * minDays;
    }
  }
}
