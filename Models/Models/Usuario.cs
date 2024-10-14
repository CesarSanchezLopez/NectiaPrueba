using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Models;

public partial class Usuario
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Requerido")]
    public string User { get; set; } = null!;


  
    [Required(ErrorMessage = "Requerido")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Primer Nombre")]
    public string? PrimerNombre { get; set; }

    public string? SegundoNombre { get; set; }

    public string? Telefono { get; set; }

    public int? PerfilId { get; set; }

    public virtual Perfil? Perfil { get; set; }
}
