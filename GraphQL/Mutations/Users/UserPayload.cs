using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.GraphQL.Mutations.Users
{
    public class UserPayload
    {
        public record AddUserPayload(User User);
        public record UpdateUserPayload(User User);
        public record DeleteUserPayload(string Message, User User);
        
    }
    
}