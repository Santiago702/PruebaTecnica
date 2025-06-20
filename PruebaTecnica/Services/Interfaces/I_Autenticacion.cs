using PruebaTecnica.Entities;
using PruebaTecnica.Models;

namespace PruebaTecnica.Services.Interfaces
{
    public interface I_Autenticacion
    {
        /// <summary>
        /// Devuelve el usuario autenticado o null si las credenciales son inválidas.
        /// </summary>
        Task<Usuario?> Autenticar(AutenticarViewModel login);
    }
}
