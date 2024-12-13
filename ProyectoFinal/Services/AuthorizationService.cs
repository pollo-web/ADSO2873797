using ProyectoFinal.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoFinal.Security;
using ProyectoFinal.Models;

namespace ProyectoFinal.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly ProyectoFinalContext db = new ProyectoFinalContext();
        private readonly IPasswordEncripter _passordEncripter = new PasswordEncripter();


        public AuthResults Auth(string Usuario, string pass, out Usuarios user)
        {
            // Busca al usuario en la base de datos por su nombre de usuario
            user = db.Usuarios.SingleOrDefault(x => x.Usuario == Usuario);

            // Si el usuario no existe, retorna el resultado correspondiente
            if (user == null)
                return AuthResults.NotExists;


            // Encripta la contraseña proporcionada usando las claves del usuario
            pass = _passordEncripter.Encript(pass, new List<byte[]>
            {
                user.HashKey, // Usa 'users' para acceder a las propiedades del usuario
                user.HashIV
            });

            // Compara la contraseña encriptada con la almacenada en la base de datos
            if (pass != user.Pass)
                return AuthResults.PasswordNotMatch;

            // Si todo está correcto, retorna éxito
            return AuthResults.Success;
        }
    }

}