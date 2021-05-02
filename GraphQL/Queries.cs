using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using TFE_Khalifa_Sami_2021.DAL;
using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.GraphQL
{
    public class Queries
    {

        /* private readonly AppDbContext _context;
        public Queries(AppDbContext context)
        {
            _context = context;
        } */

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [GraphQLDescription("Gets All Users.")]
        public IQueryable<User> GetUsers([ScopedService] AppDbContext context)
        {
            return context.CommandUser.Include(p => p.PropertiesList);
        }
        
        [UseDbContext(typeof(AppDbContext))]
        [UseSorting]
        [GraphQLDescription("Gets All Properties.")]
        public IQueryable<Property> GetProperties([ScopedService] AppDbContext context)
        {
            return context.CommandProperty.Include(p => p.Owner);
        }
        
        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Gets All Contracts.")]
        public IQueryable<Contract> GetContracts([ScopedService] AppDbContext context)
        {
            return context.CommandContract
            .Include(p => p.User)
            .Include(p => p.Property);
        }
    }
}