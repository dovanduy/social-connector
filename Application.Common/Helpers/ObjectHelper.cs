namespace App.Common.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Validation.Attribute;

    public class ObjectHelper
    {
        public static TEntity Convert<TEntity>(object obj)
        {
            return AutoMapper.Mapper.Map<TEntity>(obj);
        }

        public static IList<ValidationRequest> GetPropertyAttributes<TValidator>(object obj) where TValidator : BaseAttribute
        {
            IList<ValidationRequest> validators = new List<ValidationRequest>();
            var properties = obj.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty).Select(
                    item => item.GetCustomAttributes<TValidator>()
                            .Select(validator => new ValidationRequest(validator, item.GetValue(obj, null), item.PropertyType.FullName))
                            .ToList());
            foreach (IEnumerable<ValidationRequest> attrs in properties)
            {
                if (attrs.Count() == 0) { continue; }

                validators = validators.Concat(attrs.ToList()).ToList();
            }

            return validators;
        }
    }
}