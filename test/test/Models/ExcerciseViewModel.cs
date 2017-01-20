using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class ExcerciseViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Excercise Name is required")]
        public string ExcerciseName { get; set; }
        [Required(ErrorMessage = "Excercise Date is required")]
        public System.DateTime ExcerciseDate { get; set; }
        [Required(ErrorMessage = "Excercise Duration in minutes is required")]
        public int DurationInMin { get; set; }
    }
}
