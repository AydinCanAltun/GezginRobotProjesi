using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GezginRobotProjesi.Helpers
{
    public static class RandomExtensions
    {
        public static T GetEnumValue<T>(this Random r){
            var enumValues = Enum.GetValues(typeof(T));
            return (T)enumValues.GetValue(r.Next(enumValues.Length));
        }
    }
}