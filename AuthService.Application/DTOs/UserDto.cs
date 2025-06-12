using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.DTOs
{
    public class UserDto
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public bool IsActive { get; set; }
    }
}
