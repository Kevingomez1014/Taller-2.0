using System;
using System.Collections.Generic;
using System.Linq;

public interface Batalla {
string Nombre { get; }
string Tipo { get; }
int[] Golpes { get; }
 int Escudo { get; }
 int Golpe();
double Escudos();
}

public abstract class Pokemon:Batalla {
private Random rand;

public Pokemon(string nombre, string tipo, int[] golpe, int escudo)  {
 Nombre= nombre;
 Tipo= tipo;
 Golpes= golpe;
 Escudo= escudo;
 rand =new Random();
 }

 public string Nombre { get; }
public string Tipo { get; }
public int[] Golpes { get; }
 public int Escudo { get; }

    // aca defino lo pedido en el punto del ataque de 0 a 1 
 public int Golpe()  {
 int golpeSl= Golpes[rand.Next(Golpes.Length)];
 int multi =rand.Next(2); 
     return golpeSl *multi;
}

    // aca defino lo de 0.5 y 0.5
public double Escudos() {
return Escudo* (rand.NextDouble() * 0.5 + 0.5); 
}
}

public class Squirtle:Pokemon {
    public Squirtle():base("Squirtle", "Agua", new int[] { 20,30,40 }, 25){
 }
}

public class Growlithe:Pokemon {
    public Growlithe():base("Growlithe", "Fuego", new int[] { 15,25,35 }, 20)  {
 }
}

class Combate
{
    static void Main(string[] args) {
        Pokemon pokemon_1 = new Squirtle();
        Pokemon pokemon_2 = new Growlithe();

        Console.WriteLine($"Se enfrentan {pokemon_1.Nombre} {pokemon_1.Tipo} y {pokemon_2.Nombre} {pokemon_2.Tipo} ");

for (int i = 1; i <= 3; i++) {
     int golpe_1=pokemon_1.Golpe();
     double escudo_2=pokemon_2.Escudos();

     int golpe_2=pokemon_2.Golpe();
     double escudo_1=pokemon_1.Escudos();

     int daño_1=(int)Math.Max(golpe_2 - escudo_1, 0);
     int daño_2=(int)Math.Max(golpe_1 - escudo_2, 0);

     Console.WriteLine($"Turno {i}");
     Console.WriteLine($"{pokemon_1.Nombre} ataca a {pokemon_2.Nombre} y causa {daño_1} de daño");
     Console.WriteLine($"{pokemon_2.Nombre} ataca a {pokemon_1.Nombre} y causa {daño_2} de daño");
}

 int puntos_1=pokemon_1.Golpe()+pokemon_1.Golpe()+pokemon_1.Golpe();
 int puntos_2=pokemon_2.Golpe()+pokemon_2.Golpe()+pokemon_2.Golpe();

 Console.WriteLine("\nResultado");

 if (puntos_1>puntos_2) {
  Console.WriteLine($"{pokemon_1.Nombre} Gana");
  } else if (puntos_2>puntos_1) {
  Console.WriteLine($"{pokemon_2.Nombre} Gana");
 } else {
  Console.WriteLine("empate");
  }
 }
}
