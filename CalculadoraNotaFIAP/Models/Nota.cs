﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculadoraNotaFIAP.Models
{
    public class Nota
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Checkpoint 1")]
        public Decimal Cp1 { get; set; }
        [Display(Name = "Checkpoint 2")]
        public Decimal Cp2 { get; set; }
        [Display(Name = "Checkpoint 3")]
        public Decimal Cp3 { get; set; }

        [Display(Name = "Sprint 1")]
        public Decimal Sprint1 { get; set; }
        [Display(Name = "Sprint 2")]
        public Decimal Sprint2 { get; set; }

        [Display(Name = "Global Solution")]
        public Decimal GlobalSolution { get; set; }

        [Display(Name = "Media do primeiro semestre")]
        public Decimal NotaPrimeiroSemestre { get; set; }        

        [Display(Name = "Calcular nota mínima")]
        public bool Calcular { get; set; }

        public Decimal Media { get; set; }

        public Decimal MediaFinal { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
    }    
}