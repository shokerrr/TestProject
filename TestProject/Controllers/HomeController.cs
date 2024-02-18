using AutoMapper;
using BLL.DTO;
using BLL.Object;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TestProject.Models;
using TestProject.Object;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IBaseService<StorageDTO> _service;

        public HomeController(IStorageService service, ILogger<HomeController> logger)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StorageModel, StorageDTO>();
                cfg.CreateMap<StorageDTO, StorageModel>();
            });
            _mapper = config.CreateMapper();

            _service = service;
            //_logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index", GetAll(null));
        }

        [HttpGet]
        public IEnumerable<StorageModel> GetAll(FilterOptions? options)
        {
            var opt = options != null ? _mapper.Map<FilterOptions, StorageFilters>(options) : null;
            var res = _mapper.Map<IEnumerable<StorageDTO>, IEnumerable<StorageModel>>(_service.GetByFilters(opt));

            return res;
        }

        //[HttpPost]
        public ActionResult AddRange(IEnumerable<StorageModel>? items)
        {
            if (items != null)
            {
                _service.AddRange(_mapper.Map<IEnumerable<StorageModel>, IEnumerable<StorageDTO>>(items));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult AddFile(IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    var fStream = new StreamReader(file.OpenReadStream());
                    var fileContent = fStream.ReadToEnd();
                    var json = JsonSerializer.Deserialize<IEnumerable<StorageModel>>(fileContent);
                    return AddRange(json);
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Privacy));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ActionName("SaveData")]
        public IActionResult SaveJsonData()
        {
            return View("Api");
        }
    }
}
