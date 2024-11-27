using System;
using System.Collections.Generic;
using System.IO;

namespace Barbearia;
    public class Pessoa
    {
        private string nome;
        private int idade;
        private string cpf;

        public string Nome
        {
            get { return nome; }
            private set { nome = value; }
        }

        public int Idade
        {
            get { return idade; }
            private set { idade = value; }
        }

        public string Cpf
        {
            get { return cpf; }
            private set { cpf = value; }
        }

        public Pessoa(string nome, int idade, string cpf)
        {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
        }
    }