using DemoSlide6.API.Model;

namespace DemoSlide6.API.IRepositoryLopHoc
{
    public interface ILopHocRepository
    {
        IEnumerable<LopHoc> GetAllLopHocs();
        LopHoc GetByIDLopHoc(int id);
        LopHoc AddLopHoc(LopHoc lopHoc);
        LopHoc UpdateLopHoc(LopHoc lopHoc);
        void DeleteLopHoc(int id);
    }
}
