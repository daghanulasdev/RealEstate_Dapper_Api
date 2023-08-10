namespace RealEstate_Dapper_Api.Dtos
{
	public class GetByIDCategoryDto
	{
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public bool CategoryStatus { get; set; }
	}
}
