using System;
using System.Collections.Generic;
using System.Text;

namespace s3.Options
{
    /// <summary>
    /// A command-line option without the ability to take a parameter (see also OptionWithParameter)
    /// </summary>
    internal abstract class Option
    {
        /// <summary>
        /// A list of all the supported command-line options.  To add support for a new option,
        /// simply add an instance of a new type to the list.
        /// </summary>
        public static List<Type> AllOptions = new List<Type>() 
        { 
            typeof(Acl), 
            typeof(Backup), 
            typeof(Big),
            typeof(Days),
            typeof(Key),
            typeof(NoGUI),
            typeof(Secret),
            typeof(StorageClass),
            typeof(Sub),
            typeof(Sync), 
            typeof(Verbose),
            typeof(Yes)
        };

        /// <summary>
        /// Overridden in OptionWithParameter to accept a generic parameter
        /// </summary>
        /// <param name="parameter"></param>
        protected virtual void Initialise(string parameter)
        {
            if (!string.IsNullOrEmpty(parameter))
                throw new SyntaxException(string.Format("The {0} option does not accept a parameter", GetType().Name));
        }

        public static string OptionPrefix
        {
            get
            {
                if (Utils.IsLinux)
                    return "--";
                else
                    return "/";
            }
        }

        const char parameterSeparator = ':';

        /// <summary>
        /// Factory method to create an instance of any Option from the user-supplied command-line
        /// </summary>
        /// <param name="option">One command-line parameter</param>
        /// <returns>An instance of the appropriate Option, or null on failure</returns>
        public static Option FromString(string option)
        {
            if (option.StartsWith(OptionPrefix))
            {
                int separatorPosition = option.IndexOf(parameterSeparator);

                string optionName, parameter;
                if (separatorPosition == -1)
                {
                    optionName = option.Substring(OptionPrefix.Length);
                    parameter = null;
                }
                else
                {
                    optionName = option.Substring(OptionPrefix.Length, separatorPosition - OptionPrefix.Length);
                    parameter = option.Substring(separatorPosition + 1);
                }

                foreach (Type o in AllOptions)
                    if (o.Name.Equals(optionName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Option optionObject = (Option)Activator.CreateInstance(o);
                        // not using a constructor to initialise because we don't want explicit constructors in all the derived Option classes
                        optionObject.Initialise(parameter);
                        return optionObject;
                    }

                throw new SyntaxException(string.Format("Unrecognised option: {0}", optionName));
            }
            else
                return null;
        }
    }
}
