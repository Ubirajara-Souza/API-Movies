using MoviesApi.Infra.Repositories.BaseContext;
using MoviesApi.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Infra.Repositories
{
    public class ManagerRepository
    {
        protected readonly MoviesApiContext _context;

        public ManagerRepository(MoviesApiContext context)
        {
            _context = context;
        }

        public ManagerModel AddManager(ManagerModel manager)
        {
            _context.Manager.Add(manager);
            _context.SaveChanges();

            return manager;
        }

        public IEnumerable<ManagerModel> ListManager()
        {
            return _context.Manager.ToList();
        }

        public ManagerModel ListManagerById(int id)
        {
            ManagerModel manager = _context.Manager.FirstOrDefault(manager => manager.Id == id);
            if (manager != null)
            {
                return manager;
            }
            return null;
        }
        public void DeleteManager(int id)
        {
            ManagerModel manager = _context.Manager.FirstOrDefault(manager => manager.Id == id);

            if (manager != null)
            {
                _context.Remove(manager);
                _context.SaveChanges();
            }
        }
    }
}
