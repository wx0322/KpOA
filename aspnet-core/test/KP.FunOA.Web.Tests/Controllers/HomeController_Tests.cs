using System.Threading.Tasks;
using KP.FunOA.Models.TokenAuth;
using KP.FunOA.Web.Controllers;
using Shouldly;
using Xunit;

namespace KP.FunOA.Web.Tests.Controllers
{
    public class HomeController_Tests: FunOAWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}