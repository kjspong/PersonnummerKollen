namespace PersonnummerKollen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Välkommen till PersonnummerKollen!\n\nKnappa in någons födelsedag (ÅÅMMDD): ");
            string fodelseDag = (Console.ReadLine());

            Console.Write("Ange de tre första av de fyra sista: ");
            string treAvFyra = (Console.ReadLine());

            Console.WriteLine();
            Console.Write($"Du har angivit följande information: {fodelseDag}-{treAvFyra}");
            Console.WriteLine();

            // Slå samman födelsedag och de tre första av de fyra sista
            string fodelseDagOchTreAvFyra = Toolbox.Concat(fodelseDag, treAvFyra);

            // Splitta det sammanslagna numret till en array
            var personNummer = fodelseDagOchTreAvFyra.Select(x => (int)char.GetNumericValue(x)).ToArray();

            // Värden från Luhnalgoritmen
            int[] luhn = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };

            // Produkten av luhn * personNummer
            int[] product = new int[9];

            // Beräkna luhn * personNummer och lägg produkten i lista
            List<int> productList = new();

            for (int i = 0; i < luhn.Length; i++)
            {
                product[i] = luhn[i] * personNummer[i];
                productList.Add(product[i]);
            }

            // Addera talen om tvåsiffrig produkt och lägg summan i lista
            List<int> productSumList = new();
            int productSum = 0;

            for (int i = 0; i < productList.Count; i++)
            {
                // === Knyckt från stackoverflow ====
                while (productList[i] != 0)                     // Kör så länge något värde i listan inte är 0
                {
                    productSum += productList[i] % 10;          // Beräkna [i] mod 10 (spara "decimalen")
                    productList[i] /= 10;                       // Beräkna [i] / 10 (spara heltalet)
                }                                               // Kvar blir 0

                productSumList.Add(productSum);
                productSum = 0;
            }

            // Summera talen
            int horizSum = 0;

            foreach (int i in productSumList)
            {
                horizSum += i;
            }

            // Beräkna kontrollsiffran och skriv ut
            int kontrollSiffra = 0;
            kontrollSiffra = Toolbox.RoundUp(horizSum) - horizSum;

            Console.WriteLine();
            Console.Write($"Kontrollsiffran är: {kontrollSiffra}");
            Console.WriteLine();
            Console.WriteLine($"Det fullständiga personnumret är: {fodelseDag}-{treAvFyra}{kontrollSiffra}");
        }
    }
}