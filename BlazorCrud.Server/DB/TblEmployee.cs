using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.DB
{
    public partial class TblEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public bool? IsActive { get; set; }
    }
}
