﻿using MarketProject.Core.Utilities.Results;
using MarketProject.Entities.Concrete;
using MarketProject.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.Business.Abstract
{
    public interface IAdminService
    {
        IResult Add(Admin admin);
        IResult Update(Admin admin);
        IResult Delete(Admin admin);
        IDataResult<List<Admin>> GetList();
        IDataResult<Admin> GetById(int id);

        IDataResult<Admin> AdminToCheck(UserForLoginDto userForLoginDto);
    }
}
