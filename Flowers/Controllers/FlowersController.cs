using Flowers.Data;
using Flowers.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Flowers.Controllers
{
    public class FlowersController : Controller
    {
        // GET: Flowers
        public ActionResult Index()
        {
            List<FlowersModel> flowers = new List<FlowersModel>();

            FlowerDAO flowerDAO = new FlowerDAO();

            flowers = flowerDAO.FetchAll();

            return View("index", flowers);
        }
        public ActionResult Details(int id)
        {
            FlowerDAO flowerDAO = new FlowerDAO();
            FlowersModel flower = flowerDAO.FetchOne(id);
            return View("Details", flower);
        }
        public ActionResult Create()
        {
            return View("FlowerForm");
        }
        public ActionResult Edit(int id)
        {
            FlowerDAO flowerDAO = new FlowerDAO();
            FlowersModel flower = flowerDAO.FetchOne(id);
            return View("FlowerForm2", flower);
        }
        public ActionResult ProcessCreate(FlowersModel flowersModel)

        {
            FlowerDAO flowersDAO = new FlowerDAO();
            flowersDAO.CreateOrUpdate(flowersModel);
            return View("Details", flowersModel);
        }
        public ActionResult Delete(int id)
        {
            FlowerDAO flowerDAO = new FlowerDAO();
            flowerDAO.Delete(id);
            List<FlowersModel> flowers = flowerDAO.FetchAll();
            return View("Index", flowers);
        }
        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }
        public ActionResult SearchForName(string searchPhrase)
        {
            // get a list of search results from the database
            FlowerDAO flowerDAO = new FlowerDAO();

            List<FlowersModel> searchResults = flowerDAO.SearchForName(searchPhrase);

            return View("Index", searchResults);
        }
    }
}