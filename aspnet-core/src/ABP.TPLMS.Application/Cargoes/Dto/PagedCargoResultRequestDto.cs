using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace ABP.TPLMS.Cargoes.Dto
{
    public class PagedCargoResultRequestDto:PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public string CargoName { get; set; }
        public string CargoCode { get; set; }
        public string HsCode { get; set; }
    }
}
