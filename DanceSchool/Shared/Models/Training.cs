using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanceSchool.Shared.Models
{
    public class Training
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CoachId { get; set; }
        public virtual Coach Coach { get; set; }

        [DisplayName("Nazwa kursu")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Liczba miejsc")]
        public int NumberOfParticipants { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime FirstLessonDate { get; set; }

        [DisplayName("Cena kursu")]
        public double Price { get; set; }
    }
}
