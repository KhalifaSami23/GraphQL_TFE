using System.Collections.Generic;
using System.Linq;
using TFE_Khalifa_Sami_2021.DAL;
using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.REST.Repositories
{
    public class PropertyRepository: IPropertyRepository
    {
        private readonly AppDbContext _context;

        public PropertyRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Property> GetProperties()
        {
            return _context.CommandProperty.ToList();
        }

        public Property GetPropertyById(int id)
        {
            return _context.CommandProperty.FirstOrDefault(property => property.IdProperty == id);
        }

        public void PostProperty(Property property)
        {
            _context.CommandProperty.Add(property);
            SaveChanges();
        }

        public void UpdateProperty(Property property)
        {
            _context.CommandProperty.Update(property);
            SaveChanges();
        }

        public void DeleteProperty(int id)
        {
            _context.CommandProperty.Remove(GetPropertyById(id));
            SaveChanges();
        }

        public async void SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }

    public interface IPropertyRepository
    {
        public IEnumerable<Property> GetProperties();
        public Property GetPropertyById(int id);
        public void PostProperty(Property property);
        public void UpdateProperty(Property property);
        public void DeleteProperty(int id);
        void SaveChanges();
    }
}