using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.Dto.Dtos.BannerDtos
{
    public class ResultBannerDto
    {
        public ObjectId Id { get; set; }
        public String? City { get; set; }
        public String? Title { get; set; }
        public String? ImageUrl { get; set; }
    }
}
