using System;
using System.Collections.Generic;

namespace API_CxC_CxP.Models;

public partial class Producto
{
    public int CodigoProducto { get; set; }

    public string? DescripcionProducto { get; set; }

    public decimal? PrecioCompra { get; set; }

    public decimal? PrecioVenta { get; set; }

    public int? CodigoLibreta { get; set; }
}
