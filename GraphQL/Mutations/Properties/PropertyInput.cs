namespace TFE_Khalifa_Sami_2021.GraphQL.Mutations.Properties
{
    public class PropertyInput
    {

        #nullable enable
        public record AddPropertyInput(int IdOwner, string? Description, string? Address, int? RentCost);
        public record UpdatePropertyInput(int IdProperty, int? IdOwner, string? Description, string? Address, int? RentCost);
        public record DeletePropertyInput(int Id);

        #nullable disable

    }
    
}