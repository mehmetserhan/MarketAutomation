﻿using MarketProject.Core.DataAccess;
using MarketProject.Entities.Concrete;
using MarketProject.Entities.Dtos;
using System.Collections.Generic;

namespace MarketProject.DataAccess.Abstract
{
    public interface ICustomerPaymentDal:IEntityRepository<CustomerPayment> 
    {
        List<CustomerPaymentDto> GetListCustomerPayment();
    }
}
