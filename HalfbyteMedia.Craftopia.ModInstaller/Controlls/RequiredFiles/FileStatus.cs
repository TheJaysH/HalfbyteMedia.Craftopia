using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls.RequiredFiles
{
    public enum FileStatus
    {
        [Description("Waiting for download")] 
        WAITING,

        [Description("Not Required")]
        NOT_REQUIRED,

        [Description("Downloading")]
        DOWNLOADING,

        [Description("Installing")]
        INSTALLING,

        [Description("Finished")]
        FINISHED,

        [Description("Error")]
        ERROR,
    }
  
    public static class FileStatusExtensions
    {
        public static string GetStatusString(this FileStatus fileStatus)
        {
            Type type = fileStatus.GetType();

            string name = Enum.GetName(type, fileStatus);

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
