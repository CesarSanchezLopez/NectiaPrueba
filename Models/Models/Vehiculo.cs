using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models;

public partial class Vehiculo
{
   // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Chasis { get; set; }

    public int? Kilometraje { get; set; }

    public string? Color { get; set; }

    public decimal? Valor { get; set; }

    public string? Tipo { get; set; }

    public string? Modelo { get; set; }

    public string? Marca { get; set; }

    public string? Placa { get; set; }

    public string? Version { get; set; }
}
