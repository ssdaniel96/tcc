using Domain.Exceptions;

namespace Domain.Entities.Locations;

public sealed class Address : Entity
{
    public string ZipCode { get; private set; }
    public string Number { get; private set; }
    public string? Complement { get; private set; }
    public string? Observation { get; private set; }

#pragma warning disable CS8618
    private Address()
#pragma warning restore CS8618
    {

    }

    public Address(string zipCode, string number, string? complement = null, string? observation = null)
    {
        ValidateZipCode(ZipCode);
        ValidateNumber(number);
        ValidateComplement(complement);
        ValidateObservation(observation);
        
        ZipCode = zipCode;
        Number = number;
        Complement = complement;
        Observation = observation;
    }

    private static void ValidateZipCode(string? zipCode)
    {
        if (string.IsNullOrEmpty(zipCode))
        {
            throw new DomainException("O código Zip não pode ser nulo!");
        }

        if (zipCode.Length != 8)
        {
            throw new DomainException($"O código Zip precisa ter 8 caracteres! Tamanho atual: {zipCode.Length}");
        }
    }
    
    private static void ValidateNumber(string? number)
    {
        if (string.IsNullOrEmpty(number))
        {
            throw new DomainException("O número não pode ser nulo!");
        }

        if (number.Length > 10)
        {
            throw new DomainException(
                $"O comprimento máximo permitido do número é 10 caracteres! Tamanho atual: {number.Length}");
        }
    }
    
    private static void ValidateComplement(string? complement)
    {
        if (complement == null)
            return;

        if (complement.Length > 100)
        {
            throw new DomainException(
                $"O comprimento máximo permitido do complemento é 100 caracteres! Tamanho atual: {complement.Length}");
        }

    }
    
    private static void ValidateObservation(string? observation)
    {
        if (observation == null)
            return;

        if (observation.Length > 100)
        {
            throw new DomainException(
                $"O comprimento máximo permitido da observação é 100 caracteres! Tamanho atual: {observation.Length}");
        }
    }
}