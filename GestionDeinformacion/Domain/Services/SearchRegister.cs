using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Services
{
    internal class SearchRegister
    {
        private readonly IRegisterPort registerPort;

        public SearchRegister(IRegisterPort registerPort) { this.registerPort = registerPort; }

        public Register? FindById(string id)
        {
            var existing = registerPort.FindById(id); if (existing == null) { throw new Exception("Registro no encontrado."); }
            return existing;
        }
    }

    public class Register
    {
        public object PatientId { get; internal set; }
    }
}