using System;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Runtime.Validation;
using ABP.TPLMS.Cargoes;
using ABP.TPLMS.Cargoes.Dto;
using ABP.TPLMS.Controllers;
using Abp.Web.Models;
using AutoMapper;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace ABP.TPLMS.Web.Controllers
{
    [AbpMvcAuthorize]
    public class CargoController : TPLMSControllerBase
    {
        private const int MaxNum = 10;
        // GET: /<controller>/
        public IActionResult Index()
        {

            ViewData["SupplierId"] = "100001";
            return View();
        }

        private readonly ICargoAppService _cargoAppService;

        public CargoController(ICargoAppService cargoAppService)
        {
            _cargoAppService = cargoAppService;

        }

        [HttpPost]
        [DisableValidation]
        public ActionResult Add(CargoDto createDto)
        {
            var json = string.Empty;
            string result = "NO";
            if (createDto == null)
            {
                json = JsonEasyUiResult(0, result);
                return Content(json);

            }
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<CargoDto, CreateUpdateCargoDto>());
                var mapper = config.CreateMapper();
                var cargo = mapper.Map<CreateUpdateCargoDto>(createDto);

                // TODO: Add logic here
                var obj = _cargoAppService.Create(cargo);
                int id = obj.GetAwaiter().GetResult().Id;
                json = JsonEasyUiResult(id, "OK");
            }
            catch

            {
                // ignored
            }

            return Content(json);

        }

        [HttpPost]
        [DisableValidation]
        public ActionResult Update(CreateUpdateCargoDto updateDto)
        {
            string result = "NO";

            try
            {

                var obj = _cargoAppService.Update(updateDto);

                if (obj != null)

                {
                    result = "OK";
                }
            }
            catch
            {
                // ignored
            }

            var json = JsonEasyUiResult(0, result);
            return Content(json);

        }

        public ActionResult Delete(string ids)
        {
            string result = "NO";

            try
            {
                result = _cargoAppService.DeleteBatch(ids);
            }
            catch
            {

            }

            return Content(result);
        }

        [DontWrapResult]
        [CanBeNull]
        public string List()
        {

            var page = Request.Form["page"].ToString();
            var size = Request.Form["rows"].ToString();
            int pageIndex = page == null ? 1 : int.Parse(page);
            int pageSize = size == null ? 20 : int.Parse(size);
            PagedCargoResultRequestDto paged = new PagedCargoResultRequestDto
            {
                CargoName = Request.Form["Name"].ToString(),
                CargoCode = Request.Form["Code"].ToString(),
                MaxResultCount = pageSize,
                SkipCount = ((pageIndex - 1) < 0 ? 0 : pageIndex - 1) * pageSize,
                HsCode = Request.Form["HsCode"].ToString()
            };

            var cargoList = _cargoAppService.GetAll(paged).GetAwaiter().GetResult().Items ?? throw new ArgumentNullException("_cargoAppService.GetAll(paged).GetAwaiter().GetResult().Items");
            var total = _cargoAppService.GetAll(paged).GetAwaiter().GetResult().TotalCount; //1000;
            var json = JsonEasyUi(cargoList, total);
            return json;
        }

    }
}