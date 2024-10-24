using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Repository.UserRepo
{
  public interface IUserRepository
  {
    IEnumerable<User> GetAll();
    User GetById(Guid id);
    void Insert(User user);
    void Update(User user);
    void Delete(Guid id);
    void Save();
  }
}
