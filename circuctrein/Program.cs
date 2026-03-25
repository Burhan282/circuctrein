class Dier
{
    public string Naam { get; private set; }
    public Dieet Dieet { get; private set; }
    public Grootte Grootte { get;private set; }

    public Dier(string naam, Grootte grootte, Dieet dieet)
    {
        Naam = naam;
        Grootte = grootte;
        Dieet = dieet;
    }
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

class Program
{
    static void Main()
    {
      List<Dier> dieren = new List<Dier>();
        Dier leeuw = new Dier("Leeuw", Grootte.Groot, Dieet.Carnivoor);
        Dier olifant = new Dier("Olifant", Grootte.Groot, Dieet.Herbivoor);
        Dier konijn = new Dier("Konijn", Grootte.Klein, Dieet.Herbivoor);
        Dier Aap = new Dier("Aap", Grootte.Middel, Dieet.Carnivoor);
        Dier Tijger = new Dier("Tijger", Grootte.Groot, Dieet.Carnivoor);
        Dier Giraf = new Dier("Giraf", Grootte.Groot, Dieet.Herbivoor);
        Dier kalfje = new Dier("Kalfje", Grootte.Klein, Dieet.Herbivoor);
        
        dieren.Add(leeuw);
        dieren.Add(olifant);
        dieren.Add(konijn);
        dieren.Add(Aap);
        dieren.Add(Tijger);
        dieren.Add(Giraf);
        dieren.Add(kalfje);

    }
}
// dieren met zelfgemaakte eigenschappen, zoals naam, dieet en grootte. 

/*class Program
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
}*/
//dieren die automatisch worden gegenereerd met willekeurige eigenschappen, zoals dieet en grootte.

class Wagon
{
    public List<Dier> Dieren = new List<Dier>();
    public int Capaciteit = 10;
    public int HuidigeCapaciteit()
    {
        int huidigeCapaciteit = 0;

        foreach (Dier dier in Dieren)
        {
            huidigeCapaciteit += (int)dier.Grootte;
        }

        return huidigeCapaciteit;
    }
}



