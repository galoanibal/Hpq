using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PRUEBA.QPH.API.Common;
using PRUEBA.QPH.API.Controllers;
using PRUEBA.QPH.API.Datos;
using PRUEBA.QPH.API.Entidades.Consultas;
using PRUEBA.QPH.API.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRUEBA.QPH.TEST
{
    [TestClass]
    public class CuentasTesting
    {
        [TestMethod]
        public void ListarCuentas()
        {
            string connectionString = "";
            ICuentas obj = new DatosCuentas();

            ListarCuentasRequest request = new ListarCuentasRequest()
            {
                OffSet = 1,
                Limit = 2
            };
            List<ListarCuentasResponse> response = new List<ListarCuentasResponse>() { new ListarCuentasResponse() {
                IdCliente=1,
               IdCuenta=1,
               NumeroCuenta="001",              
               Saldo=1000
            },
            new ListarCuentasResponse() {
            IdCliente=2,
           IdCuenta=2,
           NumeroCuenta="002",          
           Saldo=10000
            } };
            PageCollection<ListarCuentasResponse> valorEsperado = new PageCollection<ListarCuentasResponse>(response, request.Limit, 1);
            var mockRepo = new Mock<ICuentas>();
            mockRepo.Setup(repo => repo.Listar(request, connectionString)).Returns(Task.FromResult(valorEsperado));

            CuentasController controller = new CuentasController(mockRepo.Object);
            ObjectResult valorRespondido = controller.Listar(request).Result.Result as ObjectResult;

            //Assert - Verificacion
            var result = valorRespondido;
            Assert.IsTrue(result.StatusCode == 200);
        }
    }
}
