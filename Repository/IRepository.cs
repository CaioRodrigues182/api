using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAulaAPI.Models;
using WebAulaAPI.DTO;

namespace WebAulaAPI.Repository
{
    public interface IRepository : IDisposable
    {
        List<Course> GetCourses();
        Course GetCourseById(int studentId);
        void InsertCourse(Course student);
        void DeleteCourse(int studentID);
        void UpdateCourse(Course student);
        void Save();
    }
}