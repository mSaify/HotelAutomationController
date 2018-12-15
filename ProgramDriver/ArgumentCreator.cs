using System;
using System.ComponentModel;
using System.Linq;
using ActionContract;

namespace ProgramDriver
{
    internal static class ArgumentCreator
    {
        private static string[] _messaageArr;

        public static ActionEventArgs GetEventArgs(string message)
        {
            _messaageArr = message.Split(',');
            return new ActionEventArgs()
            {
                ActionType = GetActionType(),
                ActionLocation = GetActionLocation()
            };
        }
        
        private static ActionLocation GetActionLocation()
        {
            var floor = _messaageArr.Length == 1 ?  0 : Convert.ToInt32(_messaageArr[1]);
            var subcorridor = _messaageArr.Length == 1 ? 0 : Convert.ToInt32(_messaageArr[2]);
            var actionLocation = new ActionLocation(floor,subcorridor);

            return actionLocation;
        }

        private static  ActionType GetActionType()
        {
            return _messaageArr[0].GetEnumFromDescription();
        }

        /// <summary>
        /// Function to get Enum from description
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public static ActionType GetEnumFromDescription(this string description)
        {
            var attributeEnumType = typeof(ActionType);
            var values = Enum.GetValues(attributeEnumType).Cast<ActionType>();
            return
                values.First(
                    value =>
                    {
                        var enumField = attributeEnumType.GetField(value.ToString());
                        var decriptionAttributesOnEnumfield = enumField.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        var enumDescriptionAttribute = (DescriptionAttribute)decriptionAttributesOnEnumfield.First();

                        return enumDescriptionAttribute.Description == description;
                    });
        }
    }
}
