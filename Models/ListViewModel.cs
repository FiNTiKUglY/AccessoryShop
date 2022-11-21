using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq.Expressions;

namespace WEB_053505_Pronin.Models
{
    public class ListViewModel<T> : List<T>
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        public ListViewModel(IQueryable<T> list, int current, int total) : base(list)
        {
            TotalPages = total;
            CurrentPage = current;
        }

        public static ListViewModel<T> GetModel(IQueryable<T> list, int current, int itemsPerPage, Expression<Func<T, bool>> filter)
        {
            var totalItems = list.Where(filter);
            var items = totalItems
                            .Skip((current - 1) * itemsPerPage)
                            .Take(itemsPerPage);
            var total = (int)Math.Ceiling((double)totalItems.Count() / itemsPerPage);
            return new ListViewModel<T>(items, current, total);
        }
    }
}
