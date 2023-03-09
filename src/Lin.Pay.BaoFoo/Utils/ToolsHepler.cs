using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Lin.Pay.BaoFoo.Attributes;

namespace Lin.Pay.BaoFoo.Utils;

/// <summary>
/// 工具
/// </summary>
public static class ToolsHepler
{
    /// <summary>
    /// 属性转Dictionary
    /// </summary>
    /// <param name="data"></param>
    /// <param name="path"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Dictionary<string, string> PropertyToDictionary<T>(T data, string path)
    {
        var dic = new Dictionary<string, string>();
        var encryptAttributeType = typeof(EncryptAttribute);
        var jsonSerializeAttributeType = typeof(JsonSerializeAttribute);
        var propertyInfos = data.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
        foreach (var item in propertyInfos)
        {
            var jsonPropertyNameAttribute = item.GetCustomAttribute<JsonPropertyNameAttribute>();
            if (jsonPropertyNameAttribute is null) continue;

            var value = item.GetValue(data);

            if (item.CustomAttributes.Any(e => e.AttributeType == encryptAttributeType))
            {
                dic.Add(jsonPropertyNameAttribute.Name,
                    RSAHelper.EncryptByCer(value?.ToString() ?? string.Empty, path));
                continue;
            }

            if (item.CustomAttributes.Any(e => e.AttributeType == jsonSerializeAttributeType))
            {
                dic.Add(jsonPropertyNameAttribute.Name, JsonSerializer.Serialize(value));
                continue;
            }

            dic.Add(jsonPropertyNameAttribute.Name, value?.ToString() ?? string.Empty);
        }

        return dic;
    }

    /// <summary>
    /// 属性转Dictionary
    /// </summary>
    /// <param name="data"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Dictionary<string, string> PropertyToDictionary<T>(T data)
    {
        var dic = new Dictionary<string, string>();
        var propertyInfos = data.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
        foreach (var item in propertyInfos)
        {
            var jsonPropertyNameAttribute = item.GetCustomAttribute<JsonPropertyNameAttribute>();
            if (jsonPropertyNameAttribute is null) continue;

            var value = item.GetValue(data) ?? string.Empty;
            dic.Add(jsonPropertyNameAttribute.Name, value.ToString());
        }

        return dic;
    }


    /// <summary>
    /// 检查KEY是否存在
    /// </summary>
    /// <param name="keyStr"></param>
    /// <param name="dic"></param>
    public static void ContainsKeyIsExists<T>(string keyStr, Dictionary<string, T> dic)
    {
        var keys = keyStr.Split('|');
        foreach (var key in keys)
        {
            if (!dic.ContainsKey(key) && key.ToLower() != "null")
            {
                throw new Exception(key + " is not found");
            }
        }
    }

    /// <summary>
    /// 按格式输出验签串
    /// </summary>
    /// <param name="strSignData"></param>
    /// <param name="dic"></param>
    /// <returns></returns>
    public static string VerifyString(string strSignData, Dictionary<string, string> dic)
    {
        ContainsKeyIsExists(strSignData, dic);
        var paramList = strSignData.Split('|');
        foreach (var key in paramList)
        {
            if (string.IsNullOrEmpty(key) || key == "null")
            {
                continue;
            }

            strSignData = strSignData.Replace(key.Trim(), dic[key]);
        }

        return strSignData;
    }

    
    public static string JsonToUrlEncode(string json)
    {
        var dic = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        var builder = new StringBuilder();
        foreach (var item in dic)
        {
            builder.Append($"{item.Key}={item.Value}");
            builder.Append("&");
        }

        return builder.ToString().TrimEnd('&');
    }
}