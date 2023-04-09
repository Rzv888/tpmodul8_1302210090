using tpmodul8_1302210090;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();

        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}:");
        double suhu = double.Parse(Console.ReadLine());

        if (config.SatuanSuhu == "fahrenheit")
        {
            suhu = (suhu - 32) * 5 / 9;
        }

        if (suhu >= 36.5 && suhu <= 37.5)
        {
            Console.WriteLine($"Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? (max {config.BatasHariDeman} hari)");
            int hari = int.Parse(Console.ReadLine());

            if (hari < config.BatasHariDeman)
            {
                Console.WriteLine(config.PesanDiterima);
            }
            else
            {
                Console.WriteLine(config.PesanDitolak);
            }
        }
        else
        {
            Console.WriteLine(config.PesanDitolak);
        }

        Console.WriteLine("Apakah anda ingin mengubah satuan suhu? (y/n)");
        string jawaban = Console.ReadLine();

        if (jawaban.ToLower() == "y")
        {
            config.UbahSatuan();
        }
    }
}