using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBDTask8.Models;

[PrimaryKey("IdCountry", "IdTrip")]
[Table("Country_Trip")]
public partial class CountryTrip
{
    [Key]
    public int IdCountry { get; set; }

    [Key]
    public int IdTrip { get; set; }
}
