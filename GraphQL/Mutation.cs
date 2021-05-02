using System;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using TFE_Khalifa_Sami_2021.DAL;
using TFE_Khalifa_Sami_2021.Models;
using static TFE_Khalifa_Sami_2021.GraphQL.Mutations.Contracts.ContractPayload;
using static TFE_Khalifa_Sami_2021.GraphQL.Mutations.Contracts.ContractsInput;
using static TFE_Khalifa_Sami_2021.GraphQL.Properties.PropertyInput;
using static TFE_Khalifa_Sami_2021.GraphQL.Properties.PropertyPayload;
using static TFE_Khalifa_Sami_2021.GraphQL.Users.UserInput;
using static TFE_Khalifa_Sami_2021.GraphQL.Users.UserPayload;

namespace TFE_Khalifa_Sami_2021.GraphQL
{
    public class Mutation
    {
        /* private readonly AppDbContext _context;
        public Mutation(AppDbContext context)
        {
            _context = context;
        } */

        /*
         * User
        */
        
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddUserPayload> addUserAsync(AddUserInput input, [ScopedService] AppDbContext _context)
        {
            User user = new User
            {
                Name = input.name,
                Surname = "Castafiore",
                Address = input.address,
                DateOfBirth = DateTime.Now
            };
            await _context.CommandUser.AddAsync(user);
            await _context.SaveChangesAsync();
            return new AddUserPayload(user);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<UpdateUserPayload> updateUserAsync(UpdateUserInput input, [ScopedService] AppDbContext _context)
        {
            User user = input.user;
            user.DateOfBirth = user.DateOfBirth ?? DateTime.Now;
            user.Surname = user.Surname ?? "Jamilo";

            _context.CommandUser.Update(user);
            await _context.SaveChangesAsync();
            return new UpdateUserPayload(user);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeleteUserPayload> deleteUserAsync(DeleteUserInput input, [ScopedService] AppDbContext _context)
        {
            User user = _context.CommandUser.FirstOrDefault(p => p.IdUser == input.id);
            _context.CommandUser.Remove(user);
            await _context.SaveChangesAsync();
            return new DeleteUserPayload($"Record with id : '{input.id}' Removed !", user);
        }

        /*
         * Property
        */

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPropertyPayload> addPropertyAsync(AddPropertyInput input, [ScopedService] AppDbContext _context)
        {
            Property property = new Property
            {
                IdOwner = input.idOwner,
                Description = input.description,
                Address = input.address,
                RentCost = input.rentCost,
                FixedChargesCost = 456
            };
            await _context.CommandProperty.AddAsync(property);
            await _context.SaveChangesAsync();
            return new AddPropertyPayload(property);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<UpdatePropertyPayload> updatePropertyAsync(UpdatePropertyInput input, [ScopedService] AppDbContext _context)
        {
            Property property = _context.CommandProperty.FirstOrDefault(p => p.IdProperty == input.idProperty);
            property.IdOwner = input.idOwner ?? property.IdOwner;
            property.Address = input.address ?? property.Address;
            property.Description = input.description ?? property.Description;
            property.RentCost = input.rentCost ?? property.RentCost;

            _context.CommandProperty.Update(property);
            await _context.SaveChangesAsync();
            return new UpdatePropertyPayload(property);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeletePropertyPayload> deletePropertyAsync(DeletePropertyInput input, [ScopedService] AppDbContext _context)
        {
            Property property = _context.CommandProperty.FirstOrDefault(p => p.IdProperty == input.id);
            _context.CommandProperty.Remove(property);
            await _context.SaveChangesAsync();
            return new DeletePropertyPayload($"Record with id : '{input.id}' Removed !", property);
        }

        /*
         * Contract
        */

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddContractPayload> addContractAsync(AddContractInput input, [ScopedService] AppDbContext _context)
        {
            Contract contract = new Contract
            {
                IdProperty = input.idProp,
                IdUser = input.idUser,
                GuaranteeAmount = input.GuaranteeAmount,
                BeginContract = DateTime.Now,
                SignatureDate = DateTime.Now,
                EndContract = new DateTime(2050,12,31)
            };
            await _context.CommandContract.AddAsync(contract);
            await _context.SaveChangesAsync();
            return new AddContractPayload(contract);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<UpdateContractPayload> updateContractAsync(UpdateContractInput input, [ScopedService] AppDbContext _context)
        {
            Contract contract = _context.CommandContract.FirstOrDefault(p => p.IdContract == input.idContract);
                contract.GuaranteeAmount = input.guaranteeAmount;
                contract.IdProperty = input?.idProperty ?? contract.IdProperty;
                contract.IdUser = input?.idUser ?? contract.IdUser;

            _context.CommandContract.Update(contract);
            await _context.SaveChangesAsync();
            return new UpdateContractPayload(contract);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeleteContractPayload> deleteContractAsync(DeleteContractInput input, [ScopedService] AppDbContext _context)
        {
            Contract contract = _context.CommandContract.FirstOrDefault(p => p.IdContract == input.id);
            _context.CommandContract.Remove(contract);
            await _context.SaveChangesAsync();
            return new DeleteContractPayload($"Record with id : '{input.id}' Removed !", contract);
        }

    }
}