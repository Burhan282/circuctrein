using System;
using System.Collections.Generic;

public class Animal
{
    public Diet Diet { get; private set; }
    public AnimalSize Size { get; private set; }

    public Animal(AnimalSize size, Diet diet)
    {
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

    public int CurrentCapacity()
    {
        int total = 0;

        foreach (Animal animal in Animals)
        {
            total += (int)animal.Size;
        }

        return total;
    }

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
}

public class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>();

        Animal lion = new Animal(AnimalSize.Large, Diet.Carnivore);
        Animal elephant = new Animal(AnimalSize.Large, Diet.Herbivore);
        Animal rabbit = new Animal(AnimalSize.Small, Diet.Herbivore);
        Animal monkey = new Animal(AnimalSize.Medium, Diet.Carnivore);
        Animal tiger = new Animal(AnimalSize.Large, Diet.Carnivore);
        Animal giraffe = new Animal(AnimalSize.Large, Diet.Herbivore);
        Animal calf = new Animal(AnimalSize.Small, Diet.Herbivore);

        animals.Add(lion);
        animals.Add(elephant);
        animals.Add(rabbit);
        animals.Add(monkey);
        animals.Add(tiger);
        animals.Add(giraffe);
        animals.Add(calf);

        List<Wagon> wagons = new List<Wagon>();

        foreach (Animal animal in animals)
        {
            bool placed = false;

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

        int wagonNumber = 1;

        foreach (Wagon wagon in wagons)
        {
            int currentCapacity = wagon.CurrentCapacity();

            Console.Write($"Wagon {wagonNumber}: ");
            PrintBar(currentCapacity, wagon.Capacity);
            Console.WriteLine($" {currentCapacity}/{wagon.Capacity}");

            foreach (Animal animal in wagon.Animals)
            {
                Console.WriteLine($"- {animal.Diet} {animal.Size}");
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