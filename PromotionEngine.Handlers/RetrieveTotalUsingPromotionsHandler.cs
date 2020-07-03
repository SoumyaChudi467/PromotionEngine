using MediatR;
using PromotionEngine.Contracts;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PromotionEngine.Contracts.Constants;

namespace PromotionEngine.Handlers
{
    public class RetrieveTotalUsingPromotionsHandler : IRequestHandler<RetrieveTotalUsingPromotionsRq, RetrieveTotalUsingPromotionsRs>
    {

        public async Task<RetrieveTotalUsingPromotionsRs> Handle(RetrieveTotalUsingPromotionsRq request,
            CancellationToken cancellationToken)
        {
            long total = 0;
            var response = new RetrieveTotalUsingPromotionsRs();

           
            foreach (var product in request.Products)
            {
                switch (product.SkuId)
                {
                    case "A": total += ProductAAndBPromotion(product.ProductCount, 130, 3, UnitPriceConstants.A);
                        break;
                    case "B":
                        total += ProductAAndBPromotion(product.ProductCount, 45, 2, UnitPriceConstants.B);
                        break;
                }

            }

            var c = request.Products.Where(x => x.SkuId == "C")?.Select(s => s.ProductCount).ToList();
            var d = request.Products.Where(x => x.SkuId == "D")?.Select(s => s.ProductCount).ToList();

            var productC = c.Any() ? c[0] : 0;
            var productD = d.Any() ? d[0] : 0;
            total += ProductCDPromotion(productC, productD);
            
            response.Total = total;
            return response;
        }

        private long ProductAAndBPromotion(int productCount, int discountPrice, int discountProductCount,
            int unitPrice)
        {
           var price = (productCount % discountProductCount) * unitPrice;
           var discount = (productCount / discountProductCount) * discountPrice;

           long total = price + discount;
   
            return total;
        }

        private long ProductCDPromotion(int productC, int productD)
        {
            long total = 0;
            if (productC > productD)
            {
                var c = productC - productD;
                total = (c * UnitPriceConstants.C) + (productD * 30);
            }
            else if (productD > productC)
            {
                var d = productD - productC;
                total = (d * UnitPriceConstants.C) + (productC * 30);
            }
            if (productC == 1 && productD == 1)
            {
                total = 30;
            }

            return total;
        }
    }
}
