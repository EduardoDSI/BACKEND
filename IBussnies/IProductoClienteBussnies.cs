﻿using Models.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBussnies
{
    public interface IProductoClienteBussnies : ICRUDBussnies<ProductoClienteRequest,  ProductoClienteResponse>
    {
    }
}