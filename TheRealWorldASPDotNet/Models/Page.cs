using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TheRealWorldASPDotNet.Models
{
    public class Page
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        //[MaxLength(255)]
        public string Title { get; set; }

        public virtual Page Parent { get; set; }

        public virtual ICollection<ContentElement> ContentElements { get; set; }
    }
}
