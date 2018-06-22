using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chat_2Ball.Models
{
    public class Users
    {
        [Key]
        public string Name { get; set; }

        public string ConnectionId { get; set; }
    }
}