using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N5SportsStore.Models.ViewModels
{
    /// <summary>
    /// Класс для передачи представлению отображающему содержание корзины необходимой информации, в частности,
    /// Обьекта Cart и URL для отображения в случае если пользователь щелкинет по кнопке ContinueSopping 
    /// </summary>
    public class CartIndexViewModel
    {
         public Cart Cart { get; set; }
         public string ReturnUrl { get; set; }
    }
}
