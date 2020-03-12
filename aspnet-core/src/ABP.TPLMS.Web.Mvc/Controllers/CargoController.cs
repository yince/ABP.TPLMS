using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABP.TPLMS.Cargoes;
using ABP.TPLMS.Cargoes.Dto;
using ABP.TPLMS.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ABP.TPLMS.Web.Controllers
{
    public class CargoController : TPLMSControllerBase
    {
        const int MaxNum = 10;
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

        public JsonResult List()
        {

            var page = Request.Form["page"].ToString();
            var size = Request.Form["rows"].ToString();

            int pageIndex = page == null ? 1 : int.Parse(page);

            int pageSize = size == null ? 20 : int.Parse(size);

            PagedCargoResultRequestDto paged = new PagedCargoResultRequestDto();
            paged.MaxResultCount = pageSize;
            paged.SkipCount = ((pageIndex - 1) < 0 ? 0 : pageIndex - 1) * pageSize;
            var userList = _cargoAppService.GetAll(paged).GetAwaiter().GetResult().Items;

            int total = 1000;
            var json = JsonEasyUI(userList, total);

            return json;
        }
    }
}