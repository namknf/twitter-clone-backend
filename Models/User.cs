namespace Twitter_backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class User
    {
        public int id { get; set; }

        public string email { get; set; }

        public int password { get; set; }
    }
}
