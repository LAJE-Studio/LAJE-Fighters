using System;
using Object = UnityEngine.Object;

namespace LAJEFighters.Scripts.Utilities {
    public static class Preconditions {
        public static T RequirePresent<T>(this T obj, string field = "unspecified") where T : Object{
            if (obj == null) {
                throw new ArgumentNullException(string.Format("Object of field {0} is null!", field));
            }

            return obj;
        }
    }
}