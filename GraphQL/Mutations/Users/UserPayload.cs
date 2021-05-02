using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.GraphQL.Users
{
    public class UserPayload
    {
        public record AddUserPayload(User user);
        public record UpdateUserPayload(User user);
        public record DeleteUserPayload(string message, User user);
        
    }
    
}