using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVC.Handlers
{
    public class SessionManager
    {
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor accessor)
        {
            _session = accessor.HttpContext.Session;
        }

        public CurrentUser CurrentUser
        {
            get
            {
                if (_session.GetString(nameof(CurrentUser)) is null) return null;
                return JsonSerializer.Deserialize<CurrentUser>(_session.GetString(nameof(CurrentUser)));
            }

            set
            {
                _session.SetString(nameof(CurrentUser), JsonSerializer.Serialize(value)); 
            }
        }
    }
}
