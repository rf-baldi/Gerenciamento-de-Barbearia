using System;
using System.Collections.Generic;
using System.IO;

namespace Barbearia;
public class Menu
    {
        public int MostrarMenu()
        {
            Console.WriteLine("Menu da Barbearia:");
            Console.WriteLine("1 - Adicionar Cliente");
            Console.WriteLine("2 - Adicionar Barbeiro");
            Console.WriteLine("3 - Registrar Corte");
            Console.WriteLine("4 - Relatório de Clientes e Lucro Total");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }