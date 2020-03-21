using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Newtonsoft.Json;
using WMTest.Models;
using RestSharp.Serialization.Json;

namespace WMTest.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Product> listProducts = new List<Product>();

            var client = new RestClient("http://urnebes-001-site5.ctempurl.com/WMTest/WMTest/GetAllProducts");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            var jsonData = new JsonDeserializer().Deserialize<List<Product>>(response);

            foreach (var x in jsonData)
            {
                Product product = new Product();

                product.Id = x.Id;
                product.Naziv = x.Naziv;
                product.Opis = x.Opis;
                product.Kategorija = x.Kategorija;
                product.Proizvođač = x.Proizvođač;
                product.Dobavljač = x.Dobavljač;
                product.Cena = x.Cena;

                listProducts.Add(product);
            }

            return View(listProducts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Product());
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            string strUrl = $"http://urnebes-001-site5.ctempurl.com/WMTest/WMTest/InsertProduct?naziv={product.Naziv}&opis={product.Opis}&kategorija={product.Kategorija}&proizvodjac={product.Proizvođač}&dobavljac={product.Dobavljač}&cena={product.Cena}";

            var client = new RestClient(strUrl);
            var request = new RestRequest(Method.POST);
            IRestResponse response = client.Execute(request);

            return RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = new Product();

            string url = $"http://urnebes-001-site5.ctempurl.com/WMTest/WMTest/GetProduct?id={id}";

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            var x = new JsonDeserializer().Deserialize<Product>(response);

            product.Id = x.Id;
            product.Naziv = x.Naziv;
            product.Opis = x.Opis;
            product.Kategorija = x.Kategorija;
            product.Proizvođač = x.Proizvođač;
            product.Dobavljač = x.Dobavljač;
            product.Cena = x.Cena;

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            string strUrl = $"http://urnebes-001-site5.ctempurl.com/WMTest/WMTest/UpdateProduct?id={product.Id}&naziv={product.Naziv}&opis={product.Opis}&kategorija={product.Kategorija}&proizvodjac={product.Proizvođač}&dobavljac={product.Dobavljač}&cena={product.Cena}";

            var client = new RestClient(strUrl);
            var request = new RestRequest(Method.POST);
            IRestResponse response = client.Execute(request);

            return RedirectToAction("Index");
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            string strUrl = $"http://urnebes-001-site5.ctempurl.com/WMTest/WMTest/DeleteProduct?id={id}";

            var client = new RestClient(strUrl);
            var request = new RestRequest(Method.DELETE);
            IRestResponse response = client.Execute(request);

            return RedirectToAction("Index");
        }
    }
}