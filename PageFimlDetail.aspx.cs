using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace devoir4
{
    public partial class DetailPage : System.Web.UI.Page
    {
        Film currentFilm = LoadingPage.films.ElementAt(PageFilms.index);
        public const String VIDEO_URL = "https://api.themoviedb.org/3/movie/{0}/videos?api_key=a07e22bc18f5cb106bfe4cc1f83ad8ed";
        public SolidBrush color = new SolidBrush(Color.Red);
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTitleDetail.Text = currentFilm.title;
            lblOverViewDetail.Text = currentFilm.overview;
            lbtDateDetail.Text = currentFilm.release_date;
            lblOriginal_language.Text = currentFilm.original_language;
            lblPopularity.Text = currentFilm.popularity.ToString();
            lbl_vote_count.Text = currentFilm.vote_count.ToString();
            lbl_vote_average.Text = currentFilm.vote_average.ToString();


            string circleImgUrl = "";
            if (Utilities.IsConnectedToInternet())
            {
                color.Color = Color.Blue;
                circleImgUrl = "~/resources/circleBlue.png";
                displayVideo(getYoutubeKey(), circleImgUrl);
            }
            else
            {
                color.Color = Color.Red;
                circleImgUrl = "~/resources/circleRed.png";
                displayVideo("", circleImgUrl);
            }
        }



        private String getYoutubeKey()
        {

            String reponse = "";
            String youtubeKey = "";

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    reponse = webClient.DownloadString(String.Format(VIDEO_URL, currentFilm.id));
                }

                using (JsonDocument document = JsonDocument.Parse(reponse))
                {
                    JsonElement root = document.RootElement;
                    JsonElement resultsList = root.GetProperty("results");

                    int i = 0;
                    while (true)
                    {
                        String type = resultsList[i].GetProperty("type").ToString();
                        youtubeKey = resultsList[i].GetProperty("key").ToString();
                        if (type.Equals("Clip"))
                        {
                            break;
                        }
                        i++;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return youtubeKey;
        }


        private void displayVideo(String id, String circleImgUrl)
        {
            ltVideo.Text = String.Format("<html><head>" +
                    "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"/>" +
                    "</head><body>" +
                    "<iframe width=\"100%\" height=\"315\" src=\"https://www.youtube.com/embed/{0}?autoplay=1\"" +
                    "frameborder = \"0\" allow = \"autoplay; encrypted-media\" allowfullscreen></iframe>" +
                    "</body></html>", id);

            imgCircle.ImageUrl = circleImgUrl;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageFilms.aspx");
        }
    }
}