using bmerketo.Helpers.Repositories;
using bmerketo.Models.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bmerketo.Helpers.Services;

public class TagService
{
    private readonly TagRepo _tagRepo;
    private readonly ProductTagRepo _productTagRepo;

    public TagService(TagRepo tagRepo, ProductTagRepo productTagRepo)
    {
        _tagRepo = tagRepo;
        _productTagRepo = productTagRepo;
    }

    public async Task<List<SelectListItem>> GetTagsAsync()
    {
        var items = new List<SelectListItem>();

        foreach (var item in await _tagRepo.GetAllDataAsync())
        {
            items.Add(new SelectListItem
            {
                Value = item.Id.ToString(),
                Text = item.TagName
            });
        }

        return items;
    }

    public async Task<List<SelectListItem>> GetTagsAsync(string[] selectedItems)
    {
        var items = new List<SelectListItem>();

        foreach (var item in await _tagRepo.GetAllDataAsync())
        {
            items.Add(new SelectListItem
            {
                Value = item.Id.ToString(),
                Text = item.TagName,
                Selected = selectedItems!.Contains(item.Id.ToString())
            });
        }

        return items;
    }

    public async Task<IEnumerable<Tag>> GetProductTagsAsync(Product product)
    {
        var items = new List<Tag>();
        foreach (var item in await _productTagRepo.GetAllDataAsync(x => x.ArticleNumber.ToString() == product.ArticleNumber))
        {
            foreach (var tag in await _tagRepo.GetAllDataAsync(x => x.Id == item.TagId))
                items.Add(tag);
        }
        
        return items;
    }
}
