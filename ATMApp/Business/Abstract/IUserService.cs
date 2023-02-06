﻿using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        // Kullanıcı rollerini getiriyorum
        List<OperationClaim> GetClaims(User user);

        //Kullanıcı Ekleme
        void Add(User user);

        User GetByMail(string email);
    }
}
