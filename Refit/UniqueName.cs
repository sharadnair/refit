﻿namespace Refit
{
    internal class UniqueName
    {
        public static string ForType<T>()
        {
            string typeName;

            if (typeof(T).IsNested)
            {
                var className = "AutoGenerated" + typeof(T).DeclaringType.Name + typeof(T).Name;
                typeName = typeof(T).AssemblyQualifiedName.Replace(typeof(T).DeclaringType.FullName + "+" + typeof(T).Name, typeof(T).Namespace + "." + className);
            }
            else
            {
                var className = "AutoGenerated" + typeof(T).Name;

                if (typeof(T).Namespace == null)
                {
                    className = $"{className}.{className}";
                }

                typeName = typeof(T).AssemblyQualifiedName.Replace(typeof(T).Name, className);
            }

            return typeName;
        }
    }
}
