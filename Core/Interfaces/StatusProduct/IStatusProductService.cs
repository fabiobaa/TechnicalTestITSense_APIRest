using Core.Models.StatusProduct;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.StatusProduct
{
    public interface IStatusProductService
    {
        Task<List<StatusProductDTO>> GetSatusProduct();
    }
}
