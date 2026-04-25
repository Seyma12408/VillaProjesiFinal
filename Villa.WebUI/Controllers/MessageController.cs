using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Business.Validators;
using Villa.Dto.Dtos.DealDtos;
using Villa.Dto.Dtos.MessageDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMapper mapper, IMessageService messageService)
        {
            _mapper = mapper;
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _messageService.TGetListAsync();
            var valueList = _mapper.Map<List<ResultMessageDto>>(values);
            return View(valueList);
        }
        public async Task<IActionResult> DeleteMessage(ObjectId id)
        {
            await _messageService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            ModelState.Clear();
            var newValue = _mapper.Map<Message>(createMessageDto);
            var validator = new MessageValidator();
            var result = validator.Validate(newValue);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(createMessageDto);
            }
            await _messageService.TCreateAsync(newValue);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> MessageDetails(ObjectId id)
        {
            var value = await _messageService.TGetByIdAsync(id);
            var messageValue = _mapper.Map<ResultMessageDto>(value);
            return View(messageValue);
        }
   
}
    }
