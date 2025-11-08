// HomeController.cs 
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FAQ.Models;
using Microsoft.AspNetCore.Http.Features;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using FAQ.Data.FAQContext;
using Microsoft.EntityFrameworkCore;


namespace FAQ.Controllers;

public class HomeController : Controller
{   
    // this code says go get the database information. 
    // we have this get set private will limit the access that this context can be used. 
    private FAQContext context { get; set; }

    public HomeController(FAQContext ctx)
    {
        context = ctx;
    }

    // topic and question are passed in as parameters because we need to know what topic and category the user selected for queries. 
    [Route("/")]
    [Route("topic/{topic}")]
    [Route("topic/{category}")]
    [Route("topic/{topic}/category/{category}")]

    public IActionResult Index(string topic, string category)
    {
        
        ViewBag.Topics = context.Topics.OrderBy(t => t.Name).ToList();
        ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
        // Iqueryable sets up the capabilites for Linq search queries. 
        // the f is an alias for the iteration variable. the arrow is a lambda expression that 
        // cycles through each of the topics and categories to find the one the client reuqested. 
        IQueryable<FAQ> faqs = context.FAQs
        .Include(f => f.Topic)
        .Include(f => f.Category)
        .OrderBy(f => f.Question);

        if (!string.IsNullOrEmpty(topic))
        {
            faqs = faqs.Where(f => f.TopicId) == topic;
        }
        if (!string.IsNullOrEmpty(category))
        {
            faqs = faqs.Where(f => Where(f => f.CategoryId == category));
        }

        return View(faqs.ToList()); 
    }

}
    

        public IActionResult Index(string topic, string category)
    {
        // I need all of the Question
        // I need all of the Answers 
        // I need to gather the topics 
        // I need to gather categories. 

        return View();
    }

    
        
       

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }



}
