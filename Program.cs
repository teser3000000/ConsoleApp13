﻿int balance = 0, inputUser, quantityOfGoods, idOfGoods, lastNumber, maxValue = 12500000, paymentMethod = 3, minPrice = int.MaxValue;
string inputUserString;

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
ShowСommands();

//ShowGoods();
Console.Write("\n");
ShowBalance();
TopWallet();
//СhoiceGoods();
//Continue();

void TopWallet()
{
    Console.WriteLine("Выберите тип пополнения баланса:\n 1. Банковской картой \n 2. Монетами");
    while (!int.TryParse(Console.ReadLine(), out paymentMethod) || paymentMethod > 2 || paymentMethod < 1)
    {
        Console.Clear();
        Error("Выберите тип пополнения кошелька:\n 1. Банковской картой \n 2. Монетами\n");
    }
    Console.Clear();

    switch (paymentMethod)
    {
        case 1:
            Console.Clear();

            Console.Write("Введите сумму, на которую хотите пополнить баланс: ");
            while (!int.TryParse(Console.ReadLine(), out inputUser) || inputUser <= 0)
            {
                Console.Clear();
                Error("Введите сумму, на которую хотите пополнить баланс:");
            }
            AddMoney(inputUser);
            Console.Clear();
            Break();

            break;
        case 2:
            ShowBalance();

            Console.Write("Необходимо поочередно ввести монетки номиналом 1, 2, 5, 10\n\nВведите кол-во монет номиналом 1: ");
            while (!int.TryParse(Console.ReadLine(), out inputUser) || inputUser < 0 || inputUser > maxValue)
            {
                Console.Clear();
                Error("Введите кол-во монет номиналом 1: ");
            }
            AddMoney(inputUser);
            Console.Clear();

            ShowBalance();
            Console.Write("Необходимо поочередно ввести монетки номиналом 1, 2, 5, 10\n\nВведите кол-во монет номиналом 2: ");
            while (!int.TryParse(Console.ReadLine(), out inputUser) || inputUser < 0 || inputUser > maxValue)
            {
                Console.Clear();
                Error("Введите кол-во монет номиналом 2: ");
            }
            AddMoney(inputUser * 2);
            Console.Clear();

            ShowBalance();
            Console.Write("Необходимо поочередно ввести монетки номиналом 1, 2, 5, 10\n\nВведите кол-во монет номиналом 5: ");
            while (!int.TryParse(Console.ReadLine(), out inputUser) || inputUser < 0 || inputUser > maxValue)
            {
                Console.Clear();
                Error("Введите кол-во монет номиналом 5: ");
            }
            AddMoney(inputUser * 5);
            Console.Clear();

            ShowBalance();
            Console.Write("Необходимо поочередно ввести монетки номиналом 1, 2, 5, 10\n\nВведите кол-во монет номиналом 10: ");
            while (!int.TryParse(Console.ReadLine(), out inputUser) || inputUser < 0 || inputUser > maxValue)
            {
                Console.Clear();
                Error("Введите кол-во монет номиналом 10: ");
            }
            AddMoney(inputUser * 10);
            Console.Clear();
            Break();
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

    Console.Write("Введите номер товара, который хотите взять: ");
    while (!int.TryParse(Console.ReadLine(), out idOfGoods) || idOfGoods <= 0 || idOfGoods > produts.Count || produts[idOfGoods - 1].Quantity == 0)
    {
        Console.Clear();
        ShowGoods();
        Console.Write("\n");
        ShowBalance();
        Error("Введите номер товара, который хотите взять: ");
    }

    Console.Write("Введите кол-во товара, который хотите взять: ");
    while (!int.TryParse(Console.ReadLine(), out quantityOfGoods) || quantityOfGoods < 0 || quantityOfGoods > produts[idOfGoods - 1].Quantity)
    {
        Console.Clear();
        ShowGoods();
        Console.Write("\n");
        ShowBalance();
        Error("Введите кол-во товара, который хотите взять: ");
    }
    BuyGood(idOfGoods - 1, quantityOfGoods);
    Break();
}
void AddMoney(int value) => balance += value;
void ShowGoods()
{
    for (int i = 0; i < produts.Count; i++)
    {
        Console.WriteLine($"№ {i + 1} {produts[i].Name} -- Кол-во: {produts[i].Quantity} -- Цена: {produts[i].Price}");
    }
}
void ShowСommands()
{
    Console.WriteLine("Введите следующие команды на выбор:\n1. AddMoney -- Пополнить счёт\n2. GetChange -- Получить сдачу\n3. ShowGoods -- Отобразить товары\n4. BuyGoods -- Купить товары");
    inputUserString = Console.ReadLine();
    if (inputUserString.ToLower() == "addmoney")
    {
        Console.Clear();
        TopWallet();
    }
    else if (inputUserString.ToLower() == "getchange")
    {
        if (paymentMethod == 3)
        {
            Console.Clear();
            Console.WriteLine("Вы должны пополнить кошелек");
            ShowСommands();
        }
        else { GetChance(); }
    }
    else if (inputUserString.ToLower() == "showgoods")
    {
        Console.Clear();
        ShowGoods();
        Console.WriteLine("\nНажмите enter, чтобы вернуться назад");
        Console.ReadLine();
        Break();
    }
    else if (inputUserString.ToLower() == "buygoods")
    {
        if (balance <= 0 && balance < minPrice)
        {
            Console.Clear();
            Error("Пополните баланс\n");
            ShowСommands();
        }
        else
        {
            Console.Clear();
            СhoiceGoods();
        }
    }
    else if (inputUserString.ToLower() == "adminpanel")
    {
        Console.Clear();

    }
    else
    {
        Console.Clear();
        Error("Такой команды не существует\n");
        ShowСommands();
    }

}
void Break()
{
    Console.Clear();
    ShowСommands();
}
void BuyGood(int id, int count)
{
    Console.Clear();
    if ((produts[id].Price * count) <= balance)
    {
        balance -= produts[id].Price * count;
        produts[id].Buy(count);
        Console.Clear();
        ShowGoods();
        Console.WriteLine("\n");
        ShowBalance();
        //Continue();
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
    for (int i = 0; i < produts.Count; i++)
    {
        if (minPrice > produts[i].Price)
        {
            minPrice = produts[i].Price;
        }
    }
    if (balance < minPrice)
    {
        GetChance();
    }
    else
    {
        Console.WriteLine("Хотите купить что-то еще?:\n 1. Да \n 2. Нет");
        while (!int.TryParse(Console.ReadLine(), out inputUser) || inputUser > 2 || inputUser < 1)
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
}
void GetChance()
{
    if (paymentMethod == 1)
    {
        Console.WriteLine("Сдача выслана на вашу карту");
        balance = 0;
        Console.WriteLine("Распечатать чек?:\n 1. Да \n 2. Нет");
        Console.ReadLine();
        Break();
        //while (!int.TryParse(Console.ReadLine(), out inputUser) || inputUser > 2 || inputUser < 1)
        //{
        //    Console.Clear();
        //    ShowGoods();
        //    Console.Write("\n");
        //    Error("Распечатать чек?:\n 1. Да \n 2. Нет\n");
        //}
        //Console.Clear();
        //ShowGoods();
        //Console.Write("\n");
        //ShowBalance();
        //TopWallet();
    }
    else
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
        Console.ReadLine();
        Break();
        //while (!int.TryParse(Console.ReadLine(), out inputUser) || inputUser > 2 || inputUser < 1)
        //{
        //    Console.Clear();
        //    ShowGoods();
        //    Console.Write("\n");
        //    Error("Распечатать чек?:\n 1. Да \n 2. Нет\n");
        //}
        //Console.Clear();
        //ShowGoods();
        //Console.Write("\n");
        //ShowBalance();
        //TopWallet();
    }
}
void AdminPanel()
{

}
void Error(string message)
{
    //Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("Неправильный ввод!");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write($"\n{message}");
}
