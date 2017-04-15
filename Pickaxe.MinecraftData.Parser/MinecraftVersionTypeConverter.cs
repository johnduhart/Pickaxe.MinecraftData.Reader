using System;
using System.ComponentModel;
using System.Globalization;

namespace Pickaxe.MinecraftData.Parser
{
    public class MinecraftVersionTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string str = value as string;
            if (str == null)
            {
                return base.ConvertFrom(context, culture, value);
            }

            str = str.Trim();
            if (str.Length == 0)
            {
                return base.ConvertFrom(context, culture, value);
            }

            return new MinecraftVersion(str);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
                throw new ArgumentNullException(nameof(destinationType));

            if (value is MinecraftVersion && destinationType == typeof(string))
            {
                return ((MinecraftVersion) value).VersionString;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}