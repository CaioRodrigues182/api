using System;
using System.Collections.Generic;

namespace WebAulaAPI.Models
{
    public class Enterprise
    {
        public int Id { get; set; }
        public string Company { get; set; }

        public IList<Course> Courses { get; set; }
       
    }
}
