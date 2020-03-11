using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using ABP.TPLMS.Entities;
using ABP.TPLMS.Suppliers.Dto;

namespace ABP.TPLMS.Suppliers
{
    public class SupplierAppService : AsyncCrudAppService<Supplier, SupplierDto, int, PagedSupplierResultRequestDto,
        CreateUpdateSupplierDto, CreateUpdateSupplierDto>, ISupplierAppService
    {
        public SupplierAppService(IRepository<Supplier, int> repository)
            : base(repository)
        {

        }

        public override Task<SupplierDto> Create(CreateUpdateSupplierDto input)
        {
            var sin = input;
            return base.Create(input);
        }
    }
}

