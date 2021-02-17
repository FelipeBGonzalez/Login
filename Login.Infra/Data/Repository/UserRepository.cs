using Login.Domain.Interfaces;
using Login.Domain.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Login.Infra.Data.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly ApiContext3 _contexto;

        public UserRepository(ApiContext3 contexto)
        {
            _contexto = contexto;
        }     

        public UserDomain Me(string id)
        {
            var pedidoR = _contexto.User.Include(u => u.phones).ToArray();
            if (_contexto.User.Where(x => x.id == id).ToList().Count > 0)
            {
                return _contexto.User.Where(x => x.id == id).First();
            }

            return new UserDomain();
        }   

        public UserDomain Signin(string email, string password)
        {
            var pedidoR = _contexto.User.Include(u => u.phones).ToArray();
            if (_contexto.User.Where(x => x.email == email).Where(y => y.password == password).ToList().Count > 0)
            {
                return _contexto.User.Where(x => x.email == email).Where(y=> y.password == password).First();
            }

            return new UserDomain();
        }

        public void SignUp(UserDomain user)
        {
            _contexto.User.Add(user);
            _contexto.SaveChanges();
        }

        public void UpdateToken(UserDomain user)
        {
            _contexto.User.Update(user);
            _contexto.SaveChanges();
        }

        public bool EmailExists(string email)
        {            
            if (_contexto.User.Where(x => x.email == email).ToList().Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
