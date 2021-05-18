using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.GraphQL.Mutations.Contracts
{
    public class ContractsInput
    {
        public record AddContractInput(int IdProp, int IdUser, int GuaranteeAmount);
        public record UpdateContractInput(int IdContract, float GuaranteeAmount, int? IdProperty, int? IdUser);
        public record DeleteContractInput(int Id);

    }
    
}