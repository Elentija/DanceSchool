using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanceSchool.Shared.Models
{
    public class Coach
    {
        public Coach()
        {
            Trainings = new List<Training>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Imię trenera")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Nazwisko trenera")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Doświadczenie [w latach]")]
        public int AgeExperience { get; set; }

        [DisplayName("Opis trenera")]
        [Required]
        public string Description { get; set; }

        public virtual ICollection<Training> Trainings { get; set; }
    }
}
