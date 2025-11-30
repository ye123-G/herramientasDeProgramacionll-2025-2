using GestionDeinformacion.application.Adapters.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.application.Adapters.Validators
{
    internal class PasswordValidator :SimpleValidator 
    {
        
            public static string Validate(string password,
                int minLength = 8,
                int minUpper = 1,
                int minLower = 1,
                int minDigits = 1,
                int minSpecial = 0)
            {
                var errors = new List<string>();

                if (string.IsNullOrWhiteSpace(password))
                    return "La contraseña es obligatoria.";

                if (password.Length < minLength)
                    errors.Add($"La contraseña debe tener al menos {minLength} caracteres.");

                int upper = password.Count(char.IsUpper);
                int lower = password.Count(char.IsLower);
                int digits = password.Count(char.IsDigit);
                int special = password.Count(c => !char.IsLetterOrDigit(c));

                if (upper < minUpper)
                    errors.Add($"La contraseña debe tener al menos {minUpper} letra(s) mayúscula(s).");

                if (lower < minLower)
                    errors.Add($"La contraseña debe tener al menos {minLower} letra(s) minúscula(s).");

                if (digits < minDigits)
                    errors.Add($"La contraseña debe tener al menos {minDigits} número(s).");

                if (special < minSpecial)
                    errors.Add($"La contraseña debe tener al menos {minSpecial} caracter(es) especial(es).");

                return errors.Any() ? string.Join("\n", errors) : string.Empty;
            }
        
    }
}
