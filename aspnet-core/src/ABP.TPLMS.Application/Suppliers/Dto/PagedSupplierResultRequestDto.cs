using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace ABP.TPLMS.Suppliers.Dto
{
    public class PagedSupplierResultRequestDto: PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
