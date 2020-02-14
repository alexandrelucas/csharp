using System;
using Microsoft.Win32;

namespace CSBTE
{
    class RegisterWin32
    {
        RegistryKey MainRegister;
        public enum RegHKey
        {
            CLASSES_ROOT,
            CURRENT_USER,
            LOCAL_MACHINE,
            USERS,
            CURRENT_CONFIG
        }
        /// <summary>
        /// Gets a value in the Windows registry.
        /// </summary>
        public object GetKeyValue(RegHKey HKEY, string SubKey, string Name, bool CanWrite)
        {
            switch (HKEY)
            {
                case RegHKey.CLASSES_ROOT:
                    MainRegister = Registry.ClassesRoot.OpenSubKey(SubKey, CanWrite);
                    break;
                case RegHKey.CURRENT_CONFIG:
                    MainRegister = Registry.CurrentConfig.OpenSubKey(SubKey, CanWrite);
                    break;
                case RegHKey.CURRENT_USER:
                    MainRegister = Registry.CurrentUser.OpenSubKey(SubKey, CanWrite);
                    break;
                case RegHKey.LOCAL_MACHINE:
                    MainRegister = Registry.LocalMachine.OpenSubKey(SubKey, CanWrite);
                    break;
                case RegHKey.USERS:
                    MainRegister = Registry.Users.OpenSubKey(SubKey, CanWrite);
                    break;
                default:
                    return null;
            }
            return MainRegister.GetValue(Name);

        }
        /// <summary>
        /// Sets a value in the Windows registry.
        /// </summary>
        public void SetKeyValue(RegHKey HKEY, string SubKey, string Name, object Value, Microsoft.Win32.RegistryValueKind ValueKind, bool CanWrite)
        {

            switch (HKEY)
            {
                case RegHKey.CLASSES_ROOT:
                    MainRegister = Registry.ClassesRoot.OpenSubKey(SubKey, CanWrite);
                    break;
                case RegHKey.CURRENT_CONFIG:
                    MainRegister = Registry.CurrentConfig.OpenSubKey(SubKey, CanWrite);
                    break;
                case RegHKey.CURRENT_USER:
                    MainRegister = Registry.CurrentUser.OpenSubKey(SubKey, CanWrite);
                    break;
                case RegHKey.LOCAL_MACHINE:
                    MainRegister = Registry.LocalMachine.OpenSubKey(SubKey, CanWrite);
                    break;
                case RegHKey.USERS:
                    MainRegister = Registry.Users.OpenSubKey(SubKey, CanWrite);
                    break;
            }
            MainRegister.SetValue(Name, Value, ValueKind);
        }
    }

}
