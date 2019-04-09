using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TheRealWorldASPDotNet.Models
{
    [Serializable]
    public class Page
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [ForeignKey("Parent")]
        public Guid? ParentId { get; set; }

        [JsonIgnore]
        public virtual Page Parent { get; set; }

        [InverseProperty("Page")]
        public virtual ICollection<Content> ContentElements { get; set; }
    }
}
