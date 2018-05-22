using System.Collections.Generic;
using System.Linq;
using DAL_ZVV.Entities;

namespace ZVV_Web_Lab_1.Models
{
    public class CartItem
    {
        public LabGlassware Glassware { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        private Dictionary<int, CartItem> cartItems;

        public Cart()
        {
            cartItems = new Dictionary<int, CartItem>();
        }

        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="lgw">объект для добавления в корзину</param>
        public void AddItem(LabGlassware lgw)
        {
            if (cartItems.ContainsKey(lgw.GW_ID))
                cartItems[lgw.GW_ID].Quantity += 1;
            else cartItems.Add(lgw.GW_ID,
                new CartItem { Glassware = lgw, Quantity = 1 });
        }

        /// <summary>
        /// Удаление из корзины
        /// </summary>
        /// <param name="lgw">объект для удаления из корзины</param>
        /// <returns>Возвращает число оставшихся объектов в корзине или -1, 
        /// если такого объект нет в корзине</returns>
        public int DeleteItem(LabGlassware lgw)
        {
            if (!cartItems.ContainsKey(lgw.GW_ID)) return -1;
            else
            {
                if (cartItems[lgw.GW_ID].Quantity == 1)
                {
                    cartItems.Remove(lgw.GW_ID);
                    return 0;
                }
                else return cartItems[lgw.GW_ID].Quantity -= 1;
            }
        }

        /// <summary>
        /// Очистка корзины
        /// </summary>
        public void Clear()
        {
            cartItems.Clear();
        }

        /// <summary>
        /// Получение суммы всех содержащихся товаров в корзине
        /// </summary>
        /// <returns>Сумма всех товаров в корзине</returns>
        public decimal GetTotalSum()
        {
            return cartItems.Values.Sum(p => p.Quantity * p.Glassware.GW_Price);
        }

        /// <summary>
        /// Возвращает содержимое корзины товаров
        /// </summary>
        /// <returns>Коллекция товаров в корзине</returns>
        public IEnumerable<CartItem> GetItems()
        {
            return cartItems.Values;
        }
    }
}