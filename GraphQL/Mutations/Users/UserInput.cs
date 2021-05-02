using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.GraphQL.Users
{
    public class UserInput
    {
        public record AddUserInput(string name, string address);
        public record UpdateUserInput(User user);
        public record DeleteUserInput(int id);

    }

}