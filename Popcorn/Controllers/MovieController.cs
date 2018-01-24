using Popcorn.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Popcorn.Models.Movie_Model;

namespace Popcorn.Controllers
{
    public class MovieController : Controller
    {

   
        public JsonResult Index()
        {
            Movie_Model.Output_movie Output = new Movie_Model.Output_movie();
            Output_movie Output_m = new Output_movie();
            Output_m.Detail_AllMovie = new List<Detail>();
            DataClass.Movies dbmovie = new DataClass.Movies();

            using (DataClass.DataClasses1DataContext db = new DataClass.DataClasses1DataContext(ConfigurationManager.AppSettings["dbConnPopcorn"]))
            {
                var result = db.Movies.OrderByDescending(x => x.Date_Movie).ToList();
                if (result != null)
                {

                    foreach (var item in result.AsParallel())
                    {
                        Output_m.Detail_AllMovie.Add(new Detail
                        {
                            Name_Movie = item.Name_Movie,
                            Caster = item.ID_Caster,
                            Directer = item.ID_Director,
                            Date_Movie = item.Date_Movie


                        });

                    }
                }

            }


            return Json(Output_m, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Category_Movie(Search_Movie input)
        {
            Movie_Model.Output_movie Output = new Movie_Model.Output_movie();
            Output_movie Output_m = new Output_movie();
            Output_m.Detail_AllMovie = new List<Detail>();
            DataClass.Movies dbmovie = new DataClass.Movies();

            using (DataClass.DataClasses1DataContext db = new DataClass.DataClasses1DataContext(ConfigurationManager.AppSettings["dbConnPopcorn"]))
            {
                var result = db.Movies.ToList();
                if (result != null)
                {

                    foreach (var item in result.AsParallel())
                    {
                        Output_m.Detail_AllMovie.Add(new Detail
                        {
                            Name_Movie = item.Name_Movie,
                            Caster = item.ID_Caster,
                            Directer = item.ID_Director


                        });

                    }
                }





            }


            return Json(Output_m, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult add_movie(Input_movie input)
        {
            DataClass.Movies dbmovie = new DataClass.Movies();

            User_Model.Output_Regis output = new User_Model.Output_Regis();


            using (DataClass.DataClasses1DataContext db = new DataClass.DataClasses1DataContext(ConfigurationManager.AppSettings["dbConnPopcorn"]))
            {

                var result = db.Movies.FirstOrDefault(X => X.Name_Movie == input.Name_Movie);

                if (result != null)
                {
                    output.message = "Email is already";
                    output.error = true;


                    return Json(output, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (input.Name_Movie == null)
                    {
                        output.message = "Email null";
                    }
                    else
                    {
                       
                        dbmovie.Name_Movie = input.Name_Movie;
                        dbmovie.Picture_Movie = input.img;
                        dbmovie.Date_Movie = input.Date_Movie;
                        //userDB.Date_regis = DateTime.Now.ToString();
                        dbmovie.ID_Caster = input.Caster;
                        dbmovie.ID_Director = input.detail;
                        dbmovie.Trialer = input.urlTri;
                        db.Movies.InsertOnSubmit(dbmovie);
                        db.SubmitChanges();
                        



                    }

                    return Json("");
                }


            }
        }
    }
}