using MvcAssignment.Enums;

namespace MvcAssignment.Models
{
    public class Person
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public required string PhoneNumber { get; set; }

        public required string BirthPlace { get; set; }

        public bool IsGraduated { get; set; }
    }
}