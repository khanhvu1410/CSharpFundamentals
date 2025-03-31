using MvcAssignment.Models;

namespace MvcAssignment.Data
{
    public interface IRookiesDbContext
    {
        List<Person> Persons { get; set; }
    }
}