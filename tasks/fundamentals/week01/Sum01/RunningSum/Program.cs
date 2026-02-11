int total = 0;
string current = "0";
Console.Write("Enter a number: ");
while(!string.IsNullOrEmpty(current = Console.ReadLine()))
{
    _ = int.TryParse(current, out int value);
    total += value;
    Console.Write("Enter a number: ");
}
Console.WriteLine("The total is: " + total);
