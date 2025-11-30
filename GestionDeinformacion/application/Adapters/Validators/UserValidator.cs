using GestionDeinformacion.application.Adapters.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.application.Adapters.Validators
{
    internal class UserValidator : SimpleValidator
    {
        public ValidateRole(string role);
 
      
        public string ValidateRole(string role)
        {
            return StringNotNullOrEmpty(role, "Rol");
        }

        private string StringNotNullOrEmpty(string role, string v)
        {
            throw new NotImplementedException();
        }

        public string ValidateUserName(string username)
        {
            return StringNotNullOrEmpty(username, "Nombre de Usuario");
        }
        public string ValidatePassword(string password)
        {
            return ValidatePassWord(password, "Contraseña");
        }
 
      
    }
}



        
    

