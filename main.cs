using System;

class Program {
  static string alfabeto = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_-+#$%&/()=¿?¡!|,.;:{}[]";
  public static void Main(){
      Console.WriteLine("Ingrese la frase a cifrar");

      string msj = Console.ReadLine();
      while (string.IsNullOrEmpty(msj))
      {
          Console.WriteLine("Ingrese un mensaje no vacio");
          msj = Console.ReadLine();
      }
      Program program = new Program();
      string resultado = Program.Cifrar(msj, 7);
      Console.WriteLine(resultado);
      string otroResultado = Program.Descifrar(resultado, 7);
      Console.WriteLine(otroResultado);
  }

  public static string Cifrar(string msj, int clave) {
      string msjCifrado = "";

      foreach (char c in msj) {
          int indice = alfabeto.IndexOf(c);
          if (indice != -1) {
              int nuevoIndice = (indice + clave) % alfabeto.Length;
              msjCifrado += alfabeto[nuevoIndice];
          } else {
              Console.WriteLine("sonso");
              return "-1"; 
          }
      }

      return msjCifrado;
  }

  public static string Descifrar(string msj, int clave) {
      string msjDescifrado = "";

      foreach (char c in msj) {
          int indice = alfabeto.IndexOf(c);
          if (indice != -1) { 
            if(indice <= clave) {
              int nuevoIndice = (indice + (alfabeto.Length - clave)) % alfabeto.Length;
              msjDescifrado += alfabeto[nuevoIndice];
            } 
            else {
              int nuevoIndice = (indice - clave) % alfabeto.Length;
              msjDescifrado += alfabeto[nuevoIndice];
              }
          } 
          else {
              Console.WriteLine("sonso");
              return "-1"; 
          }
      }

      return msjDescifrado;
  }
}