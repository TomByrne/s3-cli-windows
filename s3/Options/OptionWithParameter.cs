using System;
using System.Collections.Generic;
using System.Text;

namespace s3.Options
{
    /// <summary>
    /// A command-line option that accepts a parameter after the option name and a colon,
    /// e.g. /big:5
    /// </summary>
    /// <typeparam name="parameterType">The type of the parameter.  The user-supplied value is automatically cast to this type.</typeparam>
    abstract class OptionWithParameter<parameterType> : Option
    {
        /// <summary>
        /// Return true if the parameter must always be supplied by the user, or false if it is optional
        /// </summary>
        protected abstract bool parameterIsCompulsory { get; }

        /// <summary>
        /// Set to true if a parameter has been supplied by the user
        /// </summary>
        public bool parameterIsPresent { get; private set; }

        /// <summary>
        /// The value of the supplied parameter
        /// </summary>
        public parameterType parameter { get; private set; }

        /// <summary>
        /// Takes the user-supplied parameter, if supplied, and attempts to convert it into the required type
        /// </summary>
        /// <param name="value"></param>
        protected sealed override void initialise(string value)
        {
            parameterIsPresent = !string.IsNullOrEmpty(value);

            if (parameterIsPresent)
            {
                try
                {
                    parameter = (parameterType)Convert.ChangeType(value, typeof(parameterType));
                }
                catch (FormatException)
                {
                    throw new SyntaxException(string.Format("The {0} option takes a parameter of type {1}, but you provided '{2}'",
                        GetType().Name, typeof(parameterType).Name, value));
                }

                parameterIsSet();
            }
            else if (parameterIsCompulsory)
                throw new SyntaxException(string.Format("The {0} option requires a parameter", GetType().Name));
        }

        internal static parameterType getOptionParameter(CommandLine cl, Type type, bool optionIsRequired)
        {
            if (cl.options.ContainsKey(type))
                return (cl.options[type] as OptionWithParameter<parameterType>).parameter;
            else
            {
                if (optionIsRequired)
                    throw new SyntaxException(string.Format("The {0} command requires the {1} option", cl.command.GetType().Name, type.Name));
                else
                    return default(parameterType);
            }
        }

        protected virtual void parameterIsSet() { }
    }
}
