using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PhoneService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Services.Healpers
{
    public class SearchFilterHealpers
    {
        private IEnumerable<object> SearchByDateFrom(IEnumerable<object> items, DateTime dateFrom, PropertyInfo filter)
        {
            items = items.Where
                    (p => Convert.ToDateTime(p.GetType()
                    .GetProperty(filter.Name).GetValue(p))
                    <= Convert.ToDateTime(dateFrom));

            return items;
        }

        private IEnumerable<object> SearchByDateTo(IEnumerable<object> items, DateTime dateTo, PropertyInfo filter)
        {
            items = items.Where
                    (p => Convert.ToDateTime(p.GetType()
                    .GetProperty(filter.Name).GetValue(p))
                    >= Convert.ToDateTime(dateTo));

            return items;
        }

        private IEnumerable<object> SearchByContains(IEnumerable<object> items, object filterValue, PropertyInfo filter)
        {
            items = items.Where
                    (p => p.GetType()   
                    .GetProperty(filter.Name)
                    .GetValue(p).ToString().ToLower().Trim()
                    .Contains(filterValue.ToString().ToLower().Trim()));

            return items;
        }

        private IEnumerable<object> SearchByInnerContains(IEnumerable<object> items, object innerFilterValue, PropertyInfo filter, PropertyInfo innerFilter)
        {

            items = items.Where
                    (p => p.GetType().GetProperty(filter.Name)
                            .PropertyType.GetProperty(innerFilter.Name).GetValue(p
                            .GetType().GetProperty(filter.Name).GetValue(p))
                            .ToString().ToLower().Trim()
                            .Contains(innerFilterValue.ToString().ToLower().Trim()));

            return items;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public object GetPropertyValue(object obj, string propertyName)
        {
            var objType = obj.GetType();
            var prop = objType.GetProperty(propertyName);

            return prop.GetValue(obj, null);
        }

        public async Task<IEnumerable<object>> SearchByContains(IEnumerable<object> items, object contains)
        {
            foreach (var filter in contains.GetType().GetProperties())
            {
                var filterValue = filter.GetValue(contains);

                if (filterValue != null)
                    if (filterValue.ToString() != 0.ToString())
                    {
                        var itemCount = filterValue.GetType().GetProperties().Count();

                        if (itemCount != 2)
                        {
                            foreach (var innerFilter in filterValue.GetType().GetProperties())
                            {
                                var innerFilterValue = innerFilter.GetValue(filterValue);

                                if (innerFilterValue != null && innerFilterValue.ToString() != 0.ToString())
                                    items = SearchByInnerContains(items, innerFilterValue, filter, innerFilter);
                            }
                        }
                        else
                        {
                            items = SearchByContains(items, filterValue, filter);
                        }
                    }
            }
            var response = await items.ToAsyncEnumerable().ToList();

            return response;
        }

        public async Task<IEnumerable<object>> SearchByContainsWithDateAsync(DateTime dateFrom, DateTime dateTo, IEnumerable<object> items, object contains)
        {
            foreach (var filter in contains.GetType().GetProperties())
            {
                var filterValue = filter.GetValue(contains);
                var propName = filter.ToString();

               
                if (filterValue != null
                        && filterValue.ToString() != 0.ToString())
                {
                    var itemCount = filterValue.GetType().GetProperties().Count();

                    if (itemCount != 2)
                    {
                        foreach (var innerFilter in filterValue.GetType().GetProperties())
                        {
                            var innerFilterValue = innerFilter.GetValue(filterValue);

                            if (innerFilterValue != null && innerFilterValue.ToString() != 0.ToString())
                                items = SearchByInnerContains(items, innerFilterValue, filter, innerFilter);
                        }
                    }
                    else
                    {
                        items = SearchByContains(items, filterValue, filter);
                    }
                }
                else if (propName == "CreateDate")
                {
                    if (dateFrom != null)
                    {
                        items = SearchByDateFrom(items, dateFrom, filter);
                    }

                    if (dateTo != null)
                    {
                        items = SearchByDateTo(items, dateTo, filter);
                    }
                }
            }
            var response = await items.ToAsyncEnumerable().ToList();

            return response;
        }
    }
}
