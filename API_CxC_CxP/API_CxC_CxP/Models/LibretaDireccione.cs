using System;
using System.Collections.Generic;

namespace API_CxC_CxP.Models;

public partial class LibretaDireccione
{
    public int CodigoLibreta { get; set; }

    public string? NombreLibreta { get; set; }

    public int? CodigoTerminoCredito { get; set; }

    public int? CodigoCategoria { get; set; }

    public int? CodigoTipo { get; set; }

    public string? CiudadOrigen { get; set; }

    public virtual CategoriaLibretum? CodigoCategoriaNavigation { get; set; }

    public virtual TerminosCredito? CodigoTerminoCreditoNavigation { get; set; }

    public virtual TipoLibretum? CodigoTipoNavigation { get; set; }

    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();
}
