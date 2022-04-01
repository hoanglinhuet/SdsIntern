using Newtonsoft.Json;
using StudentManagement.Interfaces.IData;
using StudentManagement.Models;
using System.Collections.Generic;
using System.IO;

namespace StudentManagement.Data
{
    internal class StudentFileData : IStudentData
    {
        private string _folderPath;
        private string _filePath;
        public StudentFileData()
        {
            _folderPath = Path.Combine(Directory.GetCurrentDirectory(), "FilesData");
            _filePath = Path.Combine(_folderPath, "student.json");
        }
        public void Add(Student student)
        {
            if (!Directory.Exists(_folderPath))
                Directory.CreateDirectory(_folderPath);
            File.AppendAllLines(_filePath, new[] { JsonConvert.SerializeObject(student) });
        }

        public List<Student> GetAll()
        {
            var result = new List<Student>();
            if (File.Exists(_filePath))
            {
                var studentStr = File.ReadAllLines(_filePath);
                foreach (var item in studentStr)
                {
                    result.Add(JsonConvert.DeserializeObject<Student>(item));
                }
            }
            return result;
        }
    }
}
