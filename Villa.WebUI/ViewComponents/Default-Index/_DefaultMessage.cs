using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.BannerDtos;
using Villa.Dto.Dtos.DealDtos;
using Villa.Dto.Dtos.MessageDtos;

namespace Villa.WebUI.ViewComponents.Default_Index
{
    public class _DefaultMessage : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
         return View();
        }
    }
}
