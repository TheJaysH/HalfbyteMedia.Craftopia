using System;
using System.ComponentModel;
using System.Reflection;
using System.Linq;

namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls
{
    public enum ControlType
    {
        [Description("EULA")]
        Disclaimer = 0,
        
        [Description("Installation Directory")]
        Setup = 1,
        
        [Description("Gather Required Files")]
        RequiredFiles = 2,

        [Description("Set Craftopia Permissions")]
        ModCraftopia = 3,
    }

    public static class ControlTypeExtensions
    {
        public static string ToString(this ControlType controlType)
        {
            return GetControlTypeString(controlType);
        }

        public static string GetControlTypeString(this ControlType controlType)
        {
            Type type = controlType.GetType();

            string name = Enum.GetName(type, controlType);

            MemberInfo member = type.GetMembers()
                .Where(w => w.Name == name)
                .FirstOrDefault();

            DescriptionAttribute attribute = member != null
                ? member.GetCustomAttributes(true)
                    .Where(w => w.GetType() == typeof(DescriptionAttribute))
                    .FirstOrDefault() as DescriptionAttribute
                : null;

            return attribute != null ? attribute.Description : name;
        }
    }
}
