using ScoutApp.Core;

namespace ScoutApp.Infrastructure;

public class EFScoutRepository : IScoutRepository
{
    private readonly ScoutAppDbContext _context;

    public EFScoutRepository(ScoutAppDbContext context)
    {
        _context = context;
    }

    public void Add(Scout a)
    {
        _context.Scouts.Add(a);
        _context.SaveChanges();
    }

    public void Delete(int scoutId)
    {
        var scout = _context.Scouts.Find(scoutId);
        if (scout != null)
        {
            _context.Scouts.Remove(scout);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Scout> GetAll()
    {
        return _context.Scouts;
    }

    public Scout? GetById(int scoutId)
    {
        return _context.Scouts.Find(scoutId);
    }

    public void Update(Scout scout)
    {
        _context.Scouts.Update(scout);
        _context.SaveChanges();
    }
}