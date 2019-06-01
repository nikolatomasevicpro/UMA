using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMA.Web.Api.Controllers
{
    public class AngularTestingController : BaseController
    {
        public class TestUser
        {
            public string Id { get; set; }
            public string Login { get; set; }
        }

        public class GetUserQuery
        {
            public string Id { get; set; }
        }

        public class UpdateUserQuery
        {
            public string Id { get; set; }
            public string Login { get; set; }
        }

        public class AddUserQuery
        {
            public string Id { get; set; }
            public string Login { get; set; }
        }

        public class DeleteUserQuery
        {
            public string Id { get; set; }
            public string Login { get; set; }
        }

        public class SearchUserQuery
        {
            public string Filter { get; set; }
        }

        private List<TestUser> _users = new List<TestUser> {
            new TestUser { Id = "yop", Login = "poy" },
            new TestUser { Id = "foo", Login = "bar" },
            new TestUser { Id = "titi", Login = "toto" },
            new TestUser { Id = "1337", Login = "dev" },
            new TestUser { Id = "admin", Login = "admin" },
            new TestUser { Id = "too", Login = "much" },
        };

        [AllowAnonymous]
        [HttpGet]
        public List<TestUser> GetUsers()
        {
            return _users;
        }

        [AllowAnonymous]
        [HttpPost]
        public TestUser GetUser(GetUserQuery query)
        {
            return _users.FirstOrDefault(e => e.Id == query.Id);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult UpdateUser(UpdateUserQuery query)
        {
            var user = _users.FirstOrDefault(e => e.Id == query.Id);

            if (user != null)
            {
                user.Login = query.Login;
            }

            return Ok();
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddUser(AddUserQuery query)
        {
            var user = _users.FirstOrDefault(e => e.Id == query.Id);

            if (user == null)
            {
                _users.Add(new TestUser
                {
                    Id = query.Id,
                    Login = query.Login
                });
            }

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult DeleteUser(DeleteUserQuery query)
        {
            var user = _users.FirstOrDefault(e => e.Id == query.Id || e.Login == query.Login);

            if (user != null)
            {
                _users.Remove(user);
            }

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        public List<TestUser> SearchUser(SearchUserQuery query)
        {
            var users = _users.Where(e => e.Login.ToLowerInvariant().Contains(query.Filter.ToLowerInvariant())).ToList();

            return users ?? new List<TestUser>();
        }
    }
}
