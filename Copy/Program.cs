namespace Copy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("\nMissing arguments.\n");
            } 
            else if (args.Length == 2 && args[0] == args[1])
            {
                Console.WriteLine("\nTarget file name must be different from source file name.\n");
            }
            else
            {
                if (File.Exists(args[0]))
                {
                    byte[] buffer = File.ReadAllBytes(args[0]);
                    Console.WriteLine($"\n{buffer.Length} bytes read from input file '{args[0]}'.\n");

                    if (File.Exists(args[1])) 
                    {
                        Console.WriteLine($"Target file '{args[1]}' exists. Overwrite? (y/n)");
                        string? response = Console.ReadLine();
                        if (response != null && response.ToLower() == "y")
                        {
                            File.WriteAllBytes(args[1], buffer);
                            Console.WriteLine($"\nFile '{args[1]}' overwritten. {buffer.Length} bytes written to output file '{args[1]}'.\n");
                        }
                        else 
                        {
                            Console.WriteLine("\nCopy aborted.\n");
                        }
                    } else
                    {
                        File.WriteAllBytes(args[1], buffer);
                        Console.WriteLine($"{buffer.Length} bytes written to output file '{args[1]}'.\n");
                    }
                }
                else
                {
                    Console.WriteLine($"File '{args[0]}' doesn't exist.\n ");
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
