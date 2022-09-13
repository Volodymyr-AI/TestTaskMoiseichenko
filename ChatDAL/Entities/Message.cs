using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatDAL.Entities
{
    public class Message
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; }

        public int? ChatId { get; set; }
        public Chat Chat { get; set; }

        [Required]
        public int OwnerId { get; set; }
        public User Owner { get; set; }

        [Required]
        public int SenderId { get; set; }       
        public User Sender { get; set; }

        public int? ReceiverId { get; set; }        
        public User Receiver { get; set; }

        [Required]
        public DateTime SendTime { get; set; }

        [Required]
        public bool IsEdited { get; set; }

        [Required]
        public bool IsDeletedForMe { get; set; }
    }
}
