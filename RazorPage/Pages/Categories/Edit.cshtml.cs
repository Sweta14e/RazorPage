using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPage.Data;
using RazorPage.Models;

namespace RazorPage.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //[BindProperty]  //bind all labels data after onpost() is called basically to save data or update data
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if(id!=null && id!=0)
            {
                Category = _db.Categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category); // what is to be add
                _db.SaveChanges(); //go to the database and create category
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index"); //view all categories in index() line 9;
                                                  //return RedirectToAction("Index","Category");
                                                  //-> if we have different controller then add like
                                                  //this else keep only menthod/function name
            }
            return Page();
        }
    }
}
