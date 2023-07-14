using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trial_Project.Models;

[Table("saledetails")]
public partial class Saledetail
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("saleid")]
    public int? Saleid { get; set; }

    [Column("productid")]
    public int? Productid { get; set; }

    [Column("price")]
    public double? Price { get; set; }

    [Column("quantity")]
    public int? Quantity { get; set; }

    [Column("total")]
    public double? Total { get; set; }

    [ForeignKey("Productid")]
    [InverseProperty("Saledetails")]
    public virtual Product? Product { get; set; }

    [ForeignKey("Saleid")]
    [InverseProperty("Saledetails")]
    public virtual Sale? Sale { get; set; }
}
