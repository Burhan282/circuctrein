using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class WagonTests
{
    [TestMethod]
    public void CurrentCapacity_ReturnsCorrectValue()
    {
        Wagon wagon = new Wagon();
        wagon.Animals.Add(new Animal("Rabbit", AnimalSize.Small, Diet.Herbivore));
        wagon.Animals.Add(new Animal("Zebra", AnimalSize.Medium, Diet.Herbivore));

        int result = wagon.CurrentCapacity();

        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void CanAddAnimal_ReturnsFalse_WhenCapacityExceeded()
    {
        Wagon wagon = new Wagon();
        wagon.Animals.Add(new Animal("Elephant", AnimalSize.Large, Diet.Herbivore));
        wagon.Animals.Add(new Animal("Giraffe", AnimalSize.Large, Diet.Herbivore));

        Animal rabbit = new Animal("Rabbit", AnimalSize.Small, Diet.Herbivore);

        bool result = wagon.CanAddAnimal(rabbit);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void CanAddAnimal_ReturnsFalse_WhenCarnivoreCanEatAnimal()
    {
        Wagon wagon = new Wagon();
        wagon.Animals.Add(new Animal("Rabbit", AnimalSize.Small, Diet.Herbivore));

        Animal fox = new Animal("Fox", AnimalSize.Small, Diet.Carnivore);

        bool result = wagon.CanAddAnimal(fox);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void CanAddAnimal_ReturnsTrue_WhenAnimalsAreSafe()
    {
        Wagon wagon = new Wagon();
        wagon.Animals.Add(new Animal("Elephant", AnimalSize.Large, Diet.Herbivore));

        Animal goat = new Animal("Goat", AnimalSize.Small, Diet.Herbivore);

        bool result = wagon.CanAddAnimal(goat);

        Assert.IsTrue(result);
    }
}