using System;
using System.Collections.Generic;
using System.Text;
using PartyInvites.Controllers;
using PartyInvites.Model;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace N13PartyInvites.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public  void ListActionFiltersNonAttendees() 
        {
            HomeController controller = new HomeController ( new FakeRepository());

            ViewResult result = controller.ListResponses();

            Assert.Equal(2, (result.Model as IEnumerable<GuestResponse>).Count());
        }
    }

    class FakeRepository : IRepository
    {
        public IEnumerable<GuestResponse> Responses =>
            new List<GuestResponse>
            {
                new GuestResponse {Name = "Bob", WillAttend = true},
                new GuestResponse {Name = "Alice", WillAttend = true},
                new GuestResponse {Name = "Joe", WillAttend = false}
            };
        public void AddResponse(GuestResponse response) 
        {
            throw new NotImplementedException();
        }
    }
}
