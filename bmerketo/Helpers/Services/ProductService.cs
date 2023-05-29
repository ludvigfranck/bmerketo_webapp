using bmerketo.Helpers.Repositories;
using bmerketo.Models.Dtos;
using bmerketo.Models.Entities;
using bmerketo.Models.ViewModels;

namespace bmerketo.Helpers.Services;

public class ProductService
{
    private readonly ProductRepo _productRepo;
    private readonly ProductTagRepo _productTagRepo;
    private readonly CategoryRepo _categoryRepo;
    private readonly CategoryService _categoryService;
    private readonly TagService _tagService;

    public ProductService(ProductRepo productRepo, ProductTagRepo productTagRepo, CategoryRepo categoryRepo, CategoryService categoryService, TagService tagService)
    {
        _productRepo = productRepo;
        _productTagRepo = productTagRepo;
        _categoryRepo = categoryRepo;
        _categoryService = categoryService;
        _tagService = tagService;
    }

    public async Task<Product> CreateProductAsync(Product product, string categoryId, string[] items)
    {
        ProductEntity productEntity = product;
        CategoryEntity categoryEntity = await _categoryRepo.GetDataAsync(x => x.Id == int.Parse(categoryId));
        productEntity.ProductCategoryId = categoryEntity.Id;

        await _productRepo.AddDataAsync(productEntity);

        foreach (var item in items)
        {
            await _productTagRepo.AddDataAsync(new ProductTagEntity
            {
                ArticleNumber = productEntity.ArticleNumber,
                TagId = int.Parse(item)
            });
        }

        return productEntity;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var items = new List<Product>();
        foreach (var item in await _productRepo.GetAllDataAsync())
        {
            Product product = item;
            items.Add(product);
            product.Category = await _categoryService.GetCategoryAsync(item.ProductCategoryId);
            product.Tags = await _tagService.GetProductTagsAsync(item);
        }

        return items;
    }

    public async Task<IEnumerable<GridCollectionItemViewModel>> GetAllProductsAsync(string tagName)
    {
        var items = new List<GridCollectionItemViewModel>();
        foreach (var item in await _productRepo.GetAllDataAsync())
        {
            Product product = item;
            foreach (var tag in await _tagService.GetProductTagsAsync(product))
            {
                if (tag.TagName == tagName)
                {
                    items.Add(product);
                }
                    
            }
        }

        return items;
    }

    public async Task<Product> GetProductAsync(Guid articleNumber)
    {
        Product product = await _productRepo.GetDataAsync(x => x.ArticleNumber == articleNumber);
        product.Category = await _categoryService.GetCategoryAsync(product.CategoryId);
        product.Tags = await _tagService.GetProductTagsAsync(product);
        return product;
    }
}
