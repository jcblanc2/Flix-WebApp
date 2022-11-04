using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;


namespace devoir4
{
    class MovieDatabase
    {
        public static List<int> listeFilmId;
        public static SQLiteConnection connection;

        /// <summary>
        /// This method load the ConnectionString 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static String LoadConnectionString()
        {
            // Get the connectionString
            string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string databasePath = Path.GetDirectoryName(path) + "/film.db";

            String connectionString = $"Data Source={databasePath};Version=3";

            // Create a connection
            using (connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                String CreateTableSql = "CREATE TABLE IF NOT EXISTS Film(id_film INTEGER, " +
                    "title VARCHAR(25), overview VARCHAR(250), release_date VARCHAR(20)," +
                    "backdrop_path VARCHAR(250), vote_average DECIMAL, image BLOB," +
                    "original_language VARCHAR(5), popularity DECIMAL, vote_count INTEGER);";

                SQLiteCommand command = connection.CreateCommand(); // create a command
                command.CommandText = CreateTableSql;
                command.ExecuteNonQuery();
                
            }
            return connectionString;
        }


        /// <summary>
        /// This methode save the movies we get from the API
        /// to the database
        /// </summary>
        /// <param name="film"></param>
        public static void SaveMovieToDatabase(Film film)
        {
            listeFilmId = UpdateDatabase();
            using (connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Open();

                if (!listeFilmId.Contains(film.id))
                {
                    var sql = "INSERT INTO Film(id_film, title, overview, release_date, " +
                        "backdrop_path, vote_average, image, original_language, " +
                        "popularity, vote_count)" +
                        " VALUES(@id_film, @title, @overview, @release_date, " +
                        "@backdrop_path, @vote_average, @image, @original_language, " +
                        "@popularity, @vote_count);";
                    using (var cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@id_film", film.id);
                        cmd.Parameters.AddWithValue("@title", film.title);
                        cmd.Parameters.AddWithValue("@overview", film.overview);
                        cmd.Parameters.AddWithValue("@release_date", film.release_date);
                        cmd.Parameters.AddWithValue("@backdrop_path", film.backdrop_path);
                        cmd.Parameters.AddWithValue("@vote_average", film.vote_average);
                        cmd.Parameters.AddWithValue("@original_language", film.original_language);
                        cmd.Parameters.AddWithValue("@popularity", film.popularity);
                        cmd.Parameters.AddWithValue("@vote_count", film.vote_count);


                        Image photo;

                        using (System.Net.WebClient webClient = new System.Net.WebClient())
                        {
                            using (Stream stream = webClient.OpenRead(@"https://image.tmdb.org/t/p/w342" + film.backdrop_path))
                            {
                                photo = new Bitmap(Image.FromStream(stream));
                            }
                        }

                        byte[] image = Utilities.ImageToByte(photo, System.Drawing.Imaging.ImageFormat.Jpeg);
                        cmd.Parameters.AddWithValue("@image", image);
                        cmd.ExecuteNonQuery();
                    }
                }


            }
        }

        /// <summary>
        /// This methode load the movies from the database
        /// </summary>
        public static List<Film> LoadMoviesFromDB()
        {
            List<Film> listeFilms = new List<Film>();
            using (connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Open();
                String querySelect = "SELECT * FROM Film";

                SQLiteCommand command = new SQLiteCommand(querySelect, connection);
                SQLiteDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Film film = new Film();

                    film.id = dataReader.GetInt32(0);
                    film.title = dataReader.GetString(1);
                    film.overview = dataReader.GetString(2);
                    film.release_date = dataReader.GetString(3);
                    film.backdrop_path = dataReader.GetString(4);
                    film.vote_average = dataReader.GetFloat(5);
                    film.image = (System.Byte[])dataReader[6];
                    film.original_language = dataReader.GetString(7);
                    film.popularity = dataReader.GetFloat(8);
                    film.vote_count = dataReader.GetInt32(9);



                    listeFilms.Add(film);
                }
            }
            return listeFilms;
        }


        /// <summary>
        /// Method to check if a movie already saved in the database
        /// </summary>
        /// <returns></returns>
        public static List<int> UpdateDatabase()
        {
            List<int> listeID = new List<int>();
            using (connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Open();
                String querySelect = "SELECT id_film FROM Film";

                SQLiteCommand command = new SQLiteCommand(querySelect, connection);
                SQLiteDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    int idFilm = dataReader.GetInt32(0);
                    listeID.Add(idFilm);
                }
            }
            return listeID;
        }
    }
}
