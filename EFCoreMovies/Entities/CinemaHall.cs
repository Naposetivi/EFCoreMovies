namespace EFCoreMovies.Entities
{
    public class CinemaHall
    {
        public int Id { get; set; }
        public CinemaHallTypes CinemaHallType { get; set; }
        public string Cost { get; set; }
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public HashSet<Movie> Movies { get; set; }
    }
}
