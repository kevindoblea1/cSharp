// See https://aka.ms/new-console-template for more information
Console.WriteLine("Bienvenido, Calculemos circulos");
//the area of circle is pi * radius * radius
Console.WriteLine("Por favor ingresa el valor del radio");
double radius = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("El resultado del area del circulo es: " +  radius * radius * Math.PI);
