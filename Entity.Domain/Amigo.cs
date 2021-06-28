using System;
using System.Collections.Generic;

namespace Entity.Domain
{
    public class Amigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }


        public int Idade()
        {
            DateTime hoje = DateTime.Today;
            int idade = hoje.Year - DataNascimento.Year;
            if (hoje < DataNascimento.AddYears(idade))
                idade--;
            return idade;
        }
        public int CalcularTempo()
        {

            DateTime proxNiver = DataNascimento.AddYears(Idade() + 1);
            TimeSpan difference = proxNiver - DateTime.Today;
            return Convert.ToInt32(difference.TotalDays);
        }

        public static implicit operator Amigo(List<Amigo> v)
        {
            throw new NotImplementedException();
        }
    }
}
