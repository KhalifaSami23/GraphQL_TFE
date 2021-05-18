using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TFE_Khalifa_Sami_2021.DAL;
using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.REST.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly AppDbContext _context;
        // protected CancellationToken CancellationToken { get; }

        public ContractRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Contract> GetProperties()
        {
            return _context.CommandContract
                .Include(c => c.Property)
                .Include(c => c.User)
                .ToList();
        }

        public Contract GetPropertyById(int id)
        {
            return _context.CommandContract
                .Include(c => c.Property)
                .Include(c => c.User)
                .FirstOrDefault(contract => contract.IdContract == id);
        }

        public void PostProperty(Contract contract)
        {
            _context.CommandContract.Add(contract);
            SaveChanges();
        }

        public void UpdateProperty(Contract contract)
        {
            _context.CommandContract.Update(contract);
            SaveChanges();
        }

        public void DeleteProperty(int id)
        {
            _context.CommandContract.Remove(GetPropertyById(id));
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

    public interface IContractRepository
    {
        public IEnumerable<Contract> GetProperties();
        public Contract GetPropertyById(int id);
        public void PostProperty(Contract contract);
        public void UpdateProperty(Contract contract);
        public void DeleteProperty(int id);
        void SaveChanges();

    }
}