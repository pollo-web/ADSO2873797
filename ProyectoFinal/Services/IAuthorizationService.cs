using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Services
{
    public interface IAuthorizationService
    {
        AuthResults Auth(string ususario, string pass, out Usuarios user);
    }

    public enum AuthResults
    {
        Success,
        PasswordNotMatch,
        NotExists,
        Error
    }
}
