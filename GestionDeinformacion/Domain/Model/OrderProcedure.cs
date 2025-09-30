using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Model
{
    internal class OrderProcedure
    {
        private long idProcedure;
        private string nameProcedure;
        private int amount;
        private DateTime dateFrequency;
        private bool requiresSpecialist;
        private string idSpecialist;
        private long item;

        public OrderProcedure() { }

        public long IdProcedure { get => idProcedure; set => idProcedure = value; }
        public string NameProcedure { get => nameProcedure; set => nameProcedure = value; }
        public int Amount { get => amount; set => amount = value; }
        public DateTime DateFrequency { get => dateFrequency; set => dateFrequency = value; }
        public bool RequiresSpecialist { get => requiresSpecialist; set => requiresSpecialist = value; }
        public string IdSpecialist { get => idSpecialist; set => idSpecialist = value; }
        public long Item { get => item; set => item = value; }
    }
}
