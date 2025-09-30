namespace GestionDeinformacion.Domain.Services
{
    internal interface IRegisterPort
    {
        Register? FindById(string id);
    }
}