using System;

namespace WebAulaAPI.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }

        public int EnterpriseId { get; set; }
        public string Enterprise { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Description { get; set; }
    }
}
