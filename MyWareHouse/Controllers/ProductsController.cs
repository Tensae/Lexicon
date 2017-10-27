using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using MyWareHouse.Models;

namespace MyWareHouse.Controllers
{
    public class ProductsController : Controller
    {
        private MyWareHouseContext db = new MyWareHouseContext();


        // GET: Products
        ////http://localhost:53323/?category=xxx ( display by catagory name
        public ActionResult Index(string catagory)
        {

           // var products = db.Products.ToList(); ...not safe bec It will bring all products from db.

            var dbProducts = db.Products;
            List<Products> products;


            if (catagory != null)
            {
                products = dbProducts.Where(p => p.Catagory != null && p.Catagory == catagory.ToLower()).ToList();

            }
            else
            {
                products = dbProducts.ToList();
            }

            var productItems = products.Select(p => new ProductListItem
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Catagory = p.Catagory,
                Count = p.Count
            }).ToList(); 

            return View(productItems);
        }


        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Catagory,Count,Description")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }

            var productEM = new ProductEditViewModel
            {
                Id= products.Id,
                Name = products.Name,
                Catagory = products.Catagory,
                Description = products.Description,
                Price = products.Price
            };
            return View(productEM);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductEditViewModel productEditVM)
        {
            if (ModelState.IsValid)
            {
                var product = new Products
                {
                    Id = productEditVM.Id,
                    Name = productEditVM.Name,
                    Catagory = productEditVM.Catagory,
                    Description = productEditVM.Description,
                    Price = productEditVM.Price

                };
                
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productEditVM);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class ProductEditViewModel
    {
        public string Catagory { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }

    public class ProductListItem
    {
        public string Catagory { get; set; }
        public int Count { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
