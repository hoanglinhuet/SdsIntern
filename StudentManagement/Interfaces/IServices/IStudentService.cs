using StudentManagement.Models;
using System.Collections.Generic;

namespace StudentManagement.Interfaces.IServices
{
    internal interface IStudentService
    {
        List<Student> GetAll();
        Student Create();
        void ShowList(List<Student> student);
    }
}
