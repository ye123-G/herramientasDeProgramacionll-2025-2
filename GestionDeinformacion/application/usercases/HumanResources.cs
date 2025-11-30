using GestionDeinformacion.Domain.Services;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.application.usercases
{
    internal class HumanResources
    {
        private readonly CreateEmployee createEmployee;

        public HumanResources(CreateEmployee createEmployee)
        {
            this.createEmployee = createEmployee;
        }

        public void CreateEmployeeUser(
            string documentNumber,
            string fullName,
            DateTime birthDate,
            string email,
            string phone,
            string address,
            string role,
            string username,
            string password)
        {
            // Llama directamente al método Create con los parámetros requeridos
            createEmployee.Create(
                fullName,
                documentNumber,
                email,
                phone,
                birthDate,
                address,
                role,
                username,
                password
            );
        }
    }
}
