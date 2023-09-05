using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPage.Data;
using RazorPage.Models;

namespace RazorPage.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //[BindProperty]  //bind all labels data after onpost() is called basically to save data or update data
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }
        public IActionResult OnPost() 
        {
            Category? obj = _db.Categories.Find(Category.Id); //we will get id from Category because of "BindProperties"
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges(); //go to the database and create category
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index"); //view all categories in index() line 9;
                                              //return RedirectToAction("Index","Category");
                                              //-> if we have different controller then add like
                                              //this else keep only menthod/function name            
        }
        
    }
}
