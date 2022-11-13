using eshop.Models;

namespace eshop.Repositories
{
    public class LoginRepository
    {
        private readonly MyContext context = new();

        public Login FindByEmail(string email)
        {
            return context.TbLogins.Find(email);
        }

        public void Create(Login login)
        {
            context.TbLogins.Add(login);
            context.SaveChanges();
        }
    }
}
