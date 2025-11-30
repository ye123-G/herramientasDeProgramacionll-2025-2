using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.application.Adapters.Out
{
    internal class SimpleValidator
    {

        private readonly List<string> _errors = new();

        public void Require(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
                _errors.Add($"El campo '{fieldName}' es obligatorio.");
        }

        public void Require(int value, string fieldName)
        {
            if (value <= 0)
                _errors.Add($"El campo '{fieldName}' es obligatorio.");
        }

        public void Require(DateTime value, string fieldName)
        {
            if (value == default)
                _errors.Add($"El campo '{fieldName}' es obligatorio.");
        }

        public void RequireEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) ||
                !email.Contains("@") ||
                !email.Contains("."))
                _errors.Add("El correo electrónico no es válido.");
        }

        public void MinLength(string value, int length, string fieldName)
        {
            if (!string.IsNullOrEmpty(value) && value.Length < length)
                _errors.Add($"El campo '{fieldName}' debe tener al menos {length} caracteres.");
        }

        public void MaxLength(string value, int length, string fieldName)
        {
            if (!string.IsNullOrEmpty(value) && value.Length > length)
                _errors.Add($"El campo '{fieldName}' debe tener máximo {length} caracteres.");
        }

        public void RequireFutureDate(DateTime date, string fieldName)
        {
            if (date <= DateTime.Now)
                _errors.Add($"El campo '{fieldName}' debe ser una fecha futura.");
        }

        public void RequireNumeric(string value, string fieldName)
        {
            if (!long.TryParse(value, out _))
                _errors.Add($"El campo '{fieldName}' debe ser numérico.");
        }

        public bool HasErrors() => _errors.Any();

        public string GetErrors() => string.Join("\n", _errors);
    }

  

}
