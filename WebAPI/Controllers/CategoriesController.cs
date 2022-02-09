using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController:ControllerBase
    {
        ICategoryService _categortService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categortService = categoryService;
        }
       
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categortService.GetAll();
            if (result.Success==true) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



    }
}
