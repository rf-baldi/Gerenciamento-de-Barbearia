using System;
using System.Collections.Generic;
using System.IO;

namespace Barbearia;

    public class Cliente : Pessoa
    {
        public string BarbeiroFavorito { get; }

        public Cliente(string nome, int idade, string cpf, string barbeiroFavorito) 
        : base(nome, idade, cpf)
        {
            BarbeiroFavorito = barbeiroFavorito;
        }
    }

