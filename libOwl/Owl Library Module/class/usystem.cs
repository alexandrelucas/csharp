using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.Win32;
using System.Management;
using Microsoft.VisualBasic.Devices;

namespace LibraryOwl.UserSystem
{
    public class Register
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
            
            switch(HKEY)
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
    public class PCInfo
    {
        public enum InfoType
        {
            OSName,
            ProcessorName,
            AmountOfMemory,
            VideoCardName,
            VideoCardMemory,
            HardwareID

        }
        public static string GetSpecialFolders(System.Environment.SpecialFolder SpecialFolder)
        {
            return Environment.GetFolderPath(SpecialFolder);
        }
        /// <summary>
        /// Gets a the information of system
        /// </summary>
        /// <param name="InfoType"></param>
        /// <returns></returns>
        public static string GetSystemInfo(InfoType InfoType)
        {
            var MyComputer = new Computer();
            var Searcher = new ManagementObjectSearcher(@"root\CIMV2","SELECT * FROM Win32_VideoController");
            var searcher1 = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            string Value = string.Empty, vgaName = string.Empty, vgaMemory = string.Empty, proc = string.Empty, HWID = string.Empty;
            
            switch (InfoType)
            {
                case PCInfo.InfoType.OSName :
                    Value = MyComputer.Info.OSFullName;
                    break;
                case PCInfo.InfoType.ProcessorName :

                    foreach (ManagementObject queryObject in searcher1.Get()){
                        proc = queryObject.GetPropertyValue("Name").ToString();
                    }
                    
                    Value = proc;
                    break;
                case PCInfo.InfoType.AmountOfMemory :
                    Value = Math.Round((((Convert.ToDouble(Convert.ToDouble(Conversion.Val(MyComputer.Info.TotalPhysicalMemory))) / 1024)) / 1024), 2) + " MB";
                    break;
                case PCInfo.InfoType.VideoCardName :
                    foreach (ManagementObject queryObject in Searcher.Get())
                    {
                        vgaName = queryObject.GetPropertyValue("Name").ToString();
                    }
                    Value = vgaName;
                    break;
                case PCInfo.InfoType.VideoCardMemory :
                    foreach (ManagementObject queryObject in Searcher.Get())
                    {
                        vgaMemory = queryObject.GetPropertyValue("AdapterRam").ToString();
                    }
                    Value = Math.Round((((Convert.ToDouble(Convert.ToDouble(Conversion.Val(vgaMemory))) / 1024)) / 1024), 2) + " MB";
                    break;
                case PCInfo.InfoType.HardwareID :
                    var mc = new ManagementClass("win32_processor");
                    ManagementObjectCollection moc = mc.GetInstances();
                    foreach (ManagementObject mo in moc)
                    {
                        if (HWID == "")
                        {
                            HWID = mo.Properties["processorID"].Value.ToString();
                            break;
                        }
                    }
                    Value = HWID;
                    break;
            }
            return Value;
        }
    }
}