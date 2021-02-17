using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Login.Domain.Interfaces;
using Login.Domain.Models;
using Login.Domain.Service;
using Xunit;
using Login.Domain.Test;
using System.Linq;
namespace Login.Domain.Test
{
	public class PedidoTest: DomainTestBase
	{

        [Theory]
        [InlineData()] 
        public void TestSignUp()
        {
            UserDomain user = new UserDomain();
            user.firstName = "Felipe";
            user.lastName = "Gonzalez";
            user.email = "felipebgonzalez@hotmail.com";
            user.password = "123";
            PhoneDomain phone = new PhoneDomain();
            phone.area_code = 13;
            phone.number = 981242254;
            phone.country_code= "+55";
            user.phones.Add(phone);


            var domain = provider.GetService<ISignUpDomain>();
            domain.Execute(user);
            Assert.Equal(user.firstName, user.firstName);
        }

        [Theory]
        [InlineData()]
        public void TestSingIn()
        {
            var domain = provider.GetService<ISignInDomain>();
            var user = domain.Execute("felipebgonzalez@hotmail.com","123");
            Assert.Equal(user.email, "felipebgonzalez@hotmail.com");
        }
    }
}
