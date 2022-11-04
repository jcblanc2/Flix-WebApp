using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace devoir4
{
    public partial class PageFilms : System.Web.UI. Page
    {
        public Film currentFilm;
        public static int index = 0;
        List<Film> films = LoadingPage.films;
 
        protected void Page_Load(object sender, EventArgs e)
        {
            display(index);

        }

        protected void btnSuivant_Click(object sender, EventArgs e)
        {
            display(++index);
        }


        protected void btnPrecedent_Click(object sender, EventArgs e)
        {
            display(--index);
        }



        /// <summary>
        /// Method to bind data with the view 
        /// </summary>
        /// <param name="index"></param>
        private void display(int index)
        {
        
            if (index == 0)
            {
                btnPrecedent.Enabled = false;
            }
            else if (index == films.Count - 1)
            {
                btnSuivant.Enabled = false;
            }
            else
            {
                btnSuivant.Enabled = true;
                btnPrecedent.Enabled = true;
            }
            currentFilm = films.ElementAt(index);

            lblTitle2.Text = currentFilm.title;

            String circleImgUrl = "";
            if (Utilities.IsConnectedToInternet())
            {
                img.ImageUrl = "https://image.tmdb.org/t/p/w342" + currentFilm.backdrop_path;
                circleImgUrl = "~/resources/circleBlue.png";
            }
            else
            {
                circleImgUrl = "~/resources/circleRed.png";
                try
                {
                    img.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(currentFilm.image);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Bad Connection Internet");
                }

            }

            imgCircle.ImageUrl = circleImgUrl;




        }

    }
}