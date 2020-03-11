using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using ABP.TPLMS.Controllers;
using ABP.TPLMS.Modules.Dto;
using ABP.TPLMS.Suppliers;
using ABP.TPLMS.Suppliers.Dto;
using ABP.TPLMS.Web.Models.Supplier;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ABP.TPLMS.Web.Controllers
{
    public class SupplierController : TPLMSControllerBase
    {
        const int MaxNum = 10;
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {

            var module = (await _supplierAppService.GetAll(new PagedSupplierResultRequestDto { MaxResultCount = MaxNum })).Items.OrderBy(s=>s.CreationTime).ToList();
            // Paging not implemented yet
            SupplierDto cuModule = module.FirstOrDefault();
            var model = new SupplierListViewModel
            {

                Supplier = cuModule,
                Suppliers = module

            };
            return View(model);
        }

        private readonly ISupplierAppService _supplierAppService;

        public SupplierController(ISupplierAppService supplierAppService)
        {
            _supplierAppService = supplierAppService;

        }
        public async Task<ActionResult> EditSupplierModal(int supplierId)

        {
            var module = await _supplierAppService.Get(new EntityDto<int>(supplierId));

            var config = new MapperConfiguration(cfg => cfg.CreateMap<SupplierDto, CreateUpdateSupplierDto>());
            var mapper = config.CreateMapper();
            CreateUpdateSupplierDto cuSupplier = mapper.Map<CreateUpdateSupplierDto>(module);
            var model = new EditSupplierModalViewModel
            {
                Supplier = cuSupplier

            };
            return View("_EditSupplierModal", model);
        }
    }
}