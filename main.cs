using System;

class Program {
  static string alfabeto = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_-+#$%&/()=¿?¡!|,.;:{}[]";
  public static void Main(){
      string msj = IngresarFrase();
      int opcion = 0;
       while(true){
         Console.WriteLine("1. Cifrar");
         Console.WriteLine("2. Descifrar");
         Console.WriteLine("3. Cambiar frase");
         Console.WriteLine("4. Salir");
         Console.WriteLine("Elija una opcion");
         opcion = int.Parse(Console.ReadLine());
         if(opcion == 1){
             string resultado = Cifrar(msj, 7);
             Console.WriteLine("El mensaje cifrado es: " + resultado);
         } 
         else if(opcion == 2){
             string resultado = Descifrar(msj, 7);
             Console.WriteLine("El mensaje descifrado es: " + resultado);
         }
         else if(opcion == 3){ 
             msj = IngresarFrase();
         }
         else if(opcion == 4){
             break;
         }
         else{
             Console.WriteLine("Opcion no valida");
         }
       }
  }

  public static string IngresarFrase(){
    string msj = "";

    bool check = false;
 
     while (!check) { 
        Console.WriteLine("Ingrese la frase, acordate que no podes usar espacios ");
        msj = Console.ReadLine();
        if(string.IsNullOrEmpty(msj)){
            Console.WriteLine("Ingrese un mensaje no vacio ");
        } else if (!ValidarChar(msj)) {
            Console.WriteLine("Ingrese un mensaje valido ");
        } else {
            check = true;    
        }
        
    }
    return msj;
  }

  public static bool ValidarChar(string msj){
    foreach (char c in msj){
        if(!alfabeto.Contains(c)){
            return false;
        } 
    }
    return true;
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