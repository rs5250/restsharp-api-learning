using System;

namespace TestProject1.Model
{
    public class Users
    {
        // Request Payload data
        
        public string email    { get; set; }
        public string password { get; set; }
        
        
        // Response  data
        
        public string id    { get; set; }
        public string token { get; set; }
    }
}