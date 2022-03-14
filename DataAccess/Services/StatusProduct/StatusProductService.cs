using Core.Interfaces.StatusProduct;
using Core.Models.StatusProduct;
using Core.Utilities.Handlers;
using DataAccess.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.StatusProduct
{
    public class StatusProductService : IStatusProductService
    {

       private readonly TechnicalTestITSenseContext _context;
        public StatusProductService(TechnicalTestITSenseContext context)
        {
            _context = context;
        }

        public async Task<List<StatusProductDTO>> GetSatusProduct()
        {
            List<StatusProductDTO> statusProductsDTO = await _context.StatusProducts.Select(x => new StatusProductDTO
            {
                IdStatusProduct = x.idStatusProduct,
                NameStatusProduct = x.nameStatusProduct
            }).ToListAsync();

            statusProductsDTO.Count.ListIfIsEmpty();
            return statusProductsDTO;
        }
    }
}
