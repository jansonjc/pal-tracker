using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalTracker
{
  public class TimeEntry
  {
    public long? Id { get; }
    public long ProjectId { get; }
    public long UserId { get; }
    public DateTime Date { get; }
    public int Hours { get; }

    public TimeEntry(long id, long projectId, long userId, DateTime date, int hours)
    {
      Id = id;
      ProjectId = projectId;
      UserId = userId;
      Date = date;
      Hours = hours;
    }

    public TimeEntry(long projectId, long userId, DateTime date, int hours)
    {
      Id = null;
      ProjectId = projectId;
      UserId = userId;
      Date = date;
      Hours = hours;
    }
  }
}
