using DemoSlide6.API.Model;

namespace DemoSlide6.API.IRepositoryStudent
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student GetByID(int id);
        Student AddStudent(Student student);
        Student UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
