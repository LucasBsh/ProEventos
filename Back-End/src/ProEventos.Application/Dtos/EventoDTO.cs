using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Application.Dtos
{
    public class EventoDTO
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        [Required(ErrorMessage ="O campo {0} é obrigatório.")]
        public string Tema { get; set; }
        [Required]
        public int QtdPessoas { get; set; }
        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$",
            ErrorMessage = "Não é uma imagem válida.")]
        public string ImagemURL { get; set; }
        [Phone(ErrorMessage = "O campo {0} está com um número inválido")]

        public string Telefone { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Formato de email inválido")]
        public string Email { get; set; }
        public IEnumerable<LoteDTO> Lote { get; set; }

        public IEnumerable<RedeSocialDTO> RedesSociais { get; set; }

        public IEnumerable<PalestranteDTO> Palestrantes { get; set; }
    }
}
