using MediatR;


namespace kpZleceniaWeb.Shared.User.Command
{
    public class DeleteUserCommand : IRequest
    {
        public string UserId { get; set; }
    }
}
