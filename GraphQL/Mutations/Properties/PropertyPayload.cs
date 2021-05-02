using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.GraphQL.Properties
{
    public class PropertyPayload
    {
        public record AddPropertyPayload(Property property);
        public record UpdatePropertyPayload(Property property);
        public record DeletePropertyPayload(string message, Property property);

    }
    
}