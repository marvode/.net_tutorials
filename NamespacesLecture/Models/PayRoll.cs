namespace NamespacesLecture.Models;

public class PayRoll
{
    public int WorkHours { get; set; }
    public int Rate { get; set; }
    public double MedicareDeduction { get; set; }
    public double GrossPay { get; set; }
    public double NetPay { get; set; }

    public PayRoll(int workHours, int rate, double medicareDeduction)
    {
        WorkHours = workHours;
        Rate = rate;
        MedicareDeduction = medicareDeduction;
        GrossPay = CalculateGrossPay();
        NetPay = CalculateNetPay();
    }
    
    public int CalculateGrossPay()
    {
        return WorkHours * Rate;
    }

    public double CalculateNetPay()
    {
        var grossPay = WorkHours * Rate;
        return grossPay - (grossPay * MedicareDeduction);
    }
}