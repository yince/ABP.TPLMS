using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace ABP.TPLMS.Cargoes.Dto
{
    public class PagedCargoResultRequestDto:PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
