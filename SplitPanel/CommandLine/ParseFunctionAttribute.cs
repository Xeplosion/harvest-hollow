// ------------------------------------------------------
// ---------- Copyright (c) 2017 Colton Murphy ----------
// ------------------------------------------------------
// ------------------------------------------------------
// ------------------------------------------------------
// ------------------------------------------------------
// ------------------------------------------------------
// ------------------------------------------------------
// ------------------------------------------------------
// ------------------------------------------------------
// ------------------------------------------------------
// ------------------------------------------------------
// ------------------------------------------------------

using System;

namespace WindowHelper.CommandLine
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ParseFunctionAttribute : Attribute
    {
        public bool AllowMultiple { get; private set; }
        public bool Required { get; private set; }
        public string Switch { get; private set; }

        public ParseFunctionAttribute(string optionSwitch, bool allowMultiple = false, bool required = false)
        {
            // Initialize the attribute
            Switch = optionSwitch;
            AllowMultiple = allowMultiple;
            Required = required;
        }
    }
}