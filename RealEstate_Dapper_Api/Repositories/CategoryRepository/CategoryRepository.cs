﻿using RealEstate_Dapper_Api.Dtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using Dapper;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category (CategoryName,CategoryStatus) values (@categoryName,@categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);
            using (var connection= _context.CreateConnection()) 
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

		public async void DeleteCategory(int id)
		{
            string query = "Delete From Category Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection= _context.CreateConnection()) 
            {
                await connection.ExecuteAsync(query,parameters);
            }
		}

		public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";
            using(var connection= _context.CreateConnection()) 
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

		public async void UpdateCategory(UpdateCategoryDto categoryDto)
		{
            string query = "Update Category Set CategoryName=@categoryName,CategoryStatus=@categoryStatus where CategoryID=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName",categoryDto.CategoryName);
            parameters.Add("@categoryStatus", categoryDto.CategoryStatus);
            parameters.Add("@categoryID", categoryDto.CategoryID);
            using ( var connection= _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
		}
	}
}
