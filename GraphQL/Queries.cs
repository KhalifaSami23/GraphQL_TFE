using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using TFE_Khalifa_Sami_2021.DAL;
using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.GraphQL
{
    public class Queries
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the Users.")]
        public IQueryable<User> GetUsers([ScopedService] AppDbContext context)
        {
            return context.CommandUser;
        }
        
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the Properties.")]
        public IQueryable<Property> GetProperties([ScopedService] AppDbContext context)
        {
            return context.CommandProperty;
        }
        
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the Contracts.")]
        public IQueryable<Contract> GetContracts([ScopedService] AppDbContext context)
        {
            return context.CommandContract;
        }
    }
}