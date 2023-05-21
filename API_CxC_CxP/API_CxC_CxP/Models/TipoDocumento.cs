using System;
using System.Collections.Generic;

namespace API_CxC_CxP.Models;

public partial class TipoDocumento
{
    public int CodigoTipoDocumento { get; set; }

    public string? DescripcionTipoDocumento { get; set; }

    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();
}
