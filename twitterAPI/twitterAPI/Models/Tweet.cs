using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace twitterAPI.Models
{
    public class Tweet
    {
        private DateTime _dateCreated;

        [Key]
        public int TweetId { get; set; }

        [Column(TypeName="nvarchar(500)")]
        public string TweetContent { get; set; }

        [Column(TypeName ="datetime")]
        public DateTime DateCreated { 
            get => _dateCreated; 
            set => _dateCreated = value.ToLocalTime(); 
        }
    }
}
