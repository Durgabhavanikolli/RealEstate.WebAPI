using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DTO
{
    
    public class ResponseDTO<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
        public ResponseDTO(bool success,string message, T result)
        {
            Success = success;
            Message = message;
            Result=result;
        }
    }
}
