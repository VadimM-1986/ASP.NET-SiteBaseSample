
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationDZmodel11.Models
{
    public class ModelDB
    {
        [BindNever]
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название:")]
        [StringLength(50, ErrorMessage = "Строка слишком длинная")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Анонс:")]
        [StringLength(100, ErrorMessage = "Строка слишком длинная")]
        public string Anons { get; set; }

        [Required]
        [Display(Name = "Описание:")]
        [StringLength(500, ErrorMessage = "Строка слишком длинная")]
        public string Fulltext { get; set; }
    }
}
