using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Faculdade.Services.Errors
{
    public class AlunoDbUpdateException: Exception
    {
        public int Code { get; set; }

        public AlunoDbUpdateException(int code, string message) : base(message)
        {
            Code = code;
        }
    }
}
