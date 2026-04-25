using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Business.Validators;
using Villa.Dto.Dtos.ContactDtos;
using Villa.Dto.Dtos.CounterDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class CounterController : Controller
    {
        private readonly ICounterService _counterService;

        private readonly IMapper _mapper;
        public CounterController(ICounterService counterService, IMapper mapper)
        {
            _counterService = counterService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _counterService.TGetListAsync();
            var counterList = _mapper.Map<List<ResultCounterDto>>(values);
            return View(counterList);
        }
        public async Task<IActionResult> DeleteCounter(ObjectId id)
        {
            await _counterService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateCounter()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCounter(CreateCounterDto createCounterDto)
        {
            ModelState.Clear();
            var newValue = _mapper.Map<Counter>(createCounterDto);
            var validator = new CounterValidator();
            var result = validator.Validate(newValue);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(createCounterDto);
            }
            await _counterService.TCreateAsync(newValue);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateCounter(ObjectId id)
        {
            var value = await _counterService.TGetByIdAsync(id);
            var counter = _mapper.Map<UpdateCounterDto>(value);
            return View(counter);
        }
        [HttpPost]

        public async Task<IActionResult> UpdateCounter(UpdateCounterDto updateCounterDto)
        {
            var Counter = _mapper.Map<Counter>(updateCounterDto);
            await _counterService.TUpdateAsync(Counter);
            return RedirectToAction("Index");
        }
    }
}
