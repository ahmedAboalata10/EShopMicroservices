using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Exceptions
{
    public class NotFoundException :Exception
    {
        public NotFoundException(string message) : base(message)
        {
            
        }
        public NotFoundException(string messange,string detail) : base(messange)
        {
            Detail = detail;
        }
        public string?  Detail { get; set; }
    }
}
