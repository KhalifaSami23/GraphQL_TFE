using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.GraphQL.Properties
{
    public class PropertyInput
    {

        #nullable enable
        public record AddPropertyInput(int idOwner, string? description, string? address, int? rentCost);
        public record UpdatePropertyInput(int idProperty, int? idOwner, string? description, string? address, int? rentCost);
        public record DeletePropertyInput(int id);

        #nullable disable

    }
    
}