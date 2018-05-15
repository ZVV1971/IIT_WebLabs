using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZVV_Web_Lab_1.Models
{
    public class PageListViewModel <T> : List<T> where T : class
    {
        /// <summary>
        /// Общее количество страниц
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Номер текущей страницы
        /// </summary>
        public int CurrentPage { get; private set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="items">список элементов</param>
        /// <param name="total">общее количество страниц</param>
        /// <param name="current">номер текущей страницы</param>
        private PageListViewModel(List<T> items, int total, int current)
        {
            AddRange(items);
            TotalPages = total;
            CurrentPage = current;
        }

        /// <summary>
        /// Создание объекта PageListViewModel
        /// </summary>
        /// <param name="items">Полный список объектов</param>
        /// <param name="current">номер текущей страницы</param>
        /// <param name="pageSize">кол. элементов на странице</param>
        /// <returns></returns>
        public static PageListViewModel<T> CreatePage(IEnumerable<T> items,
                                                int current, int pageSize)
        {
            int totalCount = items.Count();
            int pagesCount = (int)Math.Ceiling(totalCount / (double)pageSize);
            IEnumerable<T> list = items
                .Skip(pageSize * (current - 1))
                .Take(pageSize)
                .ToList();
            return new PageListViewModel<T>(list.ToList<T>(), pagesCount, current);
        }
    }
}