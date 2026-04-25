using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.Entity.Entities
{
    public class Banner : BaseEntity
    {
        public String City { get; set; }
        public String Title { get; set; }
        public String ImageUrl { get; set; }
    }
}
