using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Settings;

namespace NB.CartModule.Core
{
    public static class ModuleConstants
    {
        public static class Security
        {
            public static class Permissions
            {
                public const string Access = "CartModuleModule:access";
                public const string Create = "CartModuleModule:create";
                public const string Read = "CartModuleModule:read";
                public const string Update = "CartModuleModule:update";
                public const string Delete = "CartModuleModule:delete";

                public static string[] AllPermissions { get; } = { Read, Create, Access, Update, Delete };
            }
        }

        public static class Settings
        {
            public static class General
            {
                public static SettingDescriptor CartModuleModuleEnabled { get; } = new SettingDescriptor
                {
                    Name = "CartModuleModule.CartModuleModuleEnabled",
                    GroupName = "CartModuleModule|General",
                    ValueType = SettingValueType.Boolean,
                    DefaultValue = false
                };

                public static SettingDescriptor CartModuleModulePassword { get; } = new SettingDescriptor
                {
                    Name = "CartModuleModule.CartModuleModulePassword",
                    GroupName = "CartModuleModule|Advanced",
                    ValueType = SettingValueType.SecureString,
                    DefaultValue = "qwerty"
                };

                public static IEnumerable<SettingDescriptor> AllSettings
                {
                    get
                    {
                        yield return CartModuleModuleEnabled;
                        yield return CartModuleModulePassword;
                    }
                }
            }

            public static IEnumerable<SettingDescriptor> AllSettings
            {
                get
                {
                    return General.AllSettings;
                }
            }
        }
    }
}
