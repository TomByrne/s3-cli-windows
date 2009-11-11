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
        static List<Type> allOptions = new List<Type>() 
        { 
            typeof(Acl), 
            typeof(Backup), 
            typeof(Big), 
            typeof(Sub),
            typeof(Sync), 
            typeof(Verbose),
            typeof(Yes),
            typeof(AccessKey),
            typeof(SecretKey)
        };

        /// <summary>
        /// Overridden in OptionWithParameter to accept a generic parameter
        /// </summary>
        /// <param name="parameter"></param>
        protected virtual void initialise(string parameter)
        {
            if (!string.IsNullOrEmpty(parameter))
                throw new SyntaxException(string.Format("The {0} option does not accept a parameter", GetType().Name));
        }

        const string optionPrefix = "/";
        const char parameterSeparator = ':';

        /// <summary>
        /// Factory method to create an instance of any Option from the user-supplied command-line
        /// </summary>
        /// <param name="option">One command-line parameter</param>
        /// <returns>An instance of the appropriate Option, or null on failure</returns>
        public static Option fromString(string option)
        {
            if (option.StartsWith(optionPrefix))
            {
                int separatorPosition = option.IndexOf(parameterSeparator);

                string optionName, parameter;
                if (separatorPosition == -1)
                {
                    optionName = option.Substring(1);
                    parameter = null;
                }
                else
                {
                    optionName = option.Substring(1, separatorPosition - 1);
                    parameter = option.Substring(separatorPosition + 1);
                }

                foreach (Type o in allOptions)
                    if (o.Name.Equals(optionName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Option optionObject = (Option)Activator.CreateInstance(o);
                        // not using a constructor to initialise because we don't want explicit constructors in all the derived Option classes
                        optionObject.initialise(parameter);
                        return optionObject;
                    }

                throw new SyntaxException(string.Format("Unrecognised option: {0}", optionName));
            }
            else
                return null;
        }
    }
}
