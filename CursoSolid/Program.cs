using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList{ get; set; }

        static void Main(string[] args)
        {
            TaskList= new List<string>();
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuTaskList();
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string line = Console.ReadLine();
            return Convert.ToInt32(line);
        }

       public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");

                ShowTaskList();

                string line = Console.ReadLine();

                int indexToRemove = Convert.ToInt32(line) - 1;

                if(indexToRemove < 0 || indexToRemove > TaskList.Count){
                    Console.WriteLine("El numero ingresado no es valido.");
                    return;
                }

                string task = TaskList[indexToRemove];
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea {task} eliminada");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: ", ex.Message);
            }
        }
        
        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string taskAdd = Console.ReadLine();
                
                if(string.IsNullOrWhiteSpace(taskAdd))
                {
                    System.Console.WriteLine("No se permiten campos nullos");
                    return;
                }
                else
                {
                    TaskList.Add(taskAdd);
                    Console.WriteLine("Tarea registrada");
                }
            }
            catch (Exception)
            {
                System.Console.WriteLine("Ha surgido un erro al ingresar la tarea");
            }
        }
        
        public static void ShowMenuTaskList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                 ShowTaskList();
            }
        } 
        
        public enum Menu 
        {
            Add = 1,
            Remove= 2,
            List = 3,
            Exit = 4
        }
        
        public static void ShowTaskList()
        {
        
            var indexTask = 1;
            TaskList.ForEach(task => Console.WriteLine($"{indexTask++} . {task}"));
            Console.WriteLine("----------------------------------------");
        }
        
    }
}