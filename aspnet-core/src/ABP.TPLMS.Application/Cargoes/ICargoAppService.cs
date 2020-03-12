﻿using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using ABP.TPLMS.Cargoes.Dto;

namespace ABP.TPLMS.Cargoes
{
    public interface ICargoAppService : IAsyncCrudAppService<//定义了CRUD方法
        CargoDto, //用来展示货物信息
        int, //Cargo实体的主键
        PagedCargoResultRequestDto, //获取货物信息的时候用于分页
        CreateUpdateCargoDto, //用于创建货物信息
        CreateUpdateCargoDto> //用于更新货物信息
    {

    }
}
