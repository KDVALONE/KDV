using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N5SportsStore.Infrastructure;
using N5SportsStore.Models;
using N5SportsStore.Models.ViewModels;

namespace N5SportsStore.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private Cart cart;
        public CartController(IProductRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }


        /// <summary>
        /// Метод действия Index() извлекает обьект Cart из состояния сеанса и использует его при создании обьекта CartIndexViewModel,
        /// который затем передается методу View() для применения в качестве модели пердставления.
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId,string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if(product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
