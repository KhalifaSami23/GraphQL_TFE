using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.GraphQL.Mutations.Contracts
{
    public class ContractsInput
    {
        public record AddContractInput(int idProp, int idUser, int GuaranteeAmount);
        public record UpdateContractInput(int idContract, float guaranteeAmount, int? idProperty, int? idUser);
        public record DeleteContractInput(int id);

    }
    
}