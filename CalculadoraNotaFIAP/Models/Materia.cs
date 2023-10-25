using System.ComponentModel.DataAnnotations;

namespace CalculadoraNotaFIAP.Models
{
    public class Materia
    {
        [Display(Name = "Matéria")]
        public NomeMateria Nome { get; set; }

        public virtual ICollection<Nota> Nota { get; set; }

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
