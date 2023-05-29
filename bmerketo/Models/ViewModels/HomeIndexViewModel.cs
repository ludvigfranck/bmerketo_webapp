namespace bmerketo.Models.ViewModels;

public class HomeIndexViewModel
{
    public GridCollectionViewModel FeaturedCollection { get; set; } = null!;
    public GridCollectionViewModel NewCollection { get; set; } = null!;
    public GridCollectionViewModel PopularCollection { get; set; } = null!;

}
