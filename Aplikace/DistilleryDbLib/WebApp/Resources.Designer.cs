﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WebApp.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Název obce/města musí být vyplněn..
        /// </summary>
        internal static string CityNameMissing {
            get {
                return ResourceManager.GetString("CityNameMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PSČ musí být vyplněno..
        /// </summary>
        internal static string CityZipMissing {
            get {
                return ResourceManager.GetString("CityZipMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Číslo popisné musí být vyplněno..
        /// </summary>
        internal static string HouseNumberMissing {
            get {
                return ResourceManager.GetString("HouseNumberMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Přihlašovací login musí být vyplněn..
        /// </summary>
        internal static string LoginMissing {
            get {
                return ResourceManager.GetString("LoginMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Jméno musí být veplněno..
        /// </summary>
        internal static string NameMissing {
            get {
                return ResourceManager.GetString("NameMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Heslo musí být vyplněné..
        /// </summary>
        internal static string PasswordMissing {
            get {
                return ResourceManager.GetString("PasswordMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rodné číslo musí být vyplněno..
        /// </summary>
        internal static string PersonalNumberMissing {
            get {
                return ResourceManager.GetString("PersonalNumberMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Příjmení musí být vyplněno..
        /// </summary>
        internal static string SureNameMissing {
            get {
                return ResourceManager.GetString("SureNameMissing", resourceCulture);
            }
        }
    }
}
