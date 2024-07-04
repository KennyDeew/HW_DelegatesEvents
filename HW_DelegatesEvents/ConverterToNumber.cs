namespace HW_DelegatesEvents
{
    public delegate float ConvertToFloatdel<T>(T obj);
    
    public static class ConverterToNumber
    {
        public static float convertToNumber<T>(T obj) where T : class 
        {
            if (obj is String strObj && File.Exists(strObj))
            {
                FileInfo strFileInfo = new FileInfo(strObj);
                return strFileInfo.Length;
            }
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
                if (float.TryParse(fProperty.GetValue(obj)?.ToString(), out float fresult))
                {
                    result += fresult;
                }
                
            }
            return result;
        }
    }
}
