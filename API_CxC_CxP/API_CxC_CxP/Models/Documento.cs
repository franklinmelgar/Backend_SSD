using System;
using System.Collections.Generic;

namespace API_CxC_CxP.Models;

public partial class Documento
{
    public string NumeroDocumento { get; set; } = null!;

    public int? CodigoLibreta { get; set; }

    public int? CodigoTipoDocumento { get; set; }

    public DateTime? FechaDocumento { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public int? CodigoTerminoCredito { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? MontoIsv { get; set; }

    public decimal? MontoTotal { get; set; }

    public string? EstadoDocumento { get; set; }

    public virtual LibretaDireccione? CodigoLibretaNavigation { get; set; }

    public virtual TipoDocumento? CodigoTipoDocumentoNavigation { get; set; }
}
