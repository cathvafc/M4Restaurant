using System;

namespace M4Restaurant
{
    class M4RestaurantApp
    {
        static void Main(string[] args)
        {
            Menu M4Restaurant = new Menu();

            M4Restaurant.ShowMenu(); // Enseñamos el menú al cliente
            M4Restaurant.AskWhatClientsWant(); // Le pedimos que elija los platos
            M4Restaurant.CalcularLaDolorosa(); // Calculamos la cuenta.
        }
    }
}
