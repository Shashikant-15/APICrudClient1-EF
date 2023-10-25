using APICrudClient1.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICrudClient1.Controllers
{
    public class CustomerController : Controller
    {
        public readonly APIGateway apiGateway;

        public CustomerController(APIGateway apiGateway)
        {
            this.apiGateway = apiGateway;
        }



        public IActionResult Index()
        {
            List<Customer> customers;
            // api get will come
            customers = apiGateway.ListCustomers();
            return View(customers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }
        [HttpPost]  
        public IActionResult Create(Customer customer)
        {
            return RedirectToAction("index");
        }



        public IActionResult Details(int id) 
        {
            // fetch the 
            Customer customer = new Customer();
            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // fetch 
            Customer customer = new Customer();
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            // do api
            return RedirectToAction("index");
        }
        [HttpGet] 
        public IActionResult Delete(int id)
        {
            // fetch 
            Customer customer = new Customer();
            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            //  do api
            return RedirectToAction("index");
        }
    }
}
