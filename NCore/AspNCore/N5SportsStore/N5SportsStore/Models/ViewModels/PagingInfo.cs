using System;
namespace N5SportsStore.Models.ViewModels
{
    /// <summary>
    /// Класс служащий передачейданных между контроллером и представлением
    /// В данном случае это нужно для поддержки функционала дескриптора, передачи представлению инфы о доступном кол-ве страниц
    /// 
    /// </summary>
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages =>
            (int) Math.Ceiling((decimal) TotalItems / ItemsPerPage);
    }
}