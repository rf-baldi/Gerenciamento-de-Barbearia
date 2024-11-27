using System;
using System.Collections.Generic;
using System.IO;

namespace Barbearia; 
 public class Corte
    {
        public string NomeCorte { get; }
        public double PrecoCorte { get; }

        public Corte(string nomeCorte, double precoCorte)
        {
            NomeCorte = nomeCorte;
            PrecoCorte = precoCorte;
        }
    }