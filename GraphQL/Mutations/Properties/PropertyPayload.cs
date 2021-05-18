using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.GraphQL.Mutations.Properties
{
    public class PropertyPayload
    {
        public record AddPropertyPayload(Property Property);
        public record UpdatePropertyPayload(Property Property);
        public record DeletePropertyPayload(string Message, Property Property);

    }
    
}