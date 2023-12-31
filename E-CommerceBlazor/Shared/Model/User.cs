﻿namespace E_CommerceBlazor.Shared.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; } = "User";
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public List<Order>? Orders { get; set; }
        public Address? Address { get; set; }
    }
}
