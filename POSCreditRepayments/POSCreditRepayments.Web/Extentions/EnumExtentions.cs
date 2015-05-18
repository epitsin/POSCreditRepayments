﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Web.Mvc;

namespace POSCreditRepayments.Web.Extentions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Extends the enumeration so that if it has Description attribute on top of the value, it can be taken as a friendly text instead of the basic ToString method
        /// </summary>
        public static string GetDescription<T>(this T enumerationValue)
            where T : struct, IConvertible
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            // Tries to find a DescriptionAttribute for a potential friendly name for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    // Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            // If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }

        public static IList<SelectListItem> GetDropdownListItems<T>(this T enumerationValue)
            where T : struct, IConvertible
        {
            IList<SelectListItem> list = new List<SelectListItem>();
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                list.Add(new SelectListItem()
                {
                    Text = item.GetDescription(),
                    Value = Convert.ToInt32(item).ToString()
                });
            }

            return list;
        }
    }
}