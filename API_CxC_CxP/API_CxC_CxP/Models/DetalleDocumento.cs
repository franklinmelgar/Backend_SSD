using System;
using System.Collections.Generic;

namespace API_CxC_CxP.Models;

public partial class DetalleDocumento
{
    public string? NumeroDocumento { get; set; }

    public int? CodigoProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public virtual Producto? CodigoProductoNavigation { get; set; }

    public virtual Documento? NumeroDocumentoNavigation { get; set; }
}
