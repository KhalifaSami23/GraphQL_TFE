using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.GraphQL.Mutations.Users
{
    public class UserInput
    {
        public record AddUserInput(string Name, string Address);
        public record UpdateUserInput(User User);
        public record DeleteUserInput(int Id);

    }

}