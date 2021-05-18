using HotChocolate;
using HotChocolate.Types;
using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public User onUserAdded([EventMessage] User user) => user;
        
        [Subscribe]
        [Topic]
        public Property onPropertyAdded([EventMessage] Property property) => property;
        
        [Subscribe]
        [Topic]
        public Contract onContractAdded([EventMessage] Contract contract) => contract;
        
    }
}