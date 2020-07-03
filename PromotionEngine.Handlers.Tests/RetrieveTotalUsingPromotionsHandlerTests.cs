using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Contracts;


namespace PromotionEngine.Handlers.Tests
{
    [TestClass]
    public class RetrieveTotalUsingPromotionsHandlerTests
    {
        private RetrieveTotalUsingPromotionsHandler _handler;
        private RetrieveTotalUsingPromotionsRq _request;

        [TestInitialize]
        public void TestInitialize()
        {
            _handler = new RetrieveTotalUsingPromotionsHandler();
        }

        [TestMethod]
        public async Task WhenHandlerMethodISCalled_ReturnSuccess()
        {
            var product = new List<Product>
            {
                new Product{ProductCount = 5, SkuId = "A"},
                new Product{ProductCount = 5, SkuId = "B"},
                new Product{ProductCount = 1, SkuId = "C"},
                new Product{ProductCount = 1, SkuId = "D"},
            };
            _request = new RetrieveTotalUsingPromotionsRq
            {
                Products = product
            };
            var result = await _handler.Handle(_request, CancellationToken.None);

            Assert.AreEqual(380, result.Total);
        }

        [TestMethod]
        public async Task WhenHandlerMethodISCalled_ScenarioA_ReturnSuccess()
        {
            var product = new List<Product>
            {
                new Product{ProductCount = 1, SkuId = "A"},
                new Product{ProductCount = 1, SkuId = "B"},
                new Product{ProductCount = 1, SkuId = "C"},
            };
            _request = new RetrieveTotalUsingPromotionsRq
            {
                Products = product
            };
            var result = await _handler.Handle(_request, CancellationToken.None);

            Assert.AreEqual(100, result.Total);
        }

        [TestMethod]
        public async Task WhenHandlerMethodISCalled_ScenarioB_ReturnSuccess()
        {
            var product = new List<Product>
            {
                new Product{ProductCount = 5, SkuId = "A"},
                new Product{ProductCount = 5, SkuId = "B"},
                new Product{ProductCount = 1, SkuId = "C"},
            };
            _request = new RetrieveTotalUsingPromotionsRq
            {
                Products = product
            };
            var result = await _handler.Handle(_request, CancellationToken.None);

            Assert.AreEqual(370, result.Total);
        }

        [TestMethod]
        public async Task WhenHandlerMethodISCalled_ScenarioC_ReturnSuccess()
        {
            var product = new List<Product>
            {
                new Product{ProductCount = 3, SkuId = "A"},
                new Product{ProductCount = 5, SkuId = "B"},
                new Product{ProductCount = 1, SkuId = "C"},
                new Product{ProductCount = 1, SkuId = "D"},
            };
            _request = new RetrieveTotalUsingPromotionsRq
            {
                Products = product
            };
            var result = await _handler.Handle(_request, CancellationToken.None);

            Assert.AreEqual(280, result.Total);
        }
    }
}
