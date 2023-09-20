using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Entities
{
    //[Index(nameof(Name), IsUnique = true)]
    public class Genre : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public HashSet<Movie> Movies { get; set; }
    }
}
