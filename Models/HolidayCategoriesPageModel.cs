using Microsoft.AspNetCore.Mvc.RazorPages;
using IdealHoliday.Data;

namespace IdealHoliday.Models
{
    public class HolidayCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(IdealHolidayContext context, Holiday holiday)
        {
            var allCategories = context.Category;
            var holidayCategories = new HashSet<int>(
                holiday.HolidayCategories.Select(c => c.CategoryId));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryId = cat.Id,
                    Name = cat.CategoryName,
                    Assigned = holidayCategories.Contains(cat.Id)
                });
            }
        }

        public void UpdateHolidayCategories(IdealHolidayContext context, string[] selectedCategories, Holiday holidayToUpdate)
        {
            if (selectedCategories == null)
            {
                holidayToUpdate.HolidayCategories = new List<HolidayCategory>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var holidayCategories = new HashSet<int>(holidayToUpdate.HolidayCategories.Select(c => c.CategoryId));

            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.Id.ToString()))
                {
                    if (!holidayCategories.Contains(cat.Id))
                    {
                        holidayToUpdate.HolidayCategories.Add(new HolidayCategory
                        {
                            HolidayID = holidayToUpdate.Id,
                            CategoryId = cat.Id
                        });
                    }
                }
                else
                {
                    if (holidayCategories.Contains(cat.Id))
                    {
                        HolidayCategory courseToRemove = holidayToUpdate.HolidayCategories
                            .SingleOrDefault(i => i.CategoryId == cat.Id);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}






