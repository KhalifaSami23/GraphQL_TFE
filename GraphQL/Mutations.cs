using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using TFE_Khalifa_Sami_2021.DAL;
using TFE_Khalifa_Sami_2021.GraphQL.Contracts;
using TFE_Khalifa_Sami_2021.GraphQL.Properties;
using TFE_Khalifa_Sami_2021.GraphQL.Users;
using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.GraphQL
{
    public class Mutations
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddUserPayload> addUserAsync(AddUserInput input,
            [ScopedService] AppDbContext context)
        {
            User user = new User
            {
                Name = input.Name
            };
            await context.CommandUser.AddAsync(user);
            await context.SaveChangesAsync();
            return new AddUserPayload(user);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPropertyPayload> addPropertyAsync(AddPropertyInput input,
            [ScopedService] AppDbContext context)
        {
            Property property = new Property
            {
                Description = input.Description
            };
            await context.CommandProperty.AddAsync(property);
            await context.SaveChangesAsync();
            return new AddPropertyPayload(property);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddContractPayload> addContractAsync(AddContractInput input,
            [ScopedService] AppDbContext context)
        {
            Contract contract = new Contract
            {
                GuaranteeAmount = input.GuaranteeAmount
            };
            await context.CommandContract.AddAsync(contract);
            await context.SaveChangesAsync();
            return new AddContractPayload(contract);

        }
    }
    
}