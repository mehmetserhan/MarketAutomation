﻿using MarketProject.Core.Utilities.Results;
using MarketProject.Entities.Concrete;
using System.Collections.Generic;

namespace MarketProject.Business.Abstract
{
    public interface IDebtSupplierService
    {
        IResult Add(DebtSupplier debtSupplier);
        IResult Update(DebtSupplier debtSupplier);
        IResult Delete(DebtSupplier debtSupplier);
        IDataResult<List<DebtSupplier>> GetList();
        IDataResult<DebtSupplier> GetById(int id);
        IDataResult<DebtSupplier> GetBySupplierId(int supplierId);
    }
}
