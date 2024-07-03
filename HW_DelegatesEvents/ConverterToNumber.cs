using System;
using System.Collections;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_DelegatesEvents
{
    public delegate float ConvertToFloatdel<T>(T obj);

    public static class ConverterToNumber
    {
        public static float convertToNumber123<T>(T obj)
        {
            //Конвертируем объект в string и считаем кол-во символов
            float result = (obj.ToString() ?? string.Empty).Length;
            //Считаем все свойства объекта, которые не null
            var objectType = typeof(T);
            if (objectType.GetProperties().Length != 0)
            {
                result += objectType.GetProperties().Where(P => P.GetValue(obj) != null).Count() / objectType.GetProperties().Length;
            }
            //Если есть свойства типа float считаем их
            foreach (var fProperty in objectType.GetProperties().Where(P => P.PropertyType == typeof(float)))
            {
                if (float.TryParse(fProperty.GetValue(obj).ToString(), out float fresult))
                {
                    result += fresult;
                }
                
            }
            return result;
        }
    }
}
