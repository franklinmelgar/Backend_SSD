using System;
using System.Collections.Generic;

namespace API_CxC_CxP.Models;

public partial class CategoriaLibretum
{
    public int CodigoCategoria { get; set; }

    public string? DescripcionCategoria { get; set; }

    public virtual ICollection<LibretaDireccione> LibretaDirecciones { get; set; } = new List<LibretaDireccione>();
}
