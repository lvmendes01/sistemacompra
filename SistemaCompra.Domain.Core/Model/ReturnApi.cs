using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Domain.Core.Model
{
    public class ReturnApi
    {
        public bool Valid { get; set; }
        public Object ReturnObject { get; set; }

        public string Message { get; set; }
    }
}
