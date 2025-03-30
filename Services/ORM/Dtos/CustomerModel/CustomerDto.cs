namespace Services.ORM.Dtos.CustomerDto
{
    public record CustomerDto
    {
        public string? FullName { get; set; }
        public string? MobileNumber { get; set; }
        public string? City { get; set; }
        public bool IsActive { get; set; }
    }
}
