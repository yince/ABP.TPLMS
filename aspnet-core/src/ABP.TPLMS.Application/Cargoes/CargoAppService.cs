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

        public string DeleteBatch(string ids)
        {
            string result = "NO";
            var idList = ids.Split(',');
            foreach (var item in idList)
            {
                var id = 0;
                int.TryParse(item, out id);
                var cargoList = base.GetEntityByIdAsync(id);

                var cargo = MapToEntityDto(cargoList.GetAwaiter().GetResult());

                var obj = base.Delete(cargo);

                obj.GetAwaiter().GetResult();
                if (obj != null)
                {
                    result = "OK";
                }
            }
            return result;
        }
    }
}
