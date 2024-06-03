using DemoSlide6.API.AppDbContext;
using DemoSlide6.API.Model;

namespace DemoSlide6.API.IRepositoryLopHoc.RepositoryLopHoc
{
    public class LopHocRepository : ILopHocRepository
    {
        private readonly AppDbContexts _appDbContexts;
        public LopHocRepository(AppDbContexts appDbContexts) { 
            this._appDbContexts = appDbContexts;
        }

        public LopHoc AddLopHoc(LopHoc lopHoc)
        {
            try
            {
                _appDbContexts.LopHoc.Add(lopHoc);
                _appDbContexts.SaveChanges();
                return lopHoc;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteLopHoc(int id)
        {
            var findIdDelete = _appDbContexts.LopHoc.FirstOrDefault(l => l.Id == id);
            try
            {
                _appDbContexts.LopHoc.Remove(findIdDelete);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<LopHoc> GetAllLopHocs()
        {
            return _appDbContexts.LopHoc.ToList();
        }

        public LopHoc GetByIDLopHoc(int id)
        {
            var findById = _appDbContexts.LopHoc.FirstOrDefault(l=>l.Id == id);
            try
            {
                if (findById ==null)
                {
                    return null;
                }
                else
                {
                    return findById;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LopHoc UpdateLopHoc(LopHoc lopHoc)
        {
            var findIdUpdate = _appDbContexts.LopHoc.FirstOrDefault(l=>l.Id == lopHoc.Id);
            try
            {
                if (findIdUpdate == null)
                {
                    return null;
                }
                else
                {
                    _appDbContexts.LopHoc.Update(lopHoc);
                    _appDbContexts.SaveChanges();
                    return findIdUpdate;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
