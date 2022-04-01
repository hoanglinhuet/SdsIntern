using StudentManagement.Models;
using System.Collections.Generic;

namespace StudentManagement.Interfaces.IData
{
    internal interface IStudentData
    {
        void Add(Student student);
        List<Student> GetAll();
    }
}
