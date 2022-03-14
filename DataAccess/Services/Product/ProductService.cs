using Core.Interfaces;
using Core.Models.Product;
using Core.Models.ResponseRequest;
using Core.Utilities.Handlers;
using DataAccess.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataAccess.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly TechnicalTestITSenseContext _context;


        public ProductService(TechnicalTestITSenseContext context)
        {
            _context = context;
        }

        public async Task<ResponseRequest> ChangeStateProduct(long idProduct, int idStatusProduct)
        {
            DataBase.Product product = await this._context.Products.Where(x => x.idProduct == idProduct).FirstOrDefaultAsync();

            product.ObjectIfIsNotNull();

            if (idStatusProduct == 2)
            {
                product.dateExitProduct = DateTime.Now;
            }
            else
            {
                product.dateExitProduct = null;
            }
               
             product.idStatusProduct = idStatusProduct;


            ResponseRequest responseRequest = new ResponseRequest();
            if (await this._context.SaveChangesAsync() == 0)
            {
                responseRequest.Success = false;
                responseRequest.Message = "Unsuccessful state change";
            }
            else
            {
                responseRequest.Success = true;
                responseRequest.Message = "Successful state change";
            }
            return responseRequest;
        }

        public async Task<ResponseRequest> CreateProduct(string nameProduct)
        {
            DataBase.Product product = new DataBase.Product()
            {
                nameProduct = nameProduct,
                idStatusProduct = 1,
                dateEntryProduct = DateTime.Now
        };
            _ = this._context.Products.AddAsync(product);

            ResponseRequest responseRequest = new ResponseRequest();
            if (await this._context.SaveChangesAsync() == 0)
            {
                responseRequest.Success = false;
                responseRequest.Message = "I don't believe product";
            }
            else
            {
                responseRequest.Success = true;
                responseRequest.Message = "The product was created";
            }
            return responseRequest;
        }

        public async Task<ProductDTO> GetProductById(long idProduct)
        {
            ProductDTO productDTO = await this._context.Products.Where(p => p.idProduct == idProduct).Select(x => new ProductDTO
            {
                IdProduct = x.idProduct,
                NameProduct = x.nameProduct,
                IdStatusProduct = x.idStatusProduct,
                DateEntryProduct = x.dateEntryProduct,
                DateExitProduct = x.dateExitProduct,
                NameStatusProduct = this._context.StatusProducts.Where
               (s => s.idStatusProduct == x.idStatusProduct).Select(s => s.nameStatusProduct).FirstOrDefault()

            }).FirstOrDefaultAsync();
            productDTO.ObjectIfIsNotNull();
            return productDTO;
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            List<ProductDTO> products = await this._context.Products.Select(x => new ProductDTO
            {
                IdProduct = x.idProduct,
                NameProduct = x.nameProduct,
                IdStatusProduct = x.idStatusProduct,
                DateEntryProduct = x.dateEntryProduct,
                DateExitProduct = x.dateExitProduct,
                NameStatusProduct = this._context.StatusProducts.Where
                (s => s.idStatusProduct == x.idStatusProduct).Select(s => s.nameStatusProduct).FirstOrDefault()
            }).OrderByDescending(x=> x.IdProduct).ToListAsync();

            products.Count.ListIfIsEmpty();
            return products;
        }

        public async Task<ResponseRequest> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            DataBase.Product product = await _context.Products.Where(x => x.idProduct == updateProductDTO.IdProduct).FirstOrDefaultAsync();
            product.ObjectIfIsNotNull();


            if (updateProductDTO.IdStatusProduct == 2)
            {
                product.dateExitProduct = DateTime.Now;
            }
            else
            {
                product.dateExitProduct = null;
            }

            product.nameProduct = updateProductDTO.NameProduct;
            product.idStatusProduct = updateProductDTO.IdStatusProduct;

            ResponseRequest responseRequest = new ResponseRequest();
            if (await this._context.SaveChangesAsync() == 0)
            {
                responseRequest.Success = false;
                responseRequest.Message = "The product was not updated";
            }
            else
            {
                responseRequest.Success = true;
                responseRequest.Message = "The product was updated";
            }
            return responseRequest;
        }
    }
}
