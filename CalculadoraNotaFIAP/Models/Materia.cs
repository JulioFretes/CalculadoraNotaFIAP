using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculadoraNotaFIAP.Models
{
    public class Materia
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Matéria")]
        public NomeMateria Nome { get; set; }

        public Decimal MediaFinal { get; set; }        

        public int Faltas { get; set; }
        [Display(Name = "Quantidade de Aulas")]
        public int QuantidadeAulas { get; set; }

        public virtual IList<Nota> Notas { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }

    }
    public enum NomeMateria
    {
        [Display(Name = "COMPLIANCE & QUALITY ASSURANCE")]
        Compliance,

        [Display(Name = "DATABASE APPLICATION & DATA SCIENCE")]
        Database,

        [Display(Name = "DEVOPS TOOLS & CLOUD COMPUTING")]
        Devops,

        [Display(Name = "DIGITAL BUSINESS ENABLEMENT")]
        Digital,

        [Display(Name = "DISRUPTIVE ARCHITECTURES: IT, IOB & IA")]
        IOT,

        [Display(Name = "ENTERPRISE APPLICATION DEVELOPMENT")]
        Enterprise,

        [Display(Name = "HYBRID MOBILE APP DEVELOPMENT")]
        Hybrid
    }
}
