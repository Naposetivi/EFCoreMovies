namespace EFCoreMovies.DTOs
{
    public class CinemaCreationDTO
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public CinemaOfferCreationDTO cInemaOffer { get; set; }
        public CinemaHallCreationDTO[] CInemaHalls { get; set; }
    }
}
