namespace APBD_Cw2_s33626.Models;

public abstract class User(string firstName, string lastName)
{
    private static int _idUser = 1;
    public int Id { get; } =  _idUser++;
    public string Name { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public abstract int MaxItems { get; }
}