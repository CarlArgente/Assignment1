using Assignment1.DataContext;
using Assignment1.DataContextModels;
using Assignment1.DTOs;
using Assignment1.Models;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Web.Http.ModelBinding;

namespace Assignment1.Repositories.Department
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IMapper _mapper;
        private readonly SampleDBContext _dbContext;
        public DepartmentRepository(IMapper mapper, SampleDBContext dbContext) 
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        #region Getter
        public async Task<IEnumerable<DataContextModels.Department>> Get () => await _dbContext.Departments.ToListAsync();
        public async Task<DataContextModels.Department> GetById(int id) => await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);
        #endregion
        public async Task<DepartmentDto> Save(DepartmentDto department)
        {
            DataContextModels.Department model  = _mapper.Map<DataContextModels.Department>(department);
            if(model == null)
                throw new Exception("Department is Invalid");

            _dbContext.Departments.Add(model);
            await _dbContext.SaveChangesAsync();
            return department;
        }
        public async Task<DepartmentDto> Update(int id,DepartmentDto department)
        {
            DataContextModels.Department model = _mapper.Map<DataContextModels.Department>(department);

            if (model == null)
                throw new Exception("Department is Invalid");

            model.Id = id;

            _dbContext.Departments.Update(model);

            await _dbContext.SaveChangesAsync();
            return department;
        }
        public async Task<DepartmentDto> Delete(int id)
        {
            DataContextModels.Department dept = await _dbContext.Departments.FirstOrDefaultAsync(m => m.Id == id);
            DataContextModels.Department model = _mapper.Map<DataContextModels.Department>(dept);

            _dbContext.Departments.Remove(model);

            await _dbContext.SaveChangesAsync();
            return new DepartmentDto();
        }
    }
}
