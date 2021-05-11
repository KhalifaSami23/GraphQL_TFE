using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using TFE_Khalifa_Sami_2021.DAL;
using TFE_Khalifa_Sami_2021.Models;
using static TFE_Khalifa_Sami_2021.GraphQL.Mutations.Contracts.ContractPayload;
using static TFE_Khalifa_Sami_2021.GraphQL.Mutations.Contracts.ContractsInput;
using static TFE_Khalifa_Sami_2021.GraphQL.Mutations.Properties.PropertyInput;
using static TFE_Khalifa_Sami_2021.GraphQL.Mutations.Properties.PropertyPayload;
using static TFE_Khalifa_Sami_2021.GraphQL.Mutations.Users.UserInput;
using static TFE_Khalifa_Sami_2021.GraphQL.Mutations.Users.UserPayload;

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
        public async Task<AddUserPayload> addUserAsync(
            AddUserInput input,
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken
            )
        {
            User user = new User
            {
                Name = input.name,
                Surname = "Castafiore",
                Address = input.address,
                DateOfBirth = DateTime.Now
            };
            await context.CommandUser.AddAsync(user, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await eventSender.SendAsync(nameof(Subscription.onUserAdded), user, cancellationToken);
            return new AddUserPayload(user);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<UpdateUserPayload> updateUserAsync(
            UpdateUserInput input,
            [ScopedService] AppDbContext context)
        {
            User user = input.user;
            user.DateOfBirth = user.DateOfBirth ?? DateTime.Now;
            user.Surname = user.Surname ?? "Jamilo";

            context.CommandUser.Update(user);
            await context.SaveChangesAsync();
            return new UpdateUserPayload(user);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeleteUserPayload> deleteUserAsync(
            DeleteUserInput input,
            [ScopedService] AppDbContext context)
        {
            User user = context.CommandUser.FirstOrDefault(p => p.IdUser == input.id);
            context.CommandUser.Remove(user);
            await context.SaveChangesAsync();
            return new DeleteUserPayload($"Record with id : '{input.id}' Removed !", user);
        }

        /*
         * Property
        */

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPropertyPayload> addPropertyAsync(
            AddPropertyInput input,
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken
            )
        {
            Property property = new Property
            {
                Description = input.description,
                Address = input.address,
                RentCost = input.rentCost,
                FixedChargesCost = 456
            };
            await context.CommandProperty.AddAsync(property, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await eventSender.SendAsync(nameof(Subscription.onPropertyAdded), property, cancellationToken);
            return new AddPropertyPayload(property);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<UpdatePropertyPayload> updatePropertyAsync(
            UpdatePropertyInput input,
            [ScopedService] AppDbContext context)
        {
            Property property = context.CommandProperty.FirstOrDefault(p => p.IdProperty == input.idProperty);
            property.Address = input.address ?? property.Address;
            property.Description = input.description ?? property.Description;
            property.RentCost = input.rentCost ?? property.RentCost;

            context.CommandProperty.Update(property);
            await context.SaveChangesAsync();
            return new UpdatePropertyPayload(property);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeletePropertyPayload> deletePropertyAsync(
            DeletePropertyInput input,
            [ScopedService] AppDbContext context)
        {
            Property property = context.CommandProperty.FirstOrDefault(p => p.IdProperty == input.id);
            context.CommandProperty.Remove(property);
            await context.SaveChangesAsync();
            return new DeletePropertyPayload($"Record with id : '{input.id}' Removed !", property);
        }

        /*
         * Contract
        */

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddContractPayload> addContractAsync(
            AddContractInput input,
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken
            )
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
            await context.CommandContract.AddAsync(contract, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await eventSender.SendAsync(nameof(Subscription.onContractAdded), contract, cancellationToken);
            return new AddContractPayload(contract);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<UpdateContractPayload> updateContractAsync(
            UpdateContractInput input,
            [ScopedService] AppDbContext context)
        {
            Contract contract = context.CommandContract.FirstOrDefault(p => p.IdContract == input.idContract);
                contract.GuaranteeAmount = input.guaranteeAmount;
                contract.IdProperty = input?.idProperty ?? contract.IdProperty;
                contract.IdUser = input?.idUser ?? contract.IdUser;

            context.CommandContract.Update(contract);
            await context.SaveChangesAsync();
            return new UpdateContractPayload(contract);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeleteContractPayload> deleteContractAsync(
            DeleteContractInput input,
            [ScopedService] AppDbContext context)
        {
            Contract contract = context.CommandContract.FirstOrDefault(p => p.IdContract == input.id);
            context.CommandContract.Remove(contract);
            await context.SaveChangesAsync();
            return new DeleteContractPayload($"Record with id : '{input.id}' Removed !", contract);
        }

    }
}