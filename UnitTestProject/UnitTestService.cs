using Microsoft.AspNetCore.Authentication;
using Moq;
using Newtonsoft.Json;
using UnitTestMoqFinal.Data;
using UnitTestMoqFinal.Models;
using UnitTestMoqFinal.Services;


namespace UnitTestProject
{
    public class UnitTestService
    {
        private readonly Mock<DbContextClass> dbContextClass;
        private readonly Mock<HttpClient> httpClient;
        public UnitTestService()
        {
            dbContextClass = new Mock<DbContextClass>();
            httpClient = new Mock<HttpClient>();
        }
        [Fact]
        public void GetPlaylist()
        {
            
        }
    }
}
