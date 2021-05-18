using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.GraphQL.Mutations.Contracts
{
    public class ContractPayload 
    {
        public record AddContractPayload(Contract Contract);
        public record UpdateContractPayload(Contract Contract);
        public record DeleteContractPayload(string Message, Contract Contract);
    }
    
}