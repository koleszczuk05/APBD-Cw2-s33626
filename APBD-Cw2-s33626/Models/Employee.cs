namespace APBD_Cw2_s33626.Models;

public class Employee(string firstName, string lastName,double salary) : User(firstName, lastName)
{
    public override int MaxItems { get; } = 5;
    public double Salary { get; set; } = salary;
}