using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Services
{
    internal class CreateEmployee
    {
        private readonly IEmployeePort employeePort; 

        public CreateEmployee(IEmployeePort employeePort)
        {
            this.employeePort = employeePort;
        }

        public Employee Create(
            string fullName,
            string documentNumber,
            string email,
            string phone,
            DateTime birthDate,
            string address,
            string role,
            string userName,
            string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("El nombre completo es obligatorio.");

            if (string.IsNullOrWhiteSpace(documentNumber))
            {
                throw new ArgumentException("La cédula es obligatoria.");
            }

       
   
            if (string.IsNullOrWhiteSpace(email) ||
                !email.Contains("@") || !email.Contains("."))
                throw new ArgumentException("El correo electronico no es valido.");

            if (string.IsNullOrWhiteSpace(phone) ||
                phone.Length < 1 || phone.Length > 10 ||
                !long.TryParse(phone, out _))
                throw new ArgumentException("El telefono debe tener entre 1 y 10 digitos numericos.");

            var edad = DateTime.Today.Year - birthDate.Year;
            if (birthDate > DateTime.Today.AddYears(-edad)) edad--;
            if (edad < 0 || edad > 150)
                throw new ArgumentException("La edad debe ser menor o igual a 150 años.");

            if (string.IsNullOrWhiteSpace(address) || address.Length > 30)
                throw new ArgumentException("La dirección no puede superar 30 caracteres.");

            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("El rol es obligatorio.");

            if (string.IsNullOrWhiteSpace(userName) || userName.Length > 15)
                throw new ArgumentException("El nombre de usuario es obligatorio y max. 15 caracteres.");

            // Validar existencia de nombre de usuario
            var tempEmployeeUser = new Employee { DisplayName = userName };
            if (employeePort.FindByDocument(tempEmployeeUser) != null)
                throw new ArgumentException("El nombre de usuario ya existe.");

            if (string.IsNullOrWhiteSpace(plainPassword))
                throw new ArgumentException("La contraseña es obligatoria.");

            if (plainPassword.Length < 8 ||
                !plainPassword.Any(char.IsUpper) ||
                !plainPassword.Any(char.IsDigit) ||
                !plainPassword.Any(c => !char.IsLetterOrDigit(c)))
                throw new ArgumentException("La contraseña no cumple con los requisitos.");

            var employee = new Employee
            {
                DisplayName = fullName,
               
             
                AdditionalData = new Dictionary<string, object>
                    {
                        { "Email", email },
                        { "Phone", phone },
                        { "BirthDate", birthDate },
                        { "Address", address },
                        { "Role", role },
                        { "UserName", userName },
                        { "PasswordHash", HashPassword(plainPassword) },
                        { "Active", true }
                    }
            };

            employeePort.Save(employee);
            return employee;
        }

        private string HashPassword(string plain)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(plain);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }

}

