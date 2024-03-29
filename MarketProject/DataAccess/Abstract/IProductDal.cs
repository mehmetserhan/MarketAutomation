﻿using MarketProject.Core.DataAccess;
using MarketProject.Entities.Concrete;
using MarketProject.Entities.Dtos;
using Microsoft.Office.Interop.Word;
using System.Collections.Generic;

namespace MarketProject.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductProfitAndDamageDto> GetListProductProfitAndDamage();
    }
}
