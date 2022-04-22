using System.ComponentModel.DataAnnotations;
namespace PartyInvites.Model
{
    public class GuestResponse
    {
        public int id {get;set;}
        //ввести данные
        [Required(ErrorMessage= "Please enter your name")] 
        public string Name {get;set;}
        [RegularExpression(".+\\@.+\\..+", ErrorMessage ="please enter a valid email address")] 
        public string Email {get;set;}
        [Required(ErrorMessage = "Please enter your phone number")] 
        public string Phone {get; set;}
        [Required(ErrorMessage = "Please specify wheater you'll attend")]
        public bool? WillAttend{get;set;}
    }

}