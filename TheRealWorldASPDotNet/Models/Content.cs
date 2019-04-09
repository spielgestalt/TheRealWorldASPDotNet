using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Newtonsoft.Json;
namespace TheRealWorldASPDotNet.Models
{
    [Serializable]
    public class Content
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string TextContent { get; set; }

        [ForeignKey("Page")]
        public Guid PageId { get; set; }

        [JsonIgnore]
        public Page Page { get; set; }
    }
}
