using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nafibel.SERVICE.Dtos
{
    public class Result
    {
        public bool Success { get; set; }
        public string Errror { get; set; }

        public Result(bool success, string error = "")
        {
            Success = success;
            Errror = error;
        }

    }

    public class Result<T> : Result
    {
        public Result(bool success, string error = "") : base(success, error)
        {
        }

        public T Model { get; set; }


    }
}
