using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using ABP.TPLMS.Cargoes.Dto;
using ABP.TPLMS.Entities;

namespace ABP.TPLMS.Cargoes
{
    public class CargoAppService:AsyncCrudAppService<Cargo,CargoDto,int,PagedCargoResultRequestDto,CreateUpdateCargoDto,CreateUpdateCargoDto>,ICargoAppService
    {
        public CargoAppService(IRepository<Cargo, int> repository) : base(repository)
        {
        }
    }
}
