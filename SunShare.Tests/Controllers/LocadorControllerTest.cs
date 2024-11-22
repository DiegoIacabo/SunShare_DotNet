using Microsoft.AspNetCore.Mvc;
using Moq;
using SunShare.API.Controllers;
using SunShare.API.Requests;
using SunShare.Database.Models;
using SunShare.Repository;

namespace SunShare.API.Test.Controllers
{
    public class LocadorControllerTest
    {
        private readonly Mock<IRepository<Locador>> _locadorMock;
        private readonly LocadorController _locadorController;
        private readonly Locador _validCPFLocador;
        private readonly Locador _invalidCPFLocador;

        public LocadorControllerTest()
        {
            _locadorMock = new Mock<IRepository<Locador>>();
            _locadorController = new LocadorController(_locadorMock.Object);

            _validCPFLocador = new Locador(
                name: "Diego",
                cpf: "123.123.123-12",
                email: "diego@fiap.com",
                phoneNumber: "0000-0000",
                powerCompany: "ANEEL",
                averageProduction: 2000,
                availableEnergy: 2000
            );

            _invalidCPFLocador = new Locador(
                name: "João",
                cpf: "123.123.123-12321312323131231",
                email: "joao@fiap.com",
                phoneNumber: "1111-1111",
                powerCompany: "ANEEL",
                averageProduction: 2000,
                availableEnergy: 2000);
        }

        [Fact]
        public void PostLocador_WithValidCPF_ReturnsOk()
        {
            _locadorMock.Setup(repo => repo.Add(It.IsAny<Locador>())).Verifiable();

            var result = _locadorController.Post(new LocadorRequest
            {
                Name = _validCPFLocador.Name,
                Cpf = _validCPFLocador.Cpf,
                Email = _validCPFLocador.Email,
                PhoneNumber = _validCPFLocador.PhoneNumber,
                PowerCompany = _validCPFLocador.PowerCompany,
                AverageProduction = _validCPFLocador.AverageProduction,
                AvailableEnergy = _validCPFLocador.AvailableEnergy
            });

            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void PostLocador_WithInvalidCPF_ReturnsBadRequest()
        {
            _locadorMock.Setup(repo => repo.Add(It.IsAny<Locador>())).Verifiable();

            var result = _locadorController.Post(new LocadorRequest
            {
                Name = _invalidCPFLocador.Name,
                Cpf = _invalidCPFLocador.Cpf,
                Email = _invalidCPFLocador.Email,
                PhoneNumber = _invalidCPFLocador.PhoneNumber,
                PowerCompany = _invalidCPFLocador.PowerCompany,
                AverageProduction = _invalidCPFLocador.AverageProduction,
                AvailableEnergy = _invalidCPFLocador.AvailableEnergy
            });

            var badRequestResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

    }
}
