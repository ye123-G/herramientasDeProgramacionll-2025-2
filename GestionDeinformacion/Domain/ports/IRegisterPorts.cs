using GestionDeinformacion.Domain.Services;

namespace GestionDeinformacion.Domain.ports
{
    internal interface IRegisterPort
    {
        Register? FindById(string id);
    }
}