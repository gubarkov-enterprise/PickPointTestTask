using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PickPointTestTask.Models.ViewModels;
using PickPointTestTask.Services;

namespace PickPointTestTask.Controllers
{
    [ApiController]
    [Route("api/postamats")]
    public class PostamatsController : ControllerBase
    {
        private readonly IPostamatService _postamatService;

        public PostamatsController(IPostamatService postamatService)
        {
            _postamatService = postamatService;
        }

        [HttpGet]
        public Task<List<PostamatViewModel>> Get() => _postamatService.GetAllPostamats();
    }
}