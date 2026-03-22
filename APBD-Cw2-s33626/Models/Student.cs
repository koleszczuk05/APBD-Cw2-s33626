namespace APBD_Cw2_s33626.Models;

public class Student(string firstName, string lastName, string sNumber) : User(firstName, lastName)
{
    public override int MaxItems { get; } = 2;
    public string SNumber { get; set; } = sNumber;
}