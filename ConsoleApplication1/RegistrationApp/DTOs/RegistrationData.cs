using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp.DTOs
{
    public class RegistrationData
    {
        private string name;

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public string Email { get; set; }

        public int Age { get; set; }
    }
}
