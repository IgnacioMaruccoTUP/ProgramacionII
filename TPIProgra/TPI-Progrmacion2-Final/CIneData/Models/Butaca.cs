﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CIneData.Models;

public partial class Butaca
{
    public int IdButaca { get; set; }

    public int? IdSala { get; set; }

    public string Fila { get; set; }

    public int? Columna { get; set; }
    [JsonIgnore]
    public virtual ICollection<Entrada> Entrada { get; set; } = new List<Entrada>();

    public virtual Sala IdSalaNavigation { get; set; }
}