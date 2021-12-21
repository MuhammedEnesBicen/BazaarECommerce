﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBookDal:IGenericDal<Book>
    {
        ResultModel DeleteById(int bookId);
        Book GetById(int bookId);
        Book GetByProductId(int productId);
    }
}
