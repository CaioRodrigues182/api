using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAulaAPI.Models;
using WebAulaAPI.DTO;

namespace WebAulaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterpriseController : ControllerBase
    {
        // GET api/enterprise
        [HttpGet]
        public ActionResult<IEnumerable<CourseDTO>> Get()
        {
            var file = System.IO.File.ReadAllText("./data.json");
            var fileObj = Newtonsoft.Json.JsonConvert.DeserializeObject<Content>(file);

            var foundcourses = new List<CourseDTO>();
            foreach (var enterprise in fileObj.contents)
            {
                foreach (var course in enterprise.Courses)
                {   
                    foundcourses.Add(new CourseDTO() { Id = course.Id, Description = course.Description, Enterprise = enterprise.Company, EnterpriseId = enterprise.Id, Quantity = course.Quantity, Status = course.Status, Name = course.Name });
                }
            }

            return foundcourses;
        }
        

        // GET api/enterprise/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/course
        [HttpPost]
        public void Post([FromBody] CourseDTO course)
        {
        }

        // PUT api/course/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/course/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
