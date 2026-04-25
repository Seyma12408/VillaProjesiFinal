using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.Dto.Dtos.SubHeaderDtos
{
    public class UpdateSubHeaderDto
    {
        public ObjectId Id { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }
        public String Facebook { get; set; }
        public String Twitter { get; set; }
        public String Linkedin { get; set; }
        public String Instagram { get; set; }
    }
}
