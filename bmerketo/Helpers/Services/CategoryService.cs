using bmerketo.Helpers.Repositories;
using bmerketo.Models.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bmerketo.Helpers.Services;

public class CategoryService
{
    private readonly CategoryRepo _categoryRepo;

    public CategoryService(CategoryRepo categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public async Task<List<SelectListItem>> GetCategoriesAsync()
    {
        var items = new List<SelectListItem>();

        foreach (var item in await _categoryRepo.GetAllDataAsync())
        {
            items.Add(new SelectListItem
            {
                Value = item.Id.ToString(),
                Text = item.CategoryName
            });
        }

        return items;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        var items = new List<Category>();

        foreach (var item in await _categoryRepo.GetAllDataAsync())
        {
            Category category = item;
            items.Add(category);
        }

        return items;
    }

    public async Task<List<string>> GetAllCategoriesNamesAsync()
    {
        var items = new List<string>();

        foreach (var item in await _categoryRepo.GetAllDataAsync())
        {
            Category category = item;
            items.Add(category.CategoryName);
        }

        return items;
    }

    public async Task<Category> GetCategoryAsync(int categoryId)
    {
        return await _categoryRepo.GetDataAsync(x => x.Id == categoryId);
    }

    public async Task<Category> GetCategoryAsync(string categoryName)
    {
        return await _categoryRepo.GetDataAsync(x => x.CategoryName == categoryName);
    }
}
