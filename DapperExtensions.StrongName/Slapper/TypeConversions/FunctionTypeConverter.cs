using System;
using static Slapper.AutoMapper.Configuration;

namespace DapperExtensions.SlapperTypeConvertions
{
    public class FunctionTypeConverter : ITypeConverter
    {
        private readonly string _memberName;
        private readonly Func<object, object> _converter;

        public FunctionTypeConverter(string memberName, Func<object, object> converter)
        {
            _memberName = memberName;
            _converter = converter;
        }

        public int Order => 1;

        public bool CanConvert(object value, Type type, string memberName)
        {
            return string.IsNullOrWhiteSpace(memberName) == false && memberName.Equals(_memberName, StringComparison.OrdinalIgnoreCase);
        }

        public object Convert(object value, Type type)
        {
            return _converter(value);
        }
    }
}