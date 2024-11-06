
using ScoutApp.Core;

namespace ScoutApp.Infrastructure;

class FakeScoutRepository : IScoutRepository
{
    //Instead of using a database, we use lists to store scouts
    readonly List<Scout> _scouts = [];

    public FakeScoutRepository()
    {
        //Add some scouts to the list, pretend they are already in the database since before
        _scouts.Add(new Scout("Kalle", "kalle@scouterna.se", new DateOnly(2005, 1, 1)));
        _scouts.Add(new Scout("Lisa", "lisa@scouterna.se", new DateOnly(2006, 2, 2)));
        _scouts.Add(new Scout("Pelle", "pelle@scouterna.se", new DateOnly(2007, 3, 3)));
        _scouts.Add(new Scout("Anna", "anna@scouterna.se", new DateOnly(2008, 4, 4)));
    }

    public void Add(Scout s)
    {
        if (s == null) throw new ArgumentNullException("Scout cannot be null");

        _scouts.Add(s);
    }

    public void Update(Scout s)
    {
        //Find the scout in the list and replace it with the new one
        var scout = _scouts.FirstOrDefault(s => s.Id == s.Id);
        if (scout != null)
        {
            scout = s;
        }
    }

    public void Delete(int scoutId)
    {
        _scouts.RemoveAll(s => s.Id == scoutId);
    }

    public IEnumerable<Scout> GetAll()
    {
        return _scouts;
    }

    public Scout? GetById(int scoutId)
    {
        return _scouts.FirstOrDefault(s => s.Id == scoutId);
    }
}