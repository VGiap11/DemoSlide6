using DemoSlide6.API.AppDbContext;
using DemoSlide6.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace DemoSlide6.API.IRepositoryStudent.RepositoryStudent
{
    public class StudentRepository : IStudentRepository
    {  
        private readonly AppDbContexts _appDbContexts ;

        public StudentRepository( AppDbContexts appDbContexts) {
            this._appDbContexts = appDbContexts ;
        }
        public Student GetByID(int id)
        {
            var findStudentById = _appDbContexts.Students.FirstOrDefault(x=> x.Id == id);
            if(findStudentById == null )
            {
                return null;
            }
            return findStudentById;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _appDbContexts.Students.ToList();
        }

        public Student AddStudent(Student student)
        {
            try
            {
                _appDbContexts.Students.Add(student);
                _appDbContexts.SaveChanges();
                return student;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void DeleteStudent(int id)
        {
            var deleteStudentId = _appDbContexts.Students.FirstOrDefault(x=>x.Id == id);
            try
            {
                _appDbContexts.Remove(deleteStudentId);
                _appDbContexts.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Student UpdateStudent([FromForm]Student student)
        {
            try
            {
                _appDbContexts.Update(student);
                _appDbContexts.SaveChanges();
                return student;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
