using System;
using System.Collections.Generic;
using System.IO;

namespace Barbearia;

public class Barbeiro : Pessoa
    {
        public List<Corte> Cortes { get; } = new List<Corte>();

        public Barbeiro(string nome, int idade, string cpf)
        : base(nome, idade, cpf) { }

        public void AdicionarCorte(Corte corte)
        {
            Cortes.Add(corte);
        }
    }
