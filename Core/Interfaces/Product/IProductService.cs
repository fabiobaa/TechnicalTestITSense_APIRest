using Core.Models.Product;
using Core.Models.ResponseRequest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Core.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetProducts();
        Task<ResponseRequest> CreateProduct(string nameProduct);
        Task<ProductDTO> GetProductById(long idProduct);
        Task<ResponseRequest> UpdateProduct(UpdateProductDTO updateProductDTO);
        Task<ResponseRequest> ChangeStateProduct(long idProduct, int idStatusProduct);
    }
}
