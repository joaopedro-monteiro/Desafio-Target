using Desafio_Target.Desafio1;
using Desafio_Target.Desafio1.Model;
using Desafio_Target.Desafio2;
using Desafio_Target.Desafio3;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

Console.WriteLine("QUAL DESAFIO DESEJA VER?");
Console.WriteLine("1 - DESAFIO 1");
Console.WriteLine("2 - DESAFIO 2");
Console.WriteLine("3 - DESAFIO 3");

var desafio = Console.ReadLine();

while (desafio != "1" && desafio != "2" && desafio != "3")
{
    Console.WriteLine("OPÇÃO INVÁLIDA! DIGITE 1, 2 OU 3:");
    desafio = Console.ReadLine();
}

if (desafio == "1")
    Desafio1.Desafio();

if(desafio == "2")
    Desafio2.Desafio();

if (desafio == "3")
    Desafio3.Desafio();

Console.ReadLine();