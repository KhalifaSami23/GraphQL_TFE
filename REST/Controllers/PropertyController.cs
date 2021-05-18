using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFE_Khalifa_Sami_2021.DAL;
using TFE_Khalifa_Sami_2021.Models;
using TFE_Khalifa_Sami_2021.REST.Repositories;

namespace TFE_Khalifa_Sami_2021.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PropertyController : Controller
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        [HttpGet]
        public ActionResult GetProperties()
        {
            return Ok(_propertyRepository.GetProperties());
        }
        
        [HttpGet("getById/{id}")]
        public IActionResult GetPropertyById(int id)
        {
            return Ok(_propertyRepository.GetPropertyById(id));
        }
        
        [HttpPost]
        public IActionResult PostProperty(Property property)
        {
            _propertyRepository.PostProperty(property);
            return Ok(property);
        }
        
        [HttpPut]
        public IActionResult UpdateProperty(Property property)
        {
            _propertyRepository.UpdateProperty(property);
            return Ok(property);
        }
        
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteProperty(int id)
        {
            _propertyRepository.DeleteProperty(id);
            return Ok($"{id} Removed ! ");
        }
    }
}