using StudentManagement.Data;
using StudentManagement.Interfaces.IData;
using StudentManagement.Interfaces.IServices;
using StudentManagement.Models;
using StudentManagement.Utilities;
using System;
using System.Collections.Generic;

namespace StudentManagement.Services
{
    internal class StudentService : IStudentService
    {
        private readonly IStudentData _studentData;
        public StudentService(IStudentData studentData)
        {
            _studentData = studentData;
        }
        public List<Student> GetAll()
        {
            return _studentData.GetAll();
        }

        public Student Create()
        {
            Student student = new Student();
            Console.Write("Code: ");
            student.Code = Console.ReadLine();
            Console.Write("Name: ");
            student.Name = Console.ReadLine();
            Console.Write("Age: ");
            student.Age = Convert.ToInt32(Console.ReadLine());
            _studentData.Add(student);
            return student;
        }

        public void ShowList(List<Student> student)
        {
            var t = new TablePrinter("Code", "Name", "Age");
            foreach (var s in student)
            {
                t.AddRow(s.Code, s.Name, s.Age);
            }
            t.Print();
        }
    }
}
