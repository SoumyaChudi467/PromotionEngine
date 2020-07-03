using System.Collections.Generic;
using MediatR;

namespace PromotionEngine.Contracts
{
    public class RetrieveTotalUsingPromotionsRq : IRequest<RetrieveTotalUsingPromotionsRs>
    {
        public List<Product> Products { get; set; }
    }
}
