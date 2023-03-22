using NewUpstorm.Domain.Enums;

namespace NewUpstorm.Service.DTOs
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
        public string City { get; set; }
    }
}
