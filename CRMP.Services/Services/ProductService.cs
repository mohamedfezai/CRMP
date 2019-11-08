using CRMP.Data.Infrastructure;
using CRMP.Domain.Entities;
using CRMP.Services.IServices;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMP.Services.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(Factory);

        public ProductService() : base(UTK)
        {

        }

        

        public IEnumerable<Product> DeuxProduit()
        {
            var c = GetAll().OrderBy(p => p.prodQuantity).Take(2);
            /*foreach (var item in c)
            {
                
                //Console.WriteLine(" code de produit " + item.ProductId + " Nom de produit" + item.Name);
            }*/
            return c;
        }
    }
}
