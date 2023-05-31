namespace ShopSuphan.DTOS.Report
{
    public class SalesCommunityDTO
    {
        public double TotalPrice { get; set; }
        public List<SalesCommunityItemDTOcs> Sales { get; set; } = new List<SalesCommunityItemDTOcs>();

    }
}
