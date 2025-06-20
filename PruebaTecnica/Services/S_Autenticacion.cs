using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.Entities;
using PruebaTecnica.Models;
using PruebaTecnica.Services.Interfaces;
using BCrypt.Net;

namespace PruebaTecnica.Services
{
    public class S_Autenticacion : I_Autenticacion
    {
        private readonly ApplicationDbContext _db;

        public S_Autenticacion(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Usuario?> Autenticar(AutenticarViewModel login)
        {
            
            var usuario =  await _db.Usuarios
                                   .FirstOrDefaultAsync(u => u.IdUsuario == login.Identificacion &&
                                                             u.Estado);

            if (usuario is null)
                return null;

            bool validarClave = BCrypt.Net.BCrypt.Verify(login.Clave, usuario.Clave);

            if (!validarClave) return null;
            return usuario;
        }
    }
}
