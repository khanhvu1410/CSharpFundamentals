using MvcAssignment.Enums;
using MvcAssignment.Models;

namespace MvcAssignment.Data
{
    public class RookiesDbContext : IRookiesDbContext
    {
        private List<Person> _persons = [
            new Person 
            { 
                FirstName = "Khánh", 
                LastName = "Vũ", 
                Gender = Gender.Male, 
                DateOfBirth = DateTime.Parse("2003-10-14"), 
                PhoneNumber = "0928492950", 
                BirthPlace = "Hà Nội", 
                IsGraduated = false 
            }, 
            new Person 
            { 
                FirstName = "Văn Chiến", 
                LastName = "Thái", 
                Gender = Gender.Male, 
                DateOfBirth = DateTime.Parse("2003-07-29"), 
                PhoneNumber = "0928123123", 
                BirthPlace = "Hà Nội", 
                IsGraduated = false 
            },
            new Person
            {
                FirstName = "Đức Lâm",
                LastName = "Trần",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Parse("1993-03-22"),
                PhoneNumber = "0911123123",
                BirthPlace = "Nam Định",
                IsGraduated = true
            },
            new Person 
            { 
                FirstName = "Đỗ Hoàng Minh", 
                LastName = "Nguyễn", 
                Gender = Gender.Male, 
                DateOfBirth = DateTime.Parse("2003-05-18"), 
                PhoneNumber = "0912392950", 
                BirthPlace = "Hà Nội", 
                IsGraduated = false 
            }, 
            new Person 
            { 
                FirstName = "Thành Hưng", 
                LastName = "Nguyễn", 
                Gender = Gender.Male, 
                DateOfBirth = DateTime.Parse("2003-02-13"), 
                PhoneNumber = "0912392123", 
                BirthPlace = "Hà Nội", 
                IsGraduated = false 
            }, 
            new Person 
            { 
                FirstName = "Hồng Giang", 
                LastName = "Nguyễn", 
                Gender = Gender.Female, 
                DateOfBirth = DateTime.Parse("2004-05-23"), 
                PhoneNumber = "0912322123", 
                BirthPlace = "Thái Bình", 
                IsGraduated = false 
            },
            new Person
            {
                FirstName = "Trọng Duy",
                LastName = "Vũ",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Parse("2000-09-05"),
                PhoneNumber = "0912323323",
                BirthPlace = "Hà Tĩnh",
                IsGraduated = false
            }
        ];

        public List<Person> Persons { get => _persons; set => _persons = value; }
    }
}