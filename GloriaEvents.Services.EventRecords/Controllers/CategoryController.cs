using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GloriaEvents.Services.EventComponent.Repository;
using GloriaEvents.Services.EventRecords.Models;
using Microsoft.AspNetCore.Mvc;

namespace GloriaEvents.Services.EventRecords.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
       

        [HttpGet]
       
        public async Task<ActionResult<IEnumerable<CatrgoriesDto>>> Get()
        {
            var result = await _categoryRepository.GetAllCategories();
            return Ok(_mapper.Map<List<CatrgoriesDto>>(result));
        }
    }
}