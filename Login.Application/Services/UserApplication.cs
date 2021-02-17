using Login.Application.ViewModels;
using Login.Domain.Interfaces;
using Login.Domain.Models;
using System.Collections.Generic;
using Login.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Login.Application.Services
{  
    public class UserApplication : ApplicationBase, IUserApplication
    {   

        public void SignUp(vmUser user)
        {
            var domain = GetService<ISignUpDomain>();
            domain.Execute(ConvertToModelView(user));
        }

        public vmUser Signin(string email, string password)
        {
            var domain = GetService<ISignInDomain>();
           return ConvertToViewModel(domain.Execute(email,password));
        }

        public vmUser Me(string id)
        {
            var domain = GetService<IMeDomain>();
            return ConvertToViewModel(domain.Execute(id));
        }

        private static vmUser ConvertToViewModel(UserDomain d)
        {
            vmUser vmUser = new vmUser();
            vmPhone vmPhone;

            vmUser.firstName = d.firstName;
            vmUser.lastName = d.lastName;
            vmUser.email = d.email;
            vmUser.password = d.password;

            foreach (var item in d.phones)
            {
                vmPhone = new vmPhone();
                vmPhone.number = item.number;
                vmPhone.area_code = item.area_code;
                vmPhone.country_code = item.country_code;
                vmUser.phones.Add(vmPhone);
            }
            vmUser.token = d.token;
            vmUser.create_ate = d.create_ate;
            vmUser.last_login = d.last_login;

            return vmUser;
        }
        private static UserDomain ConvertToModelView(vmUser v)
        {

            UserDomain userDomain = new UserDomain();
            PhoneDomain phoneDomain;

            userDomain.firstName = v.firstName;
            userDomain.lastName = v.lastName;
            userDomain.email = v.email;
            userDomain.password = v.password;
            userDomain.id = userDomain.email;

            foreach (var item in v.phones)
            {
                phoneDomain = new PhoneDomain();
                phoneDomain.number = item.number;
                phoneDomain.area_code = item.area_code;
                phoneDomain.country_code = item.country_code;
                phoneDomain.id = item.number.ToString() + item.area_code.ToString() + item.country_code;

                userDomain.phones.Add(phoneDomain);
            }

            return userDomain;
        }
    }
}
