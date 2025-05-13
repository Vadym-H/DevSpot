﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevSpot.Models
{
    public class JobPosting
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description  { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string Lacation { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.UtcNow;
        public bool IsApproved { get; set; } = false;
        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
    }
}
