using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamProject.DataObjects
{
    public sealed class Applications
    {
        private List<Application> _app;
        public List<Application> app
        {
            get
            {
                if (_app == null)
                    _app = new List<Application>();
                return _app;
            }
            set { _app = value; }
        }
    }
}
