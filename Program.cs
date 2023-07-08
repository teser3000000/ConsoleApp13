float balance = 0, inputUser;
int quantityOfGoods, idOfGoods, lastNumber, maxValue = 12500000;

Product lays = new("Lays", 200, 2);
Product snickers = new("Snickers", 80, 4);
Product cheetos = new("Cheetos", 180, 5);
Product cola = new("Cola", 50, 3);
Product lipton = new("Lipton", 80, 10);
Product pepsi = new("Pepsi", 80, 13);
Product sandwich = new("Sandwich", 45, 6);
Product kirieshki = new("Kirieshki", 30, 5);
Product chupaСhups = new("Chupa chups", 15, 30);
Product kitkat = new("Kitkat", 34, 0);

List<Product> produts = new() { lays, snickers, cheetos, cola, lipton, pepsi, sandwich, kirieshki, chupaСhups, kitkat };


Console.WriteLine("Добро пожаловать!");
Console.Write("\n");
ShowGoods();
Console.Write("\n");
ShowBalance();
TopWallet();
СhoiceGoods();
Continue();

void TopWallet()
{
    Console.WriteLine("Выберите тип пополнения баланса:\n 1. Банковской картой \n 2. Монетами");
    while (!float.TryParse(Console.ReadLine(), out inputUser) || inputUser > 2 || inputUser < 1 )
    {
        Console.Clear();
        ShowGoods();
        Console.Write("\n");
        Error("Выберите тип пополнения кошелька:\n 1. Банковской картой \n 2. Монетами\n");
    }
    Console.Clear();

    switch (inputUser)
    {
        case 1:
            Console.WriteLine("Введите сумму, на которую хотите пополнить баланс:");
            while (!float.TryParse(Console.ReadLine(), out inputUser) || inputUser <= 0)
                Error("Введите сумму, на которую хотите пополнить баланс:");

            AddMoney(inputUser);
            Console.WriteLine($"Ваш баланс: {balance} рублей");
            break;
        case 2:
            ShowBalance();

            Console.Write("Необходимо поочередно ввести монетки номиналом 1, 2, 5, 10\n\nВведите кол-во монет номиналом 1: ");
            while (!float.TryParse(Console.ReadLine(), out inputUser) || inputUser < 0 || inputUser > maxValue)
            {
                Console.Clear();
                Error("Введите кол-во монет номиналом 1: ");
            }
            AddMoney(inputUser);
            maxValue -= Convert.ToInt32(inputUser);
            Console.Clear();

            ShowBalance();
            Console.Write("Необходимо поочередно ввести монетки номиналом 1, 2, 5, 10\n\nВведите кол-во монет номиналом 2: ");
            while (!float.TryParse(Console.ReadLine(), out inputUser) || inputUser < 0 || inputUser > maxValue)
            {
                Console.Clear();
                Error("Введите кол-во монет номиналом 2: ");
            }
            AddMoney(inputUser * 2);
            maxValue -= Convert.ToInt32(inputUser);
            Console.Clear();

            ShowBalance();
            Console.Write("Необходимо поочередно ввести монетки номиналом 1, 2, 5, 10\n\nВведите кол-во монет номиналом 5: ");
            while (!float.TryParse(Console.ReadLine(), out inputUser) || inputUser < 0 || inputUser > maxValue)
            {
                Console.Clear();
                Error("Введите кол-во монет номиналом 5: ");
            }
            AddMoney(inputUser * 5);
            maxValue -= Convert.ToInt32(inputUser);
            Console.Clear();

            ShowBalance();
            Console.Write("Необходимо поочередно ввести монетки номиналом 1, 2, 5, 10\n\nВведите кол-во монет номиналом 10: ");
            while (!float.TryParse(Console.ReadLine(), out inputUser) || inputUser < 0 || inputUser > maxValue)
            {
                Console.Clear();
                Error("Введите кол-во монет номиналом 10: ");
            }
            AddMoney(inputUser * 10);
            maxValue -= Convert.ToInt32(inputUser);
            Console.Clear();
            break;
        default:
            Console.WriteLine("Такого типа не существует");
            break;
    }

}
void СhoiceGoods()
{
    ShowGoods();
    Console.WriteLine("\n");
    ShowBalance();

    Console.WriteLine("Введите номер товара, который хотите взять: ");
    while (!int.TryParse(Console.ReadLine(), out idOfGoods) || idOfGoods <= 0 || idOfGoods > produts.Count)
    {
        Console.Clear();
        ShowGoods();
        Console.Write("\n");
        ShowBalance();
        Error("Введите номер товара, который хотите взять: ");
    }

    Console.WriteLine("Введите кол-во товара, который хотите взять: ");
    while (!int.TryParse(Console.ReadLine(), out quantityOfGoods) || quantityOfGoods < 0 || quantityOfGoods > produts[idOfGoods - 1].Quantity)
    {
        Console.Clear();
        ShowGoods();
        Console.Write("\n");
        ShowBalance();
        Error("Введите кол-во товара, который хотите взять: ");
    }
    BuyGood(idOfGoods - 1, quantityOfGoods);
}
void AddMoney(float value) => balance += value;
void ShowGoods()
{
    for (int i = 0; i < produts.Count; i++)
    {
        Console.WriteLine($"№ {i + 1} {produts[i].Name} -- Кол-во: {produts[i].Quantity} -- Цена: {produts[i].Price}");
    }
}
void BuyGood(int id, int count)
{
    Console.Clear();
    if ((produts[id].Price * count) <= balance)
    {
        balance -= produts[id].Price * count;
        produts[id].Sale(count);
        Console.Clear();
        ShowGoods();
        Console.WriteLine("\n");
        ShowBalance();
        Continue();
    }
    else
    {
        Error("Недостаточно средств");
        Console.WriteLine("\n");
        СhoiceGoods();
    }

}
void ShowBalance()
{
    Console.WriteLine($"Ваш баланс: {balance} рублей");
}
void Continue()
{
    Console.WriteLine("Хотите купить что-то еще?:\n 1. Да \n 2. Нет");
    while (!float.TryParse(Console.ReadLine(), out inputUser) || inputUser > 2 || inputUser < 1)
    {
        Console.Clear();
        ShowGoods();
        Console.Write("\n");
        Error("Хотите купить что-то еще?:\n 1. Да \n 2. Нет\n");
    }
    Console.Clear();
    switch (inputUser)
    {
        case 1:
            СhoiceGoods();
            break;
        case 2:
            GetChance();
            break;
        default:
            Console.WriteLine("Такого типа не существует");
            break;
    }
}
void GetChance()
{
    Console.Clear();
    int one = 0, two = 0, five = 0, ten = 0;
    while (balance > 0)
    {
        lastNumber = Convert.ToInt32(balance % 10);
        if (balance % 10 == 0)
        {
            balance -= 10;
            ten++;
        }
        else if (balance % 5 == 0)
        {
            balance -= 5;
            five++;
        }
        else if (balance % 2 == 0)
        {
            if (lastNumber == 6)
            {
                balance -= 5;
                five++;

                balance -= 1;
                one++;
            }
            else
            {
                balance -= 2;
                two++;
            }

        }
        else
        {
            if (lastNumber == 7)
            {
                balance -= 5;
                five++;

                balance -= 2;
                two++;

            }
            else if (lastNumber == 9)
            {
                balance -= 5;
                five++;

                balance -= 2;
                two++;

                balance -= 2;
                two++;
            }
            else
            {
                balance -= 1;
                one++;
            }
        }
    }
    Console.WriteLine($"Сдача выдана монетами следующего номенала: \n1р - {one}\n2р - {two}\n5р - {five}\n10р - {ten}\n");
    Console.WriteLine("Распечатать чек?:\n 1. Да \n 2. Нет");
    while (!float.TryParse(Console.ReadLine(), out inputUser) || inputUser > 2 || inputUser < 1)
    {
        Console.Clear();
        ShowGoods();
        Console.Write("\n");
        Error("Распечатать чек?:\n 1. Да \n 2. Нет");
    }
    Console.Clear();
    switch (inputUser)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("Добро пожаловать!");
            Console.Write("\n");
            ShowGoods();
            Console.Write("\n");
            ShowBalance();
            TopWallet();
            СhoiceGoods();
            Continue();
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("Добро пожаловать!");
            Console.Write("\n");
            ShowGoods();
            Console.Write("\n");
            ShowBalance();
            TopWallet();
            СhoiceGoods();
            Continue();
            break;
        default:
            Console.WriteLine("Такого типа не существует");
            break;
    }
}
void Error(string message)
{
    //Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("Неправильный ввод!");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write($"\n{message}");
}
