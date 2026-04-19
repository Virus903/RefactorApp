using RefactorApp;

Console.WriteLine("=".PadRight(60, '='));
Console.WriteLine("    Модуль расчёта итоговой стоимости заказа");
Console.WriteLine("=".PadRight(60, '='));
Console.WriteLine();

var orderService = new OrderService();

// Пример 1: Обычный заказ
Console.WriteLine("Пример 1: Обычный заказ (100 руб x 2 шт, скидка 0%, доставка 200 руб)");
try
{
    decimal result = orderService.CalculateTotal(100, 2, 0, 200);
    Console.WriteLine($"Результат: {result} руб.\n");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}\n");
}

// Пример 2: Заказ со скидкой
Console.WriteLine("Пример 2: Заказ со скидкой (1000 руб x 2 шт, скидка 10%, доставка 300 руб)");
try
{
    decimal result = orderService.CalculateTotal(1000, 2, 10, 300);
    Console.WriteLine($"Результат: {result} руб.\n");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}\n");
}

// Пример 3: Бесплатная доставка (сумма > 5000)
Console.WriteLine("Пример 3: Бесплатная доставка (3000 руб x 2 шт = 6000 руб, доставка 500 руб)");
try
{
    decimal result = orderService.CalculateTotal(3000, 2, 0, 500);
    Console.WriteLine($"Результат: {result} руб. (доставка бесплатно)\n");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}\n");
}

// Пример 4: Ошибка - отрицательная цена
Console.WriteLine("Пример 4: Ошибка (отрицательная цена товара)");
try
{
    decimal result = orderService.CalculateTotal(-100, 2, 0, 200);
    Console.WriteLine($"Результат: {result} руб.\n");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}\n");
}

Console.WriteLine("=".PadRight(60, '='));
Console.WriteLine("Нажмите любую клавишу для выхода...");
Console.ReadKey();