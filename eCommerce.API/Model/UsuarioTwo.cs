using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.API.Models
{
    [Table("Usuarios")]
    public class UsuarioTwo
    {
        [Key]
        public int Cod { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string NomeCompletoMae { get; set; }
        public string Situacao { get; set; }
        public DateTimeOffset DataCadastro { get; set; }

        public Contato Contato { get; set; }

        public ICollection<EnderecoEntrega> EnderecosEntrega { get; set; }

        public ICollection<Departamento> Departamentos { get; set; }
    }
}
