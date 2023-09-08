namespace API.Dtos.Request
{
    public class UserCreateDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime Dob { get; set; }
        public bool IsVet { get; set; }
    }
}
