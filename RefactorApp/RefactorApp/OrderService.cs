using System;

namespace RefactorApp
{
    public class OrderService
    {
        private const decimal FreeDeliveryThreshold = 5000m;
        private const int MaxDiscountPercent = 100;

        public decimal CalculateTotal(decimal productPrice, int quantity, int discountPercent, decimal deliveryPrice)
        {
            // Валидация
            if (productPrice < 0)
                throw new ArgumentException("Цена товара не может быть отрицательной", nameof(productPrice));

            if (quantity < 0)
                throw new ArgumentException("Количество товара не может быть отрицательным", nameof(quantity));

            if (discountPercent < 0 || discountPercent > MaxDiscountPercent)
                throw new ArgumentException($"Скидка должна быть в диапазоне от 0 до {MaxDiscountPercent}%", nameof(discountPercent));

            if (deliveryPrice < 0)
                throw new ArgumentException("Стоимость доставки не может быть отрицательной", nameof(deliveryPrice));

            // Расчёт
            decimal total = productPrice * quantity;

            if (discountPercent > 0)
            {
                total -= total * discountPercent / 100;
            }

            if (total > FreeDeliveryThreshold)
            {
                deliveryPrice = 0;
            }

            return total + deliveryPrice;
        }
    }
}