namespace TFE_Khalifa_Sami_2021.GraphQL.Mutations.Properties
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