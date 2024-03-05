using FataakAPI.Models;

namespace FataakAPI.Services
{
    public interface IFataakService
    {
        public Fataak Create(Fataak ftk);
        public List<Fataak> Get();
        public Fataak Get(string id);
        public void Remove(string id);
        public void Update(string id, Fataak ftk);
    }
}
