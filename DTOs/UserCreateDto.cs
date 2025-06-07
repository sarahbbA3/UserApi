namespace UserApi.DTOs
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<PhoneDto> Phones { get; set; }

    }
    public class PhoneDto
    {
        public string Number { get; set; }
        public string CityCode { get; set; }
        public string ContryCode { get; set; }
    }
}
