﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CIneData.Models;

public partial class Sala
{
    public int IdSala { get; set; }

    public bool? Activa { get; set; }

    [JsonIgnore]
    public virtual ICollection<Butaca> Butacas { get; set; } = new List<Butaca>();

    [JsonIgnore]
    public virtual ICollection<Funcione> Funciones { get; set; } = new List<Funcione>();
}