using Domain.Entities.Equipments;
using Domain.Exceptions;
using FluentAssertions;

namespace Domain.Tests.Equipments;

public class EquipmentTests
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Ab")]
    [InlineData("Maecenas ipsum velit, consectetuer eu, lobortis ut, dictum at, dui. In rutrum. Sed ac dolor sit ameta")]
    
    public void Create_WithInvalidRfTag_ThrowsException(string? invalidRfTag)
    {
        var action = new Action(() => new Equipment(invalidRfTag, "Equipment"));

        action.Should().Throw<DomainException>();
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Ab")]
    [InlineData("Maecenas ipsum velit, consectetuer eu, lobortis ut, dictum at, dui. In rutrum. Sed ac dolor sit ameta")]
    
    public void Create_WithInvalidDescription_ThrowsException(string? invalidDescription)
    {
        var action = new Action(() => new Equipment("12345", invalidDescription));

        action.Should().Throw<DomainException>();
    }

    [Fact]
    public void Create_WithValidData_NotThrowsException()
    {
        // ARRANGE

        
        // ACT
        var action = new Action(() => new Equipment("123", "description"));

        // ASSERT
        action.Should().NotThrow();
    }
}