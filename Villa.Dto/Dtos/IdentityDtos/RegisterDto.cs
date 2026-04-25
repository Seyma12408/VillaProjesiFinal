using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.Dto.Dtos.IdentityDtos
{
    public class RegisterDto
    {
        public String NameSurname { get; set; }
        public String Email { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }

    }
}
