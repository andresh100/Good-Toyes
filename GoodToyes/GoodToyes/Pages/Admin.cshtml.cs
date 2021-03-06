using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodToyes.Models;
using GoodToyes.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoodToyes.Pages
{
    [Authorize]
    public class AdminModel : PageModel
    {
        private IProduct _product;

        public AdminModel(IProduct product)
        {
            _product = product;
        }

        /// <summary>
        /// Deletes a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task OnPostDelete(int id)
        {
            await _product.DeleteProduct(id);
        }

        /// <summary>
        /// creates a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task OnPostCreateProduct(string url, decimal price, string name)
        {
            Product product = new Product();

            product.Name = name;

            product.Price = price;

            product.Image = url;

            await _product.CreateProduct(product);
        }

        /// <summary>
        /// updates product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>updated product</returns>
        public async Task OnPostUpdateProduct(int id, string url, decimal price, string name)
        {
            var product = await _product.GetProduct(id);

            product.Name = name;

            product.Price = price;

            product.Image = url;

            await _product.UpdateProduct(product);
        }

        /// <summary>
        /// Redirects to page that displays last 10 orders
        /// </summary>
        /// <returns>View</returns>
        public IActionResult OnPostTenOrders()
        {
            return RedirectToAction("Index", "Order");
        }
        public void OnGet()
        {
        }


    }
}