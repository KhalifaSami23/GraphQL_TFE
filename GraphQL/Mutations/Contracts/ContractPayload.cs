using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.GraphQL.Mutations.Contracts
{
    public class ContractPayload 
    {
        public record AddContractPayload(Contract contract);
        public record UpdateContractPayload(Contract contract);
        public record DeleteContractPayload(string message, Contract contract);
    }
    
}