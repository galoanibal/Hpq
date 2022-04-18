using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PRUEBA.QPH.API.Common;
using PRUEBA.QPH.API.Controllers;
using PRUEBA.QPH.API.Datos;
using PRUEBA.QPH.API.Entidades.Consultas;
using PRUEBA.QPH.API.Interfaces;

namespace PRUEBA.QPH.TEST
{
    [TestClass]
    public class ClientesTesting
    {
        [TestMethod]
        public void ClientesListar()
        {
            string connectionString = "";
            IClientes obj = new DatosClientes();

            ListarClienteRequest request = new ListarClienteRequest()
            {
                OffSet = 1,
                Limit = 2
            };
            List<ListarClienteResponse> response = new List<ListarClienteResponse>() { 
            new ListarClienteResponse() {
            IdCliente=1,
            Nombre="Galo Baque",
            Direccion="1234",
            Telefono="0987654321"
            },
            new ListarClienteResponse() {
            IdCliente=1,
            Nombre="Galo Baque",
            Direccion="1234",
            Telefono="0987654321"
            }};
            PageCollection<ListarClienteResponse> valorEsperado = new PageCollection<ListarClienteResponse>(response, request.Limit, 2);
            var mockRepo = new Mock<IClientes>();
            mockRepo.Setup(repo => repo.Listar(request, connectionString)).Returns(valorEsperado);

            ClientesController controller = new ClientesController(mockRepo.Object);
            ObjectResult valorRespondido = controller.Listar(request).Result as ObjectResult;

            //Assert - Verificacion
            var result = valorRespondido;
            Assert.IsTrue(result.StatusCode == 200);
        }
    }
}
