using MongoDB.Bson.Serialization.Attributes;

namespace SistemaPedidosYa.Schemes.DTO
{
    public class UsuarioDTO
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string NombreCompleto { get; set; } = string.Empty;

        public string NombreUsuario { get; set; } = string.Empty; // El que usarán para el Login

        public string Password { get; set; } = string.Empty; // En un sistema real esto iría encriptado

        public string Rol { get; set; } = "Mesero"; // Valores: "Admin", "Mesero", "Cocina"

        public bool Activo { get; set; } = true;
    }
}
