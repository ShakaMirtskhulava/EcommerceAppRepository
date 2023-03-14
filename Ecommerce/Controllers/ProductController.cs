﻿using Ecommerce.Data;
using Ecommerce.Helpers;
using Ecommerce.Models;
using Ecommerce.Services;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductsRepository _productsRepository;


        public ProductController(AppDbContext dbContext, IProductsRepository productsRepository)
        {
			_productsRepository = productsRepository;
		}


		[HttpGet]
        public IActionResult Index()
		{
			var products = _productsRepository.GetProductsFully();
			if(products == null)
			{
				var errorVM = new ErrorViewModel()
				{
					Message = "There is not a product in the database"
				};

				return RedirectToAction("ErrorPage", "Errors", errorVM);
			}

			var VM = new IndexVM
			{
				Products = products
			};

			return View(VM);
		}

		[HttpGet]
		public async Task<IActionResult> ProductPage(int productId)
		{
			var targetProduct = await _productsRepository.GetFullProductById(productId);
			if (targetProduct == null)
			{
                var errorVM = new ErrorViewModel()
                {
                    Message = "Product is not found in the database"
                };

                return RedirectToAction("ErrorPage", "Errors", errorVM);
            }

			var VM = new ProductPageVM
			{
				Product = targetProduct,
			};


            return View(VM);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ProductPage(ProductPageVM VM)
		{



			return NotFound();
		}

		[HttpGet]
		public IActionResult ValidateQuantityAgainstStockQuantity(int productId,int givenQuantity)
		{
			var stockQuantity = _productsRepository.GetStockQuantity(productId);
            if (stockQuantity == null)
            {
                var errorVM = new ErrorViewModel()
                {
                    Message = "Product is not found in the database"
                };

                return RedirectToAction("ErrorPage", "Errors", errorVM);
            }


            if (givenQuantity > stockQuantity)
				return Json(new { success = false });
			
			return Json(new { success = true });
        }
	}
}
