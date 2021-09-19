using System;

namespace LuisApp.Models
{
    public class Cliente
    {
        public long Cpf { get; set; }
        public int Id { get; set; }
        public int Rg { get; set; }
        public char DigRg { get; set; }
        public int Telefone { get; set; }
        public string Nome { get; set; }
    }
}
