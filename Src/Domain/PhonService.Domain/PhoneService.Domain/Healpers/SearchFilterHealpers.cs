using PhoneService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Services.Healpers
{
    public class SearchFilterHealpers
    {
        private IEnumerable<object> SearchByDateFrom(IEnumerable<object> items, object filterValue, System.Reflection.PropertyInfo filter)
        {
            items = items.Where
                    (p => Convert.ToDateTime(p.GetType()
                    .GetProperty(filter.Name).GetValue(p))
                    <= Convert.ToDateTime(filterValue));

            return items;
        }

        private IEnumerable<object> SearchByDateTo(IEnumerable<object> items, object filterValue, System.Reflection.PropertyInfo filter)
        {
            items = items.Where
                    (p => Convert.ToDateTime(p.GetType()
                    .GetProperty(filter.Name).GetValue(p))
                    >= Convert.ToDateTime(filterValue));

            return items;
        }

        private IEnumerable<object> SearchByContains(IEnumerable<object> items, object filterValue, System.Reflection.PropertyInfo filter)
        {
            items = items.Where
                    (p => p.GetType()
                    .GetProperty(filter.Name)
                    .GetValue(p).ToString()
                    .Contains(filterValue.ToString()));

            return items;
        }

        public async Task<IEnumerable<object>> SearchByContains(IEnumerable<object> items, object contains)
        {
            foreach (var filter in contains.GetType().GetProperties())
            {
                var filterValue = filter.GetValue(contains);
                var isDateTime = filter.ToString();

                if (filterValue != null)
                    if (filterValue.ToString() != 0.ToString())
                    {
                        if (isDateTime.Contains("DateFrom"))
                        {
                            items = SearchByDateFrom(items, filterValue, filter);
                        }
                        if (isDateTime.Contains("DateTo"))
                        {
                            items = SearchByDateTo(items, filterValue, filter);
                        }
                        {
                            items = SearchByContains(items, filterValue, filter);
                        }
                    }
            }
            var response = await items.ToAsyncEnumerable().ToList();

            return response;
        }
    }
}
