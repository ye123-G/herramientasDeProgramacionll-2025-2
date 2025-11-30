using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Model
{
    internal class DiagnosticHelp
    {
        private string idAid;
        private string nameAid;
        private int amount;
        private bool requiresSpecialistAid;
        private string idSpecialistAid;
        private long itemAid;

        public DiagnosticHelp() { }

        public string IdAid { get => idAid; set => idAid = value; }
        public string NameAid { get => nameAid; set => nameAid = value; }
        public int Amount { get => amount; set => amount = value; }
        public bool RequiresSpecialistAid { get => requiresSpecialistAid; set => requiresSpecialistAid = value; }
        public string IdSpecialistAid { get => idSpecialistAid; set => idSpecialistAid = value; }
        public long ItemAid { get => itemAid; set => itemAid = value; }
        public required List<MedicationOrder>? MedicationOrder { get; set; }
        public required List<ProcedureOrder>? Procedures { get; set; }
    }
}
