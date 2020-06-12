using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
        
//var name = Console.ReadLine();
var date = DateTime.Now;
var fileName = "/home/john/Music/webprog/work/account.json"; 
var allAccountDetails = File.ReadAllText("/home/john/Music/webprog/work/account.json");
var jsonString = File.ReadAllText(fileName);
var accountTester = ReadAccounts();
//var accountDetails = JsonSerializer.Deserialize<accountStuffs>(jsonString);
   while(true){    
         Console.WriteLine("\n input 1 to search for a account by id number \n input 2 to list all accounts \n input exit to exit ");
var name = Console.ReadLine();
if(name.Equals("1")){
    findAccountByNumber();
}
if(name.Equals("2")){
   foreach(var account in accountTester){
      Console.WriteLine();
                Console.WriteLine("------------------------------------");
                Console.WriteLine("| Number | Balance | Label | Owner |");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("| " + account.Number + " |        " + account.Balance + "| " + account.Label + "|     " + account.Owner + "| ");
                Console.WriteLine("------------------------------------");

}
}
if(name.Equals("exit")){
    Environment.Exit(0);
}
   }
//Console.WriteLine($"\nHello, {name}, on {date:d} at {date:t}!");
//Console.WriteLine($"{allAccountDetails}");
//Console.WriteLine()
//Console.Write("\nPress any key to exit...");
//Console.ReadKey(true);
        }
    
public class accountStuffs{
   public int Number {get; set;}
  public  int Balance {get; set;}
    public string Label {get; set;}

    public int Owner {get; set;} 
   
   
  public override string ToString() {
            return JsonSerializer.Serialize<accountStuffs>(this);
        }

    //    public  string toPrettyString(){
    //         return String.Format("| {0,6} | {1,7} | {2,9} | {3,5} |\n", Number, Balance, Label, Owner);
    //     }
}

public static IEnumerable<accountStuffs> ReadAccounts()
        {
            String file = "../../account.json";

            using (StreamReader reader = new StreamReader(file))
            {
                string data = reader.ReadToEnd();

                var json = JsonSerializer.Deserialize<accountStuffs[]>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );

                return json;
            }
        }

    public static void findAccountByNumber(){
        Console.WriteLine("Please enter the account number you wish to find: "); 
        String accountToFind = Console.ReadLine(); 
        var accounts = ReadAccounts();
            foreach(var account in accounts){
                //Console.WriteLine(account.Number);
            if(accountToFind.Equals(account.Number.ToString())){
                Console.WriteLine();
                Console.WriteLine("------------------------------------");
                Console.WriteLine("| Number | Balance | Label | Owner |");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("| " + account.Number + " |        " + account.Balance + "| " + account.Label + "|     " + account.Owner + "| ");
                Console.WriteLine("------------------------------------");


            }

            }
    
    }
    }
}
