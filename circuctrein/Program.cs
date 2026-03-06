class Dier
{
    public string Naam;
    public Dieet Dieet;
    public Grootte Grootte;
}

enum Dieet
{
    Carnivoor,
    Herbivoor
}

enum Grootte
{ 
    Klein = 1,
    Middel = 3,
    Groot = 5
}

/*class Program
{
    static void Main()
    {
        Dier leeuw = new Dier();
        leeuw.Naam = "Leeuw";
        leeuw.Dieet = Dieet.Carnivoor;
        leeuw.Grootte = Grootte.Groot;
        Dier olifant = new Dier();
        olifant.Naam = "Olifant";
        olifant.Dieet = Dieet.Herbivoor;
        olifant.Grootte = Grootte.Groot;
        Dier zebra = new Dier();
        zebra.Naam = "Zebra";
        zebra.Dieet = Dieet.Herbivoor;
        zebra.Grootte = Grootte.Klein;
        Console.WriteLine($"Dier: {leeuw.Naam}, Dieet: {leeuw.Dieet}, Grootte: {leeuw.Grootte}");
        Console.WriteLine($"Dier: {olifant.Naam}, Dieet: {olifant.Dieet}, Grootte: {olifant.Grootte}");
        Console.WriteLine($"Dier: {zebra.Naam}, Dieet: {zebra.Dieet}, Grootte: {zebra.Grootte}");
    }
} */
// dieren met zelfgemaakte eigenschappen, zoals naam, dieet en grootte. 

class Program
{
    static void Main()
    {
        Random random = new Random();
        Grootte[] groottes = (Grootte[])Enum.GetValues(typeof(Grootte));
        Dieet[] diëten = (Dieet[])Enum.GetValues(typeof(Dieet));

        List<Dier> dieren = new List<Dier>();
        Dier dier = new Dier();
        Dier Naam = new Dier();
        dier.Dieet = diëten[random.Next(diëten.Length)];
        dier.Grootte = groottes[random.Next(groottes.Length)];
        dieren.Add(dier);

        for (int i = 0; i < 10; i++)
        {
            Dier nieuwDier = new Dier();
            nieuwDier.Dieet = diëten[random.Next(diëten.Length)];
            nieuwDier.Grootte = groottes[random.Next(groottes.Length)];
            dieren.Add(nieuwDier);
        }
    }
}
//dieren die automatisch worden gegenereerd met willekeurige eigenschappen, zoals dieet en grootte.
class Wagon
{
    public int Capaciteit = 10;
    public List<Dier> Dieren = new List<Dier>();

}