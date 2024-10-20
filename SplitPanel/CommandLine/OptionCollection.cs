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
using System.Collections.Generic;
using System.Reflection;

namespace WindowHelper.CommandLine
{
	internal class OptionCollection<T> where T : UserOptions
	{
		private const string       DuplicateOptionErrorFormat = "An option with the switch: {0} already exists.";
		private const BindingFlags MethodFlags                = (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

		public T                          UserOptions     { get; private set; }
		public Dictionary<string, Option> RequiredOptions { get; private set; }

		private Dictionary<string, Option> items;

		public OptionCollection()
		{
			// Initialize properties
			UserOptions     = (T)Activator.CreateInstance(typeof(T));
			items           = new Dictionary<string, Option>();
			RequiredOptions = new Dictionary<string, Option>();

			// Initialize the map
			Initialize();
		}

		public bool ContainsKey(string key)
		{
			// Return a value indicating if the option is in the collection
			return items.ContainsKey(key);
		}

		private void Initialize()
		{
			// Get all of the methods in the options class
			MethodInfo[] methods = typeof(T).GetMethods(MethodFlags);

			// Iterate through all of the methods
			foreach (MethodInfo method in methods)
			{
				// Get the parse function attribute applied to the method
				ParseFunctionAttribute attr = method.GetCustomAttribute<ParseFunctionAttribute>();

				// Was the attribute set on the function?
				if (attr == null)
				{
					// The attribute was not set on the function
					continue;
				}

				// Create a new option
				Option option       = new Option(UserOptions, method, attr);
				string optionSwitch = option.Switch;

				// Does the collection already contain an option with the same key?
				if (items.ContainsKey(optionSwitch))
				{
					// The option switch is a duplicate
					throw new Exception(String.Format(DuplicateOptionErrorFormat, optionSwitch));
				}

				// Add the option to the collection
				items.Add(optionSwitch, option);

				// Is the option required?
				if (option.Required)
				{
					// Add the option to the required options collection
					RequiredOptions.Add(optionSwitch, option);
				}
			}
		}

		public Option this[string key]
		{
			get { return items[key]; }
		}
	}
}