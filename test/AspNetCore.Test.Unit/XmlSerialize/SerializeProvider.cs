using FluentAssertions;
using System.Text;

namespace AspNetCore.Test.Unit.XmlSerialize
{
    public static class SerializeProvider
    {
        public static string Serialize(object target)
        {
            if (target is null)
                return string.Empty;

            var xmlBuilder = new StringBuilder();

            var nameOfClass = target.GetType().Name;

            xmlBuilder.Append(OpenTagFor(nameOfClass));

            var properties = target.GetType().Properties();
            foreach (var property in properties)
            {
                var nameOfProperty = property.Name;
                var value = property.GetValue(target);

                xmlBuilder.Append(GetTag(nameOfProperty, value));
            }

            xmlBuilder.Append(CloseTagFor(nameOfClass));

            return xmlBuilder.ToString();
        }

        private static string GetTag(string tag, object? value)
        {
            return $"{OpenTagFor(tag)}" +
                   $"{value}" +
                   $"{CloseTagFor(tag)}";
        }

        private static string OpenTagFor(string nameOfClass)
        {
            return $"<{nameOfClass}>";
        }
        private static string CloseTagFor(string nameOfClass)
        {
            return $"</{nameOfClass}>";
        }
    }
}