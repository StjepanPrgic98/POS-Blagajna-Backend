using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS_Blagajna_Backend.DTOs.IdentityDTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string TokenString { get; set; }
    }
}