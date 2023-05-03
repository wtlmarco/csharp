using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

public class Imagem
{
    [Key]
    public int IdImagem { get; set; }

    [Required]
    [Display(Name ="Titulo da Imagem")]
    public string Titulo { get; set; }

    public int IdGaleria { get; set; }

    [ForeignKey("IdGaleria")]
    public Galeria Galeria { get; set; }

    [NotMapped, Required(ErrorMessage = "Imagem não enviada.")]
    [Display(Name = "Arquivo da Imagem")]
    public IFormFile ArquivoImagem { get; set; }

    [NotMapped]
    public string CaminhoImagem
    {
        get
        {
            var caminhoArquivoImagem = Path.Combine($"\\img\\", IdImagem.ToString("D6") + ".webp");

            return caminhoArquivoImagem;
        }
    }

}