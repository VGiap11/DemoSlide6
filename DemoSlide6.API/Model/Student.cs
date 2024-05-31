using System.ComponentModel.DataAnnotations;

namespace DemoSlide6.API.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string MaSV { get; set; }
    }
}
