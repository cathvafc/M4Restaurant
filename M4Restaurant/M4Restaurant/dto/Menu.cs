using System;
using System.Collections.Generic;
using System.Text;

namespace M4Restaurant
{
  
    class Menu
    {
        int unEuro = 0;
        int dosEuros = 0;
        int cincoEuros = 0;
        int diezEuros = 0;
        int veinteEuros = 0;
        int cincuentaEuros = 0;
        int cienEuros = 0;
        int dosCientosEuros = 0;
        int quinientosEuros = 0;
        int totalPedido = 0;
       
        string[] platos;
        int[] precioPlatos;

        Dictionary<string, int> MenuFull = new Dictionary<string, int>();
        List<string> Pedido = new List<string>();

        public Menu()
        {
            platos = new string[10]{
                "Tortilla",
                "Tomate",
                "Pan",
                "Ternera",
                "Pescado",
                "Ensalada",
                "Espaguetis",
                "Agua",
                "Vino",
                "Refresco"};

             precioPlatos = new int[10]{
                10,
                15,
                20,
                34,
                42,
                51,
                64,
                73,
                82,
                999 // Por el impuesto del azucar... :) 
                 };

            FillMenu();
        }

        private void FillMenu()
        {
            for (int i = 0; i < platos.Length; i++) // COn este bucle rellenamos los dos Arrays de los requerimientos. 
            {
                MenuFull.Add(platos[i],precioPlatos[i]);
            }

        }

        public void ShowMenu()
        {
            Console.WriteLine("El menú es el siguiente: ");

            foreach (KeyValuePair<string, int> platos in MenuFull)
            {
                Console.WriteLine("El plato {0} tiene un precio de {1} ", platos.Key, platos.Value);
            }

        }

        public void AskWhatClientsWant()
        {

            int sigaPidiendo = 1;
            int mostrarMenu = 0;
            string platoIntroducido = "";

            try
            {
                while (sigaPidiendo == 1)
                {
                    Console.WriteLine("Qué plato desea?");

                    platoIntroducido = Console.ReadLine();                

                    if (platos.Equals(platoIntroducido))
                    {
                        Pedido.Add(platoIntroducido); // Sumamos el precio del plato al total de la cuenta.
                    }
                    else
                    {
                        throw new ArgumentException("El Plato {0} no existe en el menu.", platoIntroducido);
                    }


                    

                    Console.WriteLine("Quiere seguir pidiendo? 1:Si / 0:No");
                    sigaPidiendo = Convert.ToInt32(Console.ReadLine());

                    if (sigaPidiendo != 1 && sigaPidiendo != 0)
                    {
                        throw new OptionInsertedIncorrect("The option is incorrect");
                    }

                    if (sigaPidiendo == 1)
                    {
                        Console.WriteLine("Quiere ver el menu otra vez? 1:Si / 0:No");
                        mostrarMenu = Convert.ToInt32(Console.ReadLine());

                        if (mostrarMenu == 1)
                        {
                            ShowMenu();
                        }
                    }
                 
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine("The exception {0} has been throwed.", e.Message);
            }        
        }

        //Función que calcula la cuenta
        public void CalcularLaDolorosa()
        {
            int tmpResult = 0;

            foreach(string values in Pedido)
            {
               if (MenuFull.TryGetValue(values, out tmpResult))
                {
                    totalPedido += tmpResult; // Sumamos el precio del plato al total de la cuenta.
                }
               else
                {
                    Console.WriteLine("El Plato {0} no existe en el menu.", values);
                }
            
            }

            MostrarComoTieneQuePagar();
        }

        private void MostrarComoTieneQuePagar()
        {

            int tmpTotal = totalPedido;

            quinientosEuros = tmpTotal / 500;
            tmpTotal %= 500;
            dosCientosEuros = tmpTotal / 200;
            tmpTotal %= 200;
            cienEuros = tmpTotal / 100;
            tmpTotal %= 100;
            cincuentaEuros = tmpTotal / 50;
            tmpTotal %= 50;
            veinteEuros = tmpTotal / 20;
            tmpTotal %= 20;
            diezEuros = tmpTotal / 10;
            tmpTotal %= 10;
            cincoEuros = tmpTotal / 5;
            tmpTotal %= 5;
            dosEuros = tmpTotal / 2;
            tmpTotal %= 2;
            unEuro = tmpTotal;

            Console.WriteLine("La cuenta de {0} euros la tiene que pagar en la siguiente combinación de billetes: ", totalPedido);


            if (quinientosEuros != 0)
            {
                Console.WriteLine("{0} billetes de quinientos euros", quinientosEuros);
            }
            if (dosCientosEuros != 0)
            {
                Console.WriteLine("{0} billetes de doscientos euros", dosCientosEuros);
            }
            if (cienEuros != 0)
            {
                Console.WriteLine("{0} billetes de cien euros", cienEuros);
            }
            if (cincuentaEuros != 0)
            {
                Console.WriteLine("{0} billetes de cincuenta euros", cincuentaEuros);
            }
            if (veinteEuros != 0)
            {
                Console.WriteLine("{0} billetes de veinte euros", veinteEuros);
            }
            if (diezEuros != 0)
            {
                Console.WriteLine("{0} billetes de diez euros", diezEuros);
            }
            if (cincoEuros != 0)
            {
                Console.WriteLine("{0} billetes de cinco euros", cincoEuros);
            }
            if (dosEuros != 0)
            {
                Console.WriteLine("{0} monedas de 2 euros", dosEuros);
            }
            if (unEuro != 0)
            {
                Console.WriteLine("{0} moendas de 1 euro", unEuro);
            }

            Console.WriteLine("Muchas gracias por venir.");
        }
    }
}
