using System;
using System.Collections.Generic;

public class Animal
{
    public Diet Diet { get; private set; }
    public AnimalSize Size { get; private set; }
    public string Name { get; private set; }

    public Animal(string name, AnimalSize size, Diet diet)
    {
        Name = name;
        Size = size;
        Diet = diet;
    }
}

public enum Diet
{
    Carnivore,
    Herbivore
}

public enum AnimalSize
{
    Small = 1,
    Medium = 3,
    Large = 5
}

public class Wagon
{
    public List<Animal> Animals = new List<Animal>();
    public int Capacity = 10;

    public bool CanAddAnimal(Animal newAnimal)
    {
        if (CurrentCapacity() + (int)newAnimal.Size > Capacity)
        {
            return false;
        }

        foreach (Animal existingAnimal in Animals)
        {
            if (newAnimal.Diet == Diet.Carnivore &&
                newAnimal.Size >= existingAnimal.Size)
            {
                return false;
            }

            if (existingAnimal.Diet == Diet.Carnivore &&
                existingAnimal.Size >= newAnimal.Size)
            {
                return false;
            }
        }

        return true;
    }

    public int CurrentCapacity()
    {
        int total = 0;

        foreach (Animal animal in Animals)
        {
            total += (int)animal.Size;
        }

        return total;
    }
}

public class Program
{
    static Random random = new Random();

    static void Main()
    {
        List<Animal> animals = CreateAnimals();

        ShuffleAnimals(animals);

        List<Wagon> wagons = new List<Wagon>();

        foreach (Animal animal in animals)
        {
            bool placed = false;

            ShuffleWagons(wagons);

            foreach (Wagon wagon in wagons)
            {
                if (wagon.CanAddAnimal(animal))
                {
                    wagon.Animals.Add(animal);
                    placed = true;
                    break;
                }
            }

            if (!placed)
            {
                Wagon newWagon = new Wagon();
                newWagon.Animals.Add(animal);
                wagons.Add(newWagon);
            }
        }

        PrintTrain(wagons);
    }

    static List<Animal> CreateAnimals()
    {
        return new List<Animal>
        {
            new Animal("Lion", AnimalSize.Large, Diet.Carnivore),
            new Animal("Elephant", AnimalSize.Large, Diet.Herbivore),
            new Animal("Rabbit", AnimalSize.Small, Diet.Herbivore),
            new Animal("Monkey", AnimalSize.Medium, Diet.Carnivore),
            new Animal("Tiger", AnimalSize.Large, Diet.Carnivore),
            new Animal("Giraffe", AnimalSize.Large, Diet.Herbivore),
            new Animal("Calf", AnimalSize.Small, Diet.Herbivore),
            new Animal("Zebra", AnimalSize.Medium, Diet.Herbivore),
            new Animal("Goat", AnimalSize.Small, Diet.Herbivore)
        };
    }

    static void ShuffleAnimals(List<Animal> animals)
    {
        for (int i = animals.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);

            Animal temp = animals[i];
            animals[i] = animals[j];
            animals[j] = temp;
        }
    }

    static void ShuffleWagons(List<Wagon> wagons)
    {
        for (int i = wagons.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);

            Wagon temp = wagons[i];
            wagons[i] = wagons[j];
            wagons[j] = temp;
        }
    }

    static void PrintTrain(List<Wagon> wagons)
    {
        int wagonNumber = 1;

        foreach (Wagon wagon in wagons)
        {
            int currentCapacity = wagon.CurrentCapacity();

            Console.Write($"Wagon {wagonNumber}: ");
            PrintBar(currentCapacity, wagon.Capacity);
            Console.WriteLine($" {currentCapacity}/{wagon.Capacity}");

            foreach (Animal animal in wagon.Animals)
            {
                Console.WriteLine($"- {animal.Name} ({animal.Diet}, {animal.Size})");
            }

            Console.WriteLine();
            wagonNumber++;
        }
    }

    static void PrintBar(int current, int max)
    {
        int filled = current;
        int empty = max - current;

        if (current <= 5)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else if (current <= 7)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        Console.Write("[");
        Console.Write(new string('█', filled));

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(new string('░', empty));

        Console.ResetColor();
        Console.Write("]");
    }
}