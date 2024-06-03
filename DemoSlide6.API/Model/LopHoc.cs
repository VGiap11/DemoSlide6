using System.ComponentModel.DataAnnotations;

namespace DemoSlide6.API.Model
{
    public class LopHoc
    {
        [Key]
        public int Id {  get; set; }
        public string ClassName { get; set; }
        public string Description { get; set; }
    }
}
