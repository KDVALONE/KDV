using System.Collections.Generic;


namespace PartyInvites.Model
{
    ///Для шаблона репозиторий для подключения к БД
 public interface IRepository
 {
     IEnumerable<GuestResponse> Responses {get;}
     void AddResponse(GuestResponse response);
 }

}