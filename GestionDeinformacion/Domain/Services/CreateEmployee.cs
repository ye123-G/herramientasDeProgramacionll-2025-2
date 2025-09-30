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
        public Employee Create(string firstName, string lastName, string position, decimal salary)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("El nombre y el apellido son obligatorios.");
            }

            return new Employee
            {
                GivenName = firstName,
                Surname = lastName,
                JobTitle = position,
                AdditionalData = new Dictionary<string, object>
                    {
                        { "Salary", salary }
                    }
            };
        }
    }
}

