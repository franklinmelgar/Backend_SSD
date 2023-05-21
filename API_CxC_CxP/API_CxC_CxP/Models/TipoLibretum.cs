using System;
using System.Collections.Generic;

namespace API_CxC_CxP.Models;

public partial class TipoLibretum
{
    public int CodigoTipo { get; set; }

    public string? DescripcionTipo { get; set; }

    public virtual ICollection<LibretaDireccione> LibretaDirecciones { get; set; } = new List<LibretaDireccione>();
}
