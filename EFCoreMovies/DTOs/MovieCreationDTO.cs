namespace EFCoreMovies.DTOs
{
    public class MovieCreationDTO
    {
        public string Title { get; set; }
        public bool InCinemas { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<int> GenresIds { get; set; }
        public List<int> CInemaHallsIds { get; set; }
        public List<MovieActorCreationDTO> MovieActor { get; set; }
    }
}
