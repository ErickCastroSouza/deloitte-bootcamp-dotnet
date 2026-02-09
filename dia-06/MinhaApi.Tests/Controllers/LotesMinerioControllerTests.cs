using System;
using MinhaApi.Controllers;
using Xunit;

namespace MinhaApi.Tests.Controllers
{
    public class LotesMinerioControllerTests
    {
        [Fact]
        public void PodeCriarInstancia()
        {
            var controller = new LotesMinerioController(null);
            Assert.NotNull(controller);
        }
    }
}