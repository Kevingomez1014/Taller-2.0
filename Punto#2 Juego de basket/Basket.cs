using System; // esto lo utilizo para importar el espacio de nombre y utulizar el console.writeLine
using System.Collections.Generic; // esto lo utilizo para poder crear la list<>
using System.Linq; // esto lo utilizo para la suma del rendimiento de los jugadores

// aca defino la interfaz que piden en el ejercicio y utilizo el get para dar acceso a las propiedades
public interface Baseball {
    string Nombre { get; }
    string Posicion { get; }
    int Rendimiento { get; }
}
// aca realizo la clase jugador para definirlo
public class Jugador : Baseball {
    private string nombre;
    private string posicion;
    private int rendimiento;
    private Random rand;
// aca utilizo es this para modificar los parametro antes definidos
    public Jugador(string nombre, string posicion, int rendimiento) {
        this.nombre = nombre;
        this.posicion = posicion;
        this.rendimiento = rendimiento;
        this.rand = new Random();
    }
    // aca creo una nuevas clases para usar el get y retornarlos 
    public string Nombre { get { return nombre; } }
    public string Posicion { get { return posicion; } }
    public int Rendimiento { get { return rendimiento; } }

    // esto lo utilizo para mayor facilidad y no tener q ingresar a sus propiedades 
    public override string ToString() {
        return $"{Nombre} Juega en la Posición de {Posicion} Con un Rendimiento: {Rendimiento}";
    }
}

   //Esta es la lista de jugadores
class Basket {
    static void Main(string[] args) {
        List<Baseball> playersR = new List<Baseball> {
            new Jugador("Kevin Gomez", "BASE", 10),
            new Jugador("andres Perez", "ALA_PIVOT", 8),
            new Jugador("Maicon Tabares", "ESCOLTA", 9),
            new Jugador("Carlos Sanchez", "PIVOT", 6),
            new Jugador("Mateo Osorio", "ALERO", 8),
            new Jugador("Jeffrey Gonzalez", "BASE", 7),
            new Jugador("Maria Rodrigues", "BASE", 6),
            new Jugador("Camila Puerta ", "ALA_PIVOT", 10),
            new Jugador("Tatiana Castro", "ESCOLTA", 9),
            new Jugador("Angie Gonzalez", "PIVOT", 5),
            new Jugador("Martina Larzo", "ALERO", 9),
            new Jugador("Karolina Reina", "BASE", 10)
        };

        // esta lista define los equipos
        List<Baseball> Team1 = new List<Baseball>();
        List<Baseball> Team2 = new List<Baseball>();

        Console.WriteLine("Jugadores Para escojer:");

        for (int i = 0; i < 6; i++) {
            int I_PlayerS = new Random().Next(0, playersR.Count);
            Baseball PlayerS = playersR[I_PlayerS];
            playersR.RemoveAt(I_PlayerS);
            if (i % 2 == 0)  {
                Team1.Add(PlayerS);
                Console.WriteLine($"Team 1;  Agregado {PlayerS.Nombre} ({PlayerS.Posicion})");
            } else {
                Team2.Add(PlayerS);
                Console.WriteLine($"Team 2;  Agregado {PlayerS.Nombre} ({PlayerS.Posicion})");
            }
        }

        // Estos son los jugadores que estan jugando el partido, se utiliza foreach para recorrer
        // la lista team1 y mostrar los detalles 
        Console.WriteLine("\nJugadores en Team 1:");
        foreach (var Player in Team1)  {
            Console.WriteLine(Player);
        }

        Console.WriteLine("\nJugadores en Team 2:");
        foreach (var Player in Team2)  {
            Console.WriteLine(Player);
        }

        // aca utilizo el parametro sum para ver el rendimiento del team
        int RendimientoTeam1 = Team1.Sum(players => players.Rendimiento);
        int RendimientoTeam2 = Team2.Sum(players => players.Rendimiento);

        Console.WriteLine($"\nResultado del partido:");
        Console.WriteLine($"Team 1 Puntaje total: {RendimientoTeam1}");
        Console.WriteLine($"Team 2 Puntaje total: {RendimientoTeam2}");

        if (RendimientoTeam1 > RendimientoTeam2)  {
            Console.WriteLine("¡El Team 1 gana el partido!");
        }  else if (RendimientoTeam2 > RendimientoTeam1)  {
            Console.WriteLine("¡El Team 2 gana el partido!");
        } else {
            Console.WriteLine("Empate.");
        }
    }
}
