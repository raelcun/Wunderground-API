﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.XPath;
using System.Linq;

namespace WundergroundAPI_v2
{
    public static class Extensions
    {
        public static string SelectSingleNodeNoError(this XPathNavigator navigator, string xpath)
        {
            try { return navigator.SelectSingleNode(xpath).InnerXml; }
            catch { return ""; }
        }

        public static string AsString<T>(this IEnumerable<T> list, int level = 0)
        {
            string ret = "{ ";
            foreach (Object o in list)
            {
                ret += o.ListVars(false, false, level - 1) + ", ";
            }
            ret = ret.TrimEnd(',', ' ');
            ret += " }";
            return ret;
        }

        public static string ListVars(this object o, bool multiline, bool showPrivate, int levels = 0)
        {
            string ret = "";
            if (!multiline) ret = "{ ";
            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            if (showPrivate) bindingFlags |= BindingFlags.NonPublic;

            Func<Type, bool> IsSimpleType =
                delegate(Type type)
                {
                    return
                    type.IsValueType ||
                    type.IsPrimitive ||
                    typeof(String) == type ||
                    typeof(Decimal) == type ||
                    typeof(DateTime) == type ||
                    typeof(DateTimeOffset) == type ||
                    typeof(TimeSpan) == type ||
                    typeof(Guid) == type ||
                    Convert.GetTypeCode(type) != TypeCode.Object;
                };

            Action<string, object, Type> WriteLine =
                delegate(string name, object value, Type t)
                {
                    ret += name + ": "; // append the field name

                    if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(List<>) && levels >= 1) // list
                    {
                        // convert the object into a list of objects
                        IEnumerable e = value as IEnumerable;
                        IEnumerable<object> objects = e.OfType<object>();
                        ret += objects.AsString(levels - 1);
                    }
                    else if (!IsSimpleType(t) && levels >= 1) // class
                    {
                        ret += ListVars(value, false, showPrivate, levels - 1);
                    }
                    else // other
                    {
                        ret += value.ToString();
                    }

                    if (multiline == true) { ret += "\n"; } else { ret += ", "; }
                };

            FieldInfo[] fields = o.GetType().GetFields(bindingFlags);
            foreach (FieldInfo field in fields)
                if (!field.IsDefined(typeof(CompilerGeneratedAttribute), false)) // ignore private backing fields generated by auto-properties
                {
                    object value = field.GetValue(o);
                    WriteLine(field.Name, value == null ? "NULL" : value, value == null ? typeof(string) : value.GetType());
                }

            PropertyInfo[] properties = o.GetType().GetProperties(bindingFlags);
            foreach (PropertyInfo property in properties)
                if (!property.IsDefined(typeof(CompilerGeneratedAttribute), false)) // ignore private backing fields generated by auto-properties
                {
                    object value = property.GetValue(o, null);
                    WriteLine(property.Name, value == null ? "NULL" : value, value == null ? typeof(string) : value.GetType());
                }

            ret = ret.TrimEnd(',', ' ');
            if (!multiline) ret += " }";

            return ret;
        }
    }
}