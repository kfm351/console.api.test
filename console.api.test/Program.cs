List<BankAccount> bankAccounts = new List<BankAccount>()
{
    new BankAccount("Ivanov", 10010, new DateTime(2001,12,12), false),
    new BankAccount("Petrov", 15066, new DateTime(1997,06,11), false),
    new BankAccount("Sidorov", 51000, new DateTime(1999,12,04), true),
    new BankAccount("Ivanova", 11012, new DateTime(2000,06,02), false),
    new BankAccount("Garkun", 21005, new DateTime(2003,02,03), false),
    new BankAccount("Yarullin", 10, new DateTime(2003,03,03), true),
    new BankAccount("Yapparov", 31001, new DateTime(2000,05,10), false)
};

// example
//var temp = bankAccounts.Where(x => x.IsBan == true).ToList();
//foreach(var t in temp)
//    Console.WriteLine($"{t.Name} is ban:{t.IsBan}");

// linq
// T1: Записать в отдельный список все аккаунты с балансом больше чем 11к

foreach(var a in bankAccounts.Where(x => x.Balance > 11000))
{
    Console.WriteLine($"{a.Name} {a.Balance} {a.Birthday} {a.IsBan}");
}

// T2: Отсортировать аккаунты по алфавиту, по балансу от больше к меньшему и наоборот
foreach (var a in bankAccounts.OrderBy(s => s.Name))
{
    Console.WriteLine($"{a.Name} {a.Balance} {a.Birthday} {a.IsBan}");
}
foreach (var a in bankAccounts.OrderBy(s => s.Balance))
{
    Console.WriteLine($"{a.Name} {a.Balance} {a.Birthday} {a.IsBan}");
}
foreach (var a in bankAccounts.OrderBy(s => s.Balance).Reverse())
{
    Console.WriteLine($"{a.Name} {a.Balance} {a.Birthday} {a.IsBan}");
}

// T3: Вывести все забаненные аккаунты с балансом меньше 10к
foreach (var a in bankAccounts.Where(x => x.IsBan && x.Balance < 10000))
{
    Console.WriteLine($"{a.Name} {a.Balance} {a.Birthday} {a.IsBan}");
}
// T4: Вывести все аккаунты пользователи которых родились до 2000 года
foreach (var a in bankAccounts.Where(x => x.Birthday.Year < 2000))
{
    Console.WriteLine($"{a.Name} {a.Balance} {a.Birthday} {a.IsBan}");
}
// T5: Сделать метод  ToCommunism() - который распределит все балансы пользователей поровну между всеми

var avg = bankAccounts.Sum(x => x.Balance) / bankAccounts.Count;
foreach(var b in bankAccounts)
{
    b.Balance = avg;
    Console.WriteLine($"{b.Name} {b.Balance} {b.Birthday} {b.IsBan}");
}

class BankAccount
{
    public BankAccount(string name, decimal balance, DateTime birthday, bool isBan)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Balance = balance;
        Birthday = birthday;
        IsBan = isBan;
    }

    public string Id { get; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public DateTime Birthday { get; set; }
    public bool IsBan { get; set; }
}