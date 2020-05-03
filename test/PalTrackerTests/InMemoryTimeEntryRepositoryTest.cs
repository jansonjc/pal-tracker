using System;
using System.Linq;
using FluentAssertions;
using PalTracker;
using Xunit;

namespace PalTrackerTests
{
  public class InMemoryTimeEntryRepositoryTest
  {
    private readonly InMemoryTimeEntryRepository _repository;

    public InMemoryTimeEntryRepositoryTest()
    {
      _repository = new InMemoryTimeEntryRepository();
    }

    [Fact]
    public void Create()
    {
      var expected = new TimeEntry(1, 222, 333, new DateTime(2008, 08, 01, 12, 00, 01), 24);

      var created = _repository.Create(new TimeEntry(222, 333, new DateTime(2008, 08, 01, 12, 00, 01), 24));

      expected.Should().BeEquivalentTo(created);
      expected.Should().BeEquivalentTo(_repository.Find(1));
    }

    [Fact]
    public void Find()
    {
      var timeEntry = _repository.Create(new TimeEntry(222, 333, new DateTime(2008, 08, 01, 12, 00, 01), 24));

      var found = _repository.Find(timeEntry.Id ?? 0);

      Assert.Equal(timeEntry, found);
    }

    [Fact]
    public void Contains()
    {
      _repository.Create(new TimeEntry(222, 333, new DateTime(2008, 08, 01, 12, 00, 01), 24));

      _repository.Contains(1);

      Assert.True(_repository.Contains(1));
      Assert.False(_repository.Contains(2));
    }

    [Fact]
    public void List()
    {
      var timeEntry1 = _repository.Create(new TimeEntry(222, 333, new DateTime(2008, 08, 01, 12, 00, 01), 24));
      var timeEntry2 = _repository.Create(new TimeEntry(888, 777, new DateTime(2012, 09, 02, 11, 30, 00), 12));

      var found = _repository.List();

      Assert.Contains(timeEntry1, found);
      Assert.Contains(timeEntry2, found);
      Assert.Equal(2, found.Count());
    }

    [Fact]
    public void Update()
    {
      var timeEntry = _repository.Create(new TimeEntry(222, 333, new DateTime(2008, 08, 01, 12, 00, 01), 24));

      var timeEntryUpdated = _repository.Update(1, new TimeEntry(555, 666, new DateTime(2020, 08, 01, 01, 55, 10), 8));

      var entires = _repository.List();
      Assert.Contains(timeEntryUpdated, entires);
      Assert.DoesNotContain(timeEntry, entires);
    }

    [Fact]
    public void Delete()
    {
      var timeEntry1 = _repository.Create(new TimeEntry(222, 333, new DateTime(2008, 08, 01, 12, 00, 01), 24));
      var timeEntry2 = _repository.Create(new TimeEntry(888, 777, new DateTime(2012, 09, 02, 11, 30, 00), 12));

      _repository.Delete(timeEntry1.Id ?? 0);

      var remaining = _repository.List();
      Assert.DoesNotContain(timeEntry1, remaining);
      Assert.Contains(timeEntry2, remaining);
      Assert.Single(remaining);
    }
  }
}