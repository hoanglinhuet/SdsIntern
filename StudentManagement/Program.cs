using StudentManagement.Models;
using StudentManagement.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.Unicode;
                //Console.InputEncoding = Encoding.UTF8;
                StudentService studentService = new StudentService();
                List<Student> students = studentService.GetAll();
                while (true)
                {
                    Console.WriteLine("1. Thêm sinh viên");
                    Console.WriteLine("2. Danh sách sinh viên");
                    Console.Write("Chọn chức năng: ");
                    string feature = Console.ReadLine();
                    switch (feature)
                    {
                        case "1":
                            students.Add(studentService.Create());
                            break;
                        case "2":
                            studentService.ShowList(students);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cmnr: " + ex.Message);
            }
            Console.ReadLine();
        }
    }
}
