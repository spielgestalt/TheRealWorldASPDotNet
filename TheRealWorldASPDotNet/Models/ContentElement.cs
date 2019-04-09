using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TheRealWorldASPDotNet.Models
{
    public class ContentElement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        //[MaxLength(255)]
        public string Content { get; set; }

        public virtual Page Parent { get; set; }
    }
}
