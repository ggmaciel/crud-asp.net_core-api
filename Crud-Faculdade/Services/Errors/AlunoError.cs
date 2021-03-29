using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Faculdade.Services.Errors
{
    public class AlunoError: Exception
    {
        public int Code { get; set; }

        public AlunoError(int code, string message) : base(message)
        {
            Code = code;
        }
    }
}
