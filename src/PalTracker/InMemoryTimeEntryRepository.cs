using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalTracker
{
  public class InMemoryTimeEntryRepository : ITimeEntryRepository
  {
    public bool Contains(long id)
    {
      throw new NotImplementedException();
    }

    public TimeEntry Create(TimeEntry timeEntry)
    {
      throw new NotImplementedException();
    }

    public void Delete(long id)
    {
      throw new NotImplementedException();
    }

    public TimeEntry Find(long id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<TimeEntry> List()
    {
      throw new NotImplementedException();
    }

    public TimeEntry Update(long id, TimeEntry timeEntry)
    {
      throw new NotImplementedException();
    }
  }
}
