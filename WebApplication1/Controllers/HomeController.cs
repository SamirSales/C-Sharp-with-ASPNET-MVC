﻿using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        static List<Person> lista = new List<Person>();

        public ActionResult Index()
        {
            var pessoa = new Person()
            {
                Id = 1,
                Name = "Maria",
                Nick = "Mary",
                Age = 20
            };

            lista.Add(pessoa);

            ViewBag.list = lista;

            return View();
        }

        [HttpPost]
        public void Create(string name, string nick, int age)
        {
            var pessoa = new Person()
            {
                Id = 8,
                Name = name,
                Nick = nick,
                Age = age
            };

            lista.Add(pessoa);
        }

        [HttpPost]
        public void Update(int id, string name, string nick, int age)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                Person p = lista[i];
                if (p.Id == id)
                {
                    p.Name = name;
                    p.Nick = nick;
                    p.Age = age;
                    break;
                }
            }
        }

        [HttpPost]
        public void Delete(int personId)
        {    
            for(int i=0; i<lista.Count; i++)
            {
                Person p = lista[i];
                if(p.Id == personId)
                {
                    lista.Remove(p);
                    break;
                }
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}