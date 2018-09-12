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
    public class CourseController : ControllerBase
    {
        // GET api/course
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
                    if (course.Status == "Active") {
                        foundcourses.Add(new CourseDTO() { Id = course.Id, Description = course.Description, Enterprise = enterprise.Company, EnterpriseId = enterprise.Id, Quantity = course.Quantity, Status = course.Status, Name = course.Name });
                    }
                }
            }

            return foundcourses;
        }
        

        // GET api/course/5
        [HttpGet("{id}")]
        public ActionResult<CourseDTO> Get(int id)
        {
            var file = System.IO.File.ReadAllText("./data.json");
            var fileObj = Newtonsoft.Json.JsonConvert.DeserializeObject<Content>(file);

            // Modificar conteúdo do objeto.
            var company = fileObj.contents.Where(x => x.Id == id).First();
            Console.WriteLine(company);
            var course = new CourseDTO();

            return course;
        }

        // POST api/course
        [HttpPost]
        public void Post([FromBody] CourseDTO course)
        {
            var file = System.IO.File.ReadAllText("./data.json");
            var fileObj = Newtonsoft.Json.JsonConvert.DeserializeObject<Content>(file);
            var enterprise = fileObj.contents.Where(x => x.Id == course.EnterpriseId).FirstOrDefault();
            enterprise.Courses.Add(new Course() { Id = course.Id, Status = course.Status, Name = course.Name, Quantity = course.Quantity, Description = course.Description });
            var fileSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(fileObj);
            System.IO.File.WriteAllText("./data.json", fileSerialized);
        }

        // PUT api/course/5
        [HttpPut("{id_company}/{id_course}")]
        public void Put(int id_company, int id_course, [FromBody] CourseDTO course)
        {
            var file = System.IO.File.ReadAllText("./data.json");
            var fileObj = Newtonsoft.Json.JsonConvert.DeserializeObject<Content>(file);

            var enterprise = fileObj.contents.Where(x => x.Id == id_company).FirstOrDefault();
            Course obj = null;
            obj = enterprise.Courses.Where(x => x.Id == id_course).LastOrDefault();
            enterprise.Courses.Remove(obj);

            if (enterprise.Id != course.EnterpriseId) {
                var newEnterprise = fileObj.contents.Where(x => x.Id == course.EnterpriseId).FirstOrDefault();
                newEnterprise.Courses.Add(new Course() { Id = course.Id, Status = course.Status, Name = course.Name, Quantity = course.Quantity, Description = course.Description });
            }
            else {
                enterprise.Courses.Add(new Course() { Id = course.Id, Status = course.Status, Name = course.Name, Quantity = course.Quantity, Description = course.Description });
            }

            var fileSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(fileObj);
            System.IO.File.WriteAllText("./data.json", fileSerialized);

        }

        // DELETE api/course/5/5
        [HttpDelete("{id_company}/{id_course}")]
        public void Delete(int id_company, int id_course)
        {
            var file = System.IO.File.ReadAllText("./data.json");
            var fileObj = Newtonsoft.Json.JsonConvert.DeserializeObject<Content>(file);

            var enterprise = fileObj.contents.Where(x => x.Id == id_company).FirstOrDefault();
            var obj = enterprise.Courses.Where(x => x.Id == id_course).FirstOrDefault();
            
            obj.Status = "Inative";

            var fileSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(fileObj);
            System.IO.File.WriteAllText("./data.json", fileSerialized);
        }
    }
}
