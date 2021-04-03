﻿using Company.Communication.CompanyService;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Company.Converters
{
    class DepartmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null && value is Department)
            {
                switch (value)
                {
                    case Department.Purchasing:
                        return "Отдел закупок";
                    case Department.Sales:
                        return "Отдел продаж";
                    case Department.Service:
                        return "Отдел сервиса";
                }
            }
            return "Отдел продаж";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
