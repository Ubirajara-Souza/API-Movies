using AutoMapper;
using FluentResults;
using MoviesApi.Domain.Dtos.Response;
using MoviesApi.Domain.Dtos.Request.Manager;
using MoviesApi.Domain.Entities;
using MoviesApi.Infra.Repositories;
using System.Collections.Generic;

namespace MoviesApi.Services
{
    public class ManagerService
    {
        private ManagerRepository _managerRepository;
        private readonly IMapper _mapper;

        public ManagerService(ManagerRepository managerRepository, IMapper mapper)
        {
            _managerRepository = managerRepository;
            _mapper = mapper;
        }

        public ManagerViews AddManager(ManagerDTO managerDTO)
        {
            ManagerModel manager = _mapper.Map<ManagerModel>(managerDTO);
            _managerRepository.AddManager(manager);

            return _mapper.Map<ManagerViews>(manager);
        }

        public IEnumerable<ManagerViews> ListManager()
        {
            IEnumerable<ManagerModel> manager = _managerRepository.ListManager();

            if (manager != null)
            {
                IEnumerable<ManagerViews> managerViews = _mapper.Map<IEnumerable<ManagerViews>>(manager);
                return managerViews;
            }

            return null;
        }

        public ManagerViews ListManagerById(int id)
        {
            ManagerModel manager = _managerRepository.ListManagerById(id);
            if (manager != null)
            {
                ManagerViews managerViews = _mapper.Map<ManagerViews>(manager);
                return managerViews;
            }
            return null;
        }
        public Result DeleteManager(int id)
        {
            ManagerModel manager = _managerRepository.ListManagerById(id);
            if (manager == null)
            {
                return Result.Fail("Gerente Não encontrado");
            }

            _managerRepository.DeleteManager(id);
            return Result.Ok();
        }
    }
}
