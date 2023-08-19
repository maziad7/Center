using center.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace center.RepositoryInterface
{
    public interface ITreatmentRepository
    {
        Task<IEnumerable<Treatment>> GetTreatments();
        Task<Treatment> GetTreatmentById(int id);
        Task AddTreatment(Treatment treatment);
        Task UpdateTreatment(Treatment treatment);
        Task DeleteTreatment(int id);
    }
}
