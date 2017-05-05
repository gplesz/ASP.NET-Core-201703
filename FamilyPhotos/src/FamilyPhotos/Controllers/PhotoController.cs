using AutoMapper;
using FamilyPhotos.Models;
using FamilyPhotos.Repository;
using FamilyPhotos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.Controllers
{
    public class PhotoController : Controller
    {
        private readonly PhotoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<PhotoController> logger;

        public PhotoController(PhotoRepository repository, IMapper mapper,
            ILogger<PhotoController> logger)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            this.repository = repository;

            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }
            this.mapper = mapper;

            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            //A category is specified with each log that you create.The category may be any 
            //string, but a convention is to use the fully qualified name of the class from 
            //which the logs are written.For example: "TodoApi.Controllers.TodoController".
            //_logger = logger.CreateLogger("FamilyPhotos.Controllers.PhotoController");
            //de egyszerűbb Di-vel átvenni
            this.logger = logger;
        }

        public IActionResult Index()
        {
            //https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.extensions.logging.loglevel

            //Trace = 0
            //For information that is valuable only to a developer debugging an issue.
            //These messages may contain sensitive application data and so should not 
            //be enabled in a production environment.
            //
            //*Disabled by default.*
            //Example: 
            //Credentials: { "User":"someuser", "Password":"P@ssword"}

            //Debug = 1
            //For information that has short-term usefulness during development and debugging.
            //Example: Entering method Configure with flag set to true.

            //Information = 2
            //For tracking the general flow of the application. These logs typically 
            //have some long-term value.Example: Request received for path / api / todo

            //Warning = 3
            //For abnormal or unexpected events in the application flow.These may include 
            //errors or other conditions that do not cause the application to stop, but 
            //which may need to be investigated.Handled exceptions are a common place to use the Warning log level. Example: FileNotFoundException for file quotes.txt.

            //Error = 4
            //For errors and exceptions that cannot be handled.These messages indicate a 
            //failure in the current activity or operation(such as the current HTTP request), 
            //not an application - wide failure.
            //Example log message: Cannot insert record due to duplicate key violation.

            //Critical = 5
            //For failures that require immediate attention.
            //Examples: data loss scenarios, out of disk space.

            logger.LogInformation("az Index actiont meghívták");
            var pics = repository.GetAllPhotos();
            return View(pics);
        }

        public FileContentResult GetImage(int photoId)
        {
            var pic = repository.GetPicture(photoId);
            if (pic==null || pic.Picture==null)
            {
                return null;
            }

            return File(pic.Picture, pic.ContentType);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View(new PhotoViewModel());
        }

        [HttpPost]
        //public IActionResult Create(string Title, string Description)
        public IActionResult Create(PhotoViewModel viewModel) //Itt az MVC modelbindere a bejövő paramétereket egyezteti a várt osztály propertyjeivel és ki is tölti
        {
            //Ha a kontroller action model-t fogad, KÖTELEZŐ ellenőrizni a 
            //ModelState-et

            //nagyon kezdetleges Adatvalidálás, ezt majd jól meg fogjuk haladni!
            //hiányzik még pár dolog, csak DEMO

            if (!ModelState.IsValid
                || viewModel.PictureFromBrowser == null || viewModel.PictureFromBrowser.Length == 0)
            {
                return View(viewModel);
            }

            var model = mapper.Map<PhotoModel>(viewModel);

            repository.AddPhoto(model);
            //return View(viewModel);
            return RedirectToAction("Index");
        }

        public IActionResult Exception()
        {
            throw new System.Exception("Ez egy példa arra, hogy elszáll a rendszer");
            //try
            //{
            //    throw new System.Exception("Ez egy példa arra, hogy elszáll a rendszer");
            //}
            //catch (Exception)
            //{
            //    return StatusCode(500);
            //}

        }
    }
}
