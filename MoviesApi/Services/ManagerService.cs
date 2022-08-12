using AutoMapper;
using FluentResults;
using MoviesApi.Database;
using MoviesApi.Dtos.Manager;
using MoviesApi.Models;
using MoviesApi.Views;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Services
{
    public class ManagerService
    {
        private readonly MoviesApiContext _context;
        private readonly IMapper _mapper;

        public ManagerService(MoviesApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ManagerViews AddManager(ManagerDTO managerDTO)
        {
            ManagerModel manager = _mapper.Map<ManagerModel>(managerDTO);
            _context.Manager.Add(manager);
            _context.SaveChanges();

            return _mapper.Map<ManagerViews>(manager);
        }

        public IEnumerable<ManagerViews> ListManager()
        {
            IEnumerable<ManagerModel> manager = _context.Manager;

            if (manager != null)
            {
                IEnumerable<ManagerViews> managerViews = _mapper.Map<IEnumerable<ManagerViews>>(manager);
                return managerViews;
            }

            return null;
        }

        public ManagerViews ListManagerById(int id)
        {
            ManagerModel manager = _context.Manager.FirstOrDefault(manager => manager.Id == id);
            if (manager != null)
            {
                ManagerViews managerViews = _mapper.Map<ManagerViews>(manager);
                return managerViews;
            }
            return null;
        }
        public Result DeleteManager(int id)
        {
            ManagerModel manager = _context.Manager.FirstOrDefault(manager => manager.Id == id);

            if (manager == null)
            {
                return Result.Fail("Gerente Não encontrado");
            }

            _context.Remove(manager);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
