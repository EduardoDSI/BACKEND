using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestResponseModel
{
    public class ErrorRequest
    {
        public int Id { get; set; }

        public string? Url { get; set; }

        public string? Controller { get; set; }

        public string? Ip { get; set; }

        public string? Method { get; set; }

        public string? UserAgent { get; set; }

        public string? Host { get; set; }

        public string? ClassComponent { get; set; }

        public string? FunctionName { get; set; }

        public int? LineNumber { get; set; }

        public string? Error1 { get; set; }

        public string? StackTrace { get; set; }

        public short? Status { get; set; }

        public string? Request { get; set; }

        public int? ErrorCode { get; set; }

        public int? IdPersona { get; set; }

        public int? UsuarioCrea { get; set; }

        public int? UsuarioActualiza { get; set; }

        public DateTime? FechaCrea { get; set; }

        public DateTime? FechaActualiza { get; set; }

        //public virtual Persona? IdPersonaNavigation { get; set; }

        //public virtual Usuario? UsuarioActualizaNavigation { get; set; }

        //public virtual Usuario? UsuarioCreaNavigation { get; set; }
    }
}
