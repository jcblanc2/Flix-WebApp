using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Name: John Clayton Blanc
/// Date: 11/4/2022
/// Course: C#
/// </summary>

namespace devoir4
{
    public partial class LoadingPage : System.Web.UI.Page
    {
        public static bool check = false;
        public static List<Film> films;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            checkToGetData();
        }


        /// <summary>
        /// Check if the user is connected to internet to load data
        /// </summary>
        private void checkToGetData()
        {
            if (Utilities.IsConnectedToInternet())
            {
                films = Utilities.getMovieDbList();
                foreach (Film film in films)
                {
                    check = true;
                    MovieDatabase.SaveMovieToDatabase(film);
                }
            }
            else
            {
                films = MovieDatabase.LoadMoviesFromDB();
            }
        }
    }
}