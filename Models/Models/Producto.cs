using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Marca { get; set; }

    public decimal? Valor { get; set; }

    public string? Descripcion { get; set; }

    public byte[]? Imagen { get; set; }

    public int? CategoriaId { get; set; }

    public virtual Categorium? Categoria { get; set; }
}
