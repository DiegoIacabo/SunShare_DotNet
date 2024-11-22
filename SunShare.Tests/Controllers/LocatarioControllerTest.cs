using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using SunShare.API.Controllers;
using SunShare.API.Requests;
using SunShare.Database;
using SunShare.Database.Models;
using SunShare.Repository;

namespace SunShare.API.Test.Controllers
{
    //public class LocatarioControllerTest
    //{

    //    private readonly Mock<IRepository<Locatario>> _locatarioMock;
    //    private readonly LocatarioController _locatarioController;
    //    private readonly Locatario _validLocatario;
    //    private readonly Locatario _invalidLocatario;


    //    public LocatarioControllerTest()
    //    {
    //        _locatarioMock = new Mock<IRepository<Locatario>>();
    //        _locatarioController = new LocatarioController(_locatarioMock.Object);

    //        _validLocatario = new Locatario(
    //            name: "Diego",
    //            cpf: "123.123.123-12",
    //            email: "diego@fiap.com",
    //            phoneNumber: "0000-0000",
    //            powerCompany: "ANEEL",
    //            averageUsage: 2000
    //        );

    //        _invalidLocatario = new Locatario(
    //            name: "",
    //            cpf: "123.123.123-12321312323131231",
    //            email: "joao@fiap.com",
    //            phoneNumber: "1111-1111",
    //            powerCompany: "ANEEL",
    //            averageUsage: 2000
    //         );

    //        [Fact]
    //        public void PostLocatario_WithValidFields_ReturnsOk()
    //        {

    //        }

    //        [Fact]
    //        public void PostLocatario_WithNullName_ReturnsBadRequest()
    //        {

    //        }
    //    }
    //}

    public class LocatarioControllerTest
    {
        private readonly Mock<IRepository<Locatario>> _locatarioMock;
        private readonly LocatarioController _locatarioController;

        public LocatarioControllerTest()
        {
            _locatarioMock = new Mock<IRepository<Locatario>>();
            _locatarioController = new LocatarioController(_locatarioMock.Object);
        }

        [Fact]
        public void PostLocatario_WithValidFields_ReturnsOk()
        {
            var locatarioRequest = new LocatarioRequest
            {
                Name = "Test Locatario",
                Cpf = "123.456.789-00",
                Email = "test@locatario.com",
                PhoneNumber = "123456789",
                PowerCompany = "123 Test Street",
                AverageUsage = 2000
            };

            _locatarioMock.Setup(r => r.Add(It.IsAny<Locatario>())).Verifiable();

            var result = _locatarioController.Post(locatarioRequest);
            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);

            _locatarioMock.Verify(r => r.Add(It.IsAny<Locatario>()), Times.Once);
        }

        [Fact]
        public void PostLocatario_WithNullName_ReturnsBadRequest()
        {
            var locatarioRequest = new LocatarioRequest
            {
                Name = null, 
                Cpf = "123.456.789-00",
                Email = "invalid@locatario.com",
                PhoneNumber = "987654321",
                PowerCompany = "123 Test Street",
                AverageUsage = 2000
            };

            var result = _locatarioController.Post(locatarioRequest);
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);  
        }
    }

}
