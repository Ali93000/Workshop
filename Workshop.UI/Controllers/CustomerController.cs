using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workshop.Entities.DTO;
using Workshop.UI.BLL;

namespace Workshop.UI.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = BLL.CustomerConsumer.GetAllCustomers();
            return View(customers.CustomersList);
        }

        public ActionResult Details(int id)
        {
            var customerInfo = BLL.CustomerConsumer.GetCustomerById(id);
            return View(customerInfo.Customer);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerDTO customerDTO)
        {
            CustomerConsumer.CreateCustomer(customerDTO);
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = CustomerConsumer.GetCustomerById(id);
            return View(customer.Customer);
        }

        [HttpPost]
        public ActionResult Edit(CustomerDTO customerDTO)
        {
            CustomerConsumer.EditCustomer(customerDTO);
            return RedirectToAction("Index", "Customer");
        }


        public ActionResult Delete(int? id)
        {
            var customer = CustomerConsumer.GetCustomerById(id.Value);
            return View(customer.Customer);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            CustomerConsumer.DeleteCustomer(id);
            return RedirectToAction("Index", "Customer");
        }
    }
}