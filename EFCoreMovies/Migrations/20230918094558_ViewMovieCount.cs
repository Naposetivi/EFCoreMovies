using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    /// <inheritdoc />
    public partial class ViewMovieCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW dbo.MoviesWithCounts
as

Select Id, Title,
(select COUNT(*) FROM GenreMovie where MoviesId = movies.Id) as AmountGenres,
(Select COUNT(distinct moviesId) from CinemaHallMovie
	Inner Join CinemaHalls
	On CinemaHalls.Id = CinemaHallMovie.CinemaHallsId
	Where MoviesId = movies.Id) as AmountCinemas,
	(Select count(*) from MoviesActors where MovieId = movies.Id) as AmountActors
	From Movies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.MoviesWithCounts");
        }
    }
}
