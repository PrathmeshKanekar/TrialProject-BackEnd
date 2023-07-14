using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trial_Project.Models;

[Table("sales")]
public partial class Sale
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("clientid")]
    public int? Clientid { get; set; }

    [Column("billamount")]
    public double? Billamount { get; set; }

    [ForeignKey("Clientid")]
    [InverseProperty("Sales")]
    public virtual Client? Client { get; set; }

    [InverseProperty("Sale")]
    public virtual ICollection<Saledetail> Saledetails { get; set; } = new List<Saledetail>();
}
