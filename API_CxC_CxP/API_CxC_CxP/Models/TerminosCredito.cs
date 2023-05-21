using System;
using System.Collections.Generic;

namespace API_CxC_CxP.Models;

public partial class TerminosCredito
{
    public int CodigoTerminoCredito { get; set; }

    public string? DescripcionTerminoCredito { get; set; }

    public string? CantidadDias { get; set; }

    public virtual ICollection<LibretaDireccione> LibretaDirecciones { get; set; } = new List<LibretaDireccione>();
}
