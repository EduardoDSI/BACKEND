using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestResponseModel
{
    public class LoginRequest
    {
        [Required]
        [StringLength(20, MinimumLength = 13)]
        public string Usuario { get; set; } = "";
        [Required]
        [StringLength(30, MinimumLength = 17)]
        public string Contraseña { get; set; } = "";
    }
}