using System.Dynamic;

namespace CoreApi.Model
{
    public class Utils
    {
        public static dynamic StringToDecimal(dynamic data)
        {
            if (data != null)
            {
                var result = new ExpandoObject();
                var resultDict = (IDictionary<string, object>)result;
                foreach (var property in (IDictionary<string, object>)data)
                {
                    // اگر مقدار قابل تبدیل به float است، تبدیلش کن
                    if (decimal.TryParse(property.Value?.ToString(), out decimal decimalValue))
                    {
                        resultDict[property.Key] = (float)decimalValue;
                    }
                    else
                    {
                        resultDict[property.Key] = property.Value;
                    }
                }

                return result;
            }
            return null;
        }
    }
}
