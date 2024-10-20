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
using System.IO;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace WindowHelper
{
	public static class Program
	{
		public static readonly string Location;

		static Program()
		{
			// Get the current app domain
			AppDomain domain = AppDomain.CurrentDomain;

			// Set the program location
			Location = domain.BaseDirectory;

			// Attach assembly loaded event
			domain.AssemblyLoad += AssemblyLoaded;

			// Initialize any currently loaded assembly types
			InitializeTypes(domain.GetAssemblies());
		}

		public static void Initialize() { }

		public static void LoadAssembly(Type type) { }

		public static void Terminate(Enum value, string message = null)
		{
			// Terminate the program
			Terminate(((IConvertible)value).ToInt32(null), message);
		}

		public static void Terminate(int exitCode, string message = null)
		{
			// Is there anything to write to the output stream?
			if (message != null)
			{
				// Print a message to the output stream
				Console.WriteLine(message);
			}

			// Terminate the program
			Environment.Exit(exitCode);
		}

		private static void AssemblyLoaded(object sender, AssemblyLoadEventArgs args)
		{
			// Initialize the types in the assembly
			InitializeTypes(args.LoadedAssembly);
		}

		private static void InitializeTypes(Assembly[] assemblies)
		{
			// Iterate through the assemblies to initialize the types for
			foreach (Assembly assembly in assemblies)
			{
				// Initialize the types in the assembly
				InitializeTypes(assembly);
			}
		}

		private static void InitializeTypes(Assembly assembly)
		{
			// Iterate through all the types in the assembly
			foreach (Type type in assembly.GetTypes())
			{
				// Determine if the type should be initialized
				if (typeof(ITypeInitialize).IsAssignableFrom(type) && !type.IsInterface)
				{
					// Initialize the type
					RuntimeHelpers.RunClassConstructor(type.TypeHandle);
				}
			}
		}

		public static string WorkingDirectory
		{
			get { return Directory.GetCurrentDirectory(); }
		}
	}
}