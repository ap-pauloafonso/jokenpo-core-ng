using System;

namespace Business.Dtos
{
    public class LoginResponseDto
    {
        public string user { get; set; }
        public string email { get; set; }

        public DateTime? dataConfirmacao { get; set; }
    }
}