using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Repository.UserRepo
{
  public class UserRepository : IUserRepository
  {
    private readonly DesignMaterialDbContext _context;

    public UserRepository(DesignMaterialDbContext context)
    {
      _context = context;
    }

    public IEnumerable<User> GetAll()
    {
      return _context.Users.ToList();
    }

    public User GetById(Guid id)
    {
      return _context.Users.Find(id);
    }

    public void Insert(User user)
    {
      _context.Users.Add(user);
      Save();
    }

    public void Update(User user)
    {
      _context.Users.Update(user);
      Save();
    }

    public void Delete(Guid id)
    {
      var user = _context.Users.Find(id);
      _context.Users.Remove(user);
      Save();
    }

    public void Save()
    {
      _context.SaveChanges();
    }
  }
}
