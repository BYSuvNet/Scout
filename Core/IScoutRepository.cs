using ScoutApp.Core;

public interface IScoutRepository
{
    public void Add(Scout s);
    public void Update(Scout s);
    public void Delete(int scoutId);
    public Scout? GetById(int scoutId);
    public IEnumerable<Scout> GetAll();
}