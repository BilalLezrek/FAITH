namespace Faith.Shared;

public class Gebruiker
{
    public string? Voornaam { get; set; }
    public string? Achternaam { get; set; }
    public DateTime Geboortedatum { get; set; }
    public Rol Rol { get; set; }
}
