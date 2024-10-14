using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Perfil
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
