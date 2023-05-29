using bmerketo.Models.Dtos;

namespace bmerketo.Models.ViewModels;

public class BackOfficeViewModel
{
    public string ProductsTitle { get; set; } = null!;
    public IEnumerable<Product> Products { get; set; } = new List<Product>();

    public string UsersTitle { get; set; } = null!;
    public IEnumerable<UserProfile> Users { get; set; } = new List<UserProfile>();
}
