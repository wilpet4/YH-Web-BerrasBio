using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class InitialTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_genres_GenresGenreId",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_movie_MoviesMovieId",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_directors_DirectorId",
                table: "movie");

            migrationBuilder.DropForeignKey(
                name: "FK_screeningRooms_cinemas_CinemaId",
                table: "screeningRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_screenings_movie_MovieId",
                table: "screenings");

            migrationBuilder.DropForeignKey(
                name: "FK_screenings_screeningRooms_ScreeningRoomId",
                table: "screenings");

            migrationBuilder.DropForeignKey(
                name: "FK_seats_screeningRooms_ScreeningRoomId",
                table: "seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_seats",
                table: "seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_screenings",
                table: "screenings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_screeningRooms",
                table: "screeningRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_genres",
                table: "genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_directors",
                table: "directors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cinemas",
                table: "cinemas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movie",
                table: "movie");

            migrationBuilder.RenameTable(
                name: "seats",
                newName: "Seats");

            migrationBuilder.RenameTable(
                name: "screenings",
                newName: "Screenings");

            migrationBuilder.RenameTable(
                name: "screeningRooms",
                newName: "ScreeningRooms");

            migrationBuilder.RenameTable(
                name: "genres",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "directors",
                newName: "Directors");

            migrationBuilder.RenameTable(
                name: "cinemas",
                newName: "Cinemas");

            migrationBuilder.RenameTable(
                name: "movie",
                newName: "Movies");

            migrationBuilder.RenameIndex(
                name: "IX_seats_ScreeningRoomId",
                table: "Seats",
                newName: "IX_Seats_ScreeningRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_screenings_ScreeningRoomId",
                table: "Screenings",
                newName: "IX_Screenings_ScreeningRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_screenings_MovieId",
                table: "Screenings",
                newName: "IX_Screenings_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_screeningRooms_CinemaId",
                table: "ScreeningRooms",
                newName: "IX_ScreeningRooms_CinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_movie_DirectorId",
                table: "Movies",
                newName: "IX_Movies_DirectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "SeatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Screenings",
                table: "Screenings",
                column: "ScreeningId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScreeningRooms",
                table: "ScreeningRooms",
                column: "ScreeningRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directors",
                table: "Directors",
                column: "DirectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cinemas",
                table: "Cinemas",
                column: "CinemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_Genres_GenresGenreId",
                table: "GenreMovie",
                column: "GenresGenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_Movies_MoviesMovieId",
                table: "GenreMovie",
                column: "MoviesMovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "DirectorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScreeningRooms_Cinemas_CinemaId",
                table: "ScreeningRooms",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "CinemaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_Movies_MovieId",
                table: "Screenings",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_ScreeningRooms_ScreeningRoomId",
                table: "Screenings",
                column: "ScreeningRoomId",
                principalTable: "ScreeningRooms",
                principalColumn: "ScreeningRoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_ScreeningRooms_ScreeningRoomId",
                table: "Seats",
                column: "ScreeningRoomId",
                principalTable: "ScreeningRooms",
                principalColumn: "ScreeningRoomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Genres_GenresGenreId",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Movies_MoviesMovieId",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_ScreeningRooms_Cinemas_CinemaId",
                table: "ScreeningRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Movies_MovieId",
                table: "Screenings");

            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_ScreeningRooms_ScreeningRoomId",
                table: "Screenings");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_ScreeningRooms_ScreeningRoomId",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Screenings",
                table: "Screenings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScreeningRooms",
                table: "ScreeningRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directors",
                table: "Directors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cinemas",
                table: "Cinemas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Seats",
                newName: "seats");

            migrationBuilder.RenameTable(
                name: "Screenings",
                newName: "screenings");

            migrationBuilder.RenameTable(
                name: "ScreeningRooms",
                newName: "screeningRooms");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "genres");

            migrationBuilder.RenameTable(
                name: "Directors",
                newName: "directors");

            migrationBuilder.RenameTable(
                name: "Cinemas",
                newName: "cinemas");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "movie");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_ScreeningRoomId",
                table: "seats",
                newName: "IX_seats_ScreeningRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Screenings_ScreeningRoomId",
                table: "screenings",
                newName: "IX_screenings_ScreeningRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Screenings_MovieId",
                table: "screenings",
                newName: "IX_screenings_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ScreeningRooms_CinemaId",
                table: "screeningRooms",
                newName: "IX_screeningRooms_CinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_DirectorId",
                table: "movie",
                newName: "IX_movie_DirectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_seats",
                table: "seats",
                column: "SeatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_screenings",
                table: "screenings",
                column: "ScreeningId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_screeningRooms",
                table: "screeningRooms",
                column: "ScreeningRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_genres",
                table: "genres",
                column: "GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_directors",
                table: "directors",
                column: "DirectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cinemas",
                table: "cinemas",
                column: "CinemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movie",
                table: "movie",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_genres_GenresGenreId",
                table: "GenreMovie",
                column: "GenresGenreId",
                principalTable: "genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_movie_MoviesMovieId",
                table: "GenreMovie",
                column: "MoviesMovieId",
                principalTable: "movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movie_directors_DirectorId",
                table: "movie",
                column: "DirectorId",
                principalTable: "directors",
                principalColumn: "DirectorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_screeningRooms_cinemas_CinemaId",
                table: "screeningRooms",
                column: "CinemaId",
                principalTable: "cinemas",
                principalColumn: "CinemaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_screenings_movie_MovieId",
                table: "screenings",
                column: "MovieId",
                principalTable: "movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_screenings_screeningRooms_ScreeningRoomId",
                table: "screenings",
                column: "ScreeningRoomId",
                principalTable: "screeningRooms",
                principalColumn: "ScreeningRoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_seats_screeningRooms_ScreeningRoomId",
                table: "seats",
                column: "ScreeningRoomId",
                principalTable: "screeningRooms",
                principalColumn: "ScreeningRoomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
