using System;
using System.Collections.Generic;
using System.Text;

namespace PersianSmsGate.Core.Extensions
{
    public class QueryParam : Dictionary<string, string>
    {
        public string Key { get; }
        public string Value { get; }
        public QueryParam(string key, string val)
        {
            Key = key;
            Value = val;
        }
    }
    public static class HttpClientExtensions
    {
        public static string QueryStringBuilder(this string url, List<QueryParam> Parameters)
        => QueryStringBuilder(url, Parameters.ToArray());

        public static string QueryStringBuilder(this string url, params QueryParam[] Parameters)
        {
            var sb = new StringBuilder();

            sb.Append(url);
            if (url.EndsWith("?") is false)
            {
                sb.Append("?");
            }

            var length = Parameters.Length;
            for (int i = 0; i < length; i++)
            {
                sb.Append(Parameters[i].Key);
                sb.Append("=");
                sb.Append(Parameters[i].Value);
                sb.Append("&");
            }

            return sb.ToString();
        }
    }
}
