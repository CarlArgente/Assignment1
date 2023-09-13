using Assignment1.DTOs;

namespace Assignment1.Repositories.Department
{
    public interface IDepartmentRepository
    {
        Task<DepartmentDto> Delete(int id);
        Task<IEnumerable<DataContextModels.Department>> Get();
        Task<DataContextModels.Department> GetById(int id);
        Task<DepartmentDto> Save(DepartmentDto department);
        Task<DepartmentDto> Update(int id, DepartmentDto department);
    }
}