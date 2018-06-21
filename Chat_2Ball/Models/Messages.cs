using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Chat_2Ball.Models
{
    public class Messages
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public byte?[] Image { get; set; }

        [Required, ForeignKey("Users")]
        public string UsersId { get; set; }
        public virtual Users Users { get; set; }
    }
}