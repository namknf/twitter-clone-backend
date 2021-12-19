namespace Twitter_backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class Profile
    {
        public string Name { get; set; }

        public string NickName { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; }
    }
}
