using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Ansa.Extensions
{
    /// <summary>
    /// Extension methods for types that implement an IEnumerable interface
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Converts a generic <see cref="IEnumerable"/> to a <see cref="DataTable"/> object
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="data">A type that implementing an IEnumerable interface</param>
        /// <returns>A <see cref="DataTable"/> object</returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            var properties = TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (var item in data)
            {
                var row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }

            return table;
        }
    }
}