using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class WagonTests
{
    [TestMethod]
    public void CurrentCapacity_ReturnsCorrectValue()
    {
        // Arrange
        Wagon wagon = new Wagon();
        wagon.Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore)); // 1
        wagon.Animals.Add(new Animal(AnimalSize.Medium, Diet.Herbivore)); // 3

        // Act
        int result = wagon.CurrentCapacity();

        // Assert
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void CanAddAnimal_ReturnsFalse_WhenCapacityExceeded()
    {
        // Arrange
        Wagon wagon = new Wagon();
        wagon.Animals.Add(new Animal(AnimalSize.Large, Diet.Herbivore)); // 5
        wagon.Animals.Add(new Animal(AnimalSize.Large, Diet.Herbivore)); // 5

        Animal rabbit = new Animal(AnimalSize.Small, Diet.Herbivore); // +1 = 11

        // Act
        bool result = wagon.CanAddAnimal(rabbit);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void CanAddAnimal_ReturnsFalse_WhenCarnivoreEatsHerbivore()
    {
        // Arrange
        Wagon wagon = new Wagon();
        wagon.Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));

        Animal carnivore = new Animal(AnimalSize.Small, Diet.Carnivore);

        // Act
        bool result = wagon.CanAddAnimal(carnivore);

        // Assert
        Assert.IsFalse(result);
    }
}