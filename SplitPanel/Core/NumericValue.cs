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
using System.Collections.Immutable;

namespace WindowHelper
{
	public static class NumericValue
	{
		private const int    DecimalRadix       = 10;
		private const int    HexRadix           = 16;
		private const int    BinaryRadix        = 2;
		private const long   KiloMultiplier     = 1024;
		private const long   MegaMultiplier     = (KiloMultiplier * 1024);
		private const long   GigaMultiplier     = (MegaMultiplier * 1024);
		private const char   KiloMultiplierKey  = 'k';
		private const char   MegaMultiplierKey  = 'm';
		private const char   GigaMultiplierKey  = 'g';
		private const string HexRadixKey        = "0x";
		private const string BinaryRadixKey     = "0b";
		private const string InvalidInputError  = "A null or empty string cannot be parsed.";
		private const string InputTypeError     = "The input type to be parsed is not valid.";
		private const string InvalidFormatError = "The input is not in a valid format.";
		private const string OverflowError      = "The number is either too big or too small and overflows.";

		private delegate object ParseFunctionDelegate(string input, byte radix, long multiplier);

		private static readonly Dictionary<Type, ParseFunctionDelegate> ParseFunctions = new Dictionary<Type, ParseFunctionDelegate>
		{
			{ typeof(byte), ParseByte },
			{ typeof(ushort), ParseUShort },
			{ typeof(uint), ParseUInteger },
			{ typeof(ulong), ParseULong },
			{ typeof(sbyte), ParseSByte },
			{ typeof(short), ParseShort },
			{ typeof(int), ParseInteger },
			{ typeof(long), ParseLong },
			{ typeof(float), ParseFloat },
			{ typeof(double), ParseDouble }
		};

		private static readonly Dictionary<char, long> Multipliers = new Dictionary<char, long>()
		{
			{ KiloMultiplierKey, KiloMultiplier },
			{ MegaMultiplierKey, MegaMultiplier },
			{ GigaMultiplierKey, GigaMultiplier }
		};

		private static readonly Dictionary<string, byte> Radicies = new Dictionary<string, byte>()
		{
			{ BinaryRadixKey, BinaryRadix },
			{ HexRadixKey, HexRadix }
		};

		private static ImmutableHashSet<Type> validTypes;

		static NumericValue()
		{
			// Create valid types
			CreateValidTypes();
		}

		public static T Parse<T>(string input)
		{
			// Parse the generic number value
			return (T)Parse(input, typeof(T));
		}

		public static object Parse(string input, Type type)
		{
			// Make sure the input string is valid
			if (String.IsNullOrEmpty(input))
			{
				// The input is not valid
				throw new ArgumentNullException(InvalidInputError);
			}

			// Make sure the input type is valid
			else if (!ParseFunctions.ContainsKey(type))
			{
				// The input type is not valid
				throw new ArgumentException(InputTypeError);
			}

			// Make the entire input lowercase
			input = input.ToLower();

			// Get the information for the conversion
			byte radix      = StripRadix(ref input);
			long multiplier = StripMultiplier(ref input);

			try
			{
				// Parse the number
				return ParseFunctions[type](input, radix, multiplier);
			}
			catch (OverflowException e)
			{
				// The result has overflowed
				throw new Exception(OverflowError, e);
			}
			catch (Exception e)
			{
				// The input format was not valid
				throw new Exception(InvalidFormatError, e);
			}
		}

		private static void CreateValidTypes()
		{
			// Create new type table
			HashSet<Type> types = new HashSet<Type>();

			// Iterate through all of the types that the class handles
			foreach (Type type in ParseFunctions.Keys)
			{
				// Add the type to the type table
				types.Add(type);
			}

			// Create the valid types table
			validTypes = types.ToImmutableHashSet();
		}

		private static object ParseByte(string input, byte radix, long multiplier)
		{
			// Parse the byte value
			return (byte)(Convert.ToByte(input, radix) * multiplier);
		}

		private static object ParseUShort(string input, byte radix, long multiplier)
		{
			// Parse the unsigned short value
			return (ushort)(Convert.ToInt16(input, radix) * multiplier);
		}

		private static object ParseUInteger(string input, byte radix, long multiplier)
		{
			// Parse the unsigned integer value
			return (uint)(Convert.ToInt32(input, radix) * multiplier);
		}

		private static object ParseULong(string input, byte radix, long multiplier)
		{
			// Parse the unsigned long value
			return (Convert.ToUInt64(input, radix) * (ulong)multiplier);
		}

		private static object ParseSByte(string input, byte radix, long multiplier)
		{
			// Parse the sbyte value
			return (sbyte)(Convert.ToSByte(input, radix) * multiplier);
		}

		private static object ParseShort(string input, byte radix, long multiplier)
		{
			// Parse the short value
			return (short)(Convert.ToInt16(input, radix) * multiplier);
		}

		private static object ParseInteger(string input, byte radix, long multiplier)
		{
			// Parse the integer value
			return (int)(Convert.ToInt32(input, radix) * multiplier);
		}

		private static object ParseLong(string input, byte radix, long multiplier)
		{
			// Parse the long value
			return (Convert.ToInt64(input, radix) * multiplier);
		}

		private static object ParseFloat(string input, byte radix, long multiplier)
		{
			// If the radix is decimal, we convert the value as is
			if (radix == DecimalRadix)
			{
				// Convert the double value
				return (Convert.ToSingle(input) * multiplier);
			}

			// First convert the input into an integer value
			uint value = (uint)ParseUInteger(input, radix, multiplier);

			// Convert the double value using the raw integer bytes
			return BitConverter.ToSingle(BitConverter.GetBytes(value), 0);
		}

		private static object ParseDouble(string input, byte radix, long multiplier)
		{
			// If the radix is decimal, we convert the value as is
			if (radix == DecimalRadix)
			{
				// Convert the double value
				return (Convert.ToDouble(input) * multiplier);
			}

			// First convert the input into an integer value
			ulong value = (ulong)ParseULong(input, radix, multiplier);

			// Convert the double value using the raw integer bytes
			return BitConverter.ToDouble(BitConverter.GetBytes(value), 0);
		}

		private static byte StripRadix(ref string input)
		{
			// The default radix is decimal
			byte radix = DecimalRadix;

			// Iterate through potential radicies
			foreach (KeyValuePair<string, byte> kvp in Radicies)
			{
				// Get the radix key
				string key = kvp.Key;

				// Does the input start with the radix key?
				if (!input.StartsWith(key))
				{
					// Continue the iteration
					continue;
				}

				// Get the radix
				radix = Radicies[key];

				// Remove the radix key from the input
				input = input.Substring(key.Length);

				// Is the input still valid?
				if (input.Length == 0)
				{
					// The length of the string should not be 0 after stripping of the radix key
					throw new ArgumentException(InvalidFormatError);
				}
			}

			// Return the radix
			return radix;
		}

		private static long StripMultiplier(ref string input)
		{
			// The default multiplier is 1
			long multiplier = 1;

			// Get the last character in input
			char multKey = input[(input.Length - 1)];

			// Is this a valid multiplier key?
			if (Multipliers.ContainsKey(multKey))
			{
				// Get the new multiplier
				multiplier = Multipliers[multKey];

				// Adjust input text by stripping the multiplier key off the end
				input = input.Substring(0, (input.Length - 1));

				// Is the input still valid?
				if (input.Length == 0)
				{
					// The length of the string should not be 0 after stripping off the multiplier key
					throw new ArgumentException(InvalidFormatError);
				}
			}

			// Return the multiplier
			return multiplier;
		}

		public static ImmutableHashSet<Type> ValidTypes
		{
			get { return validTypes; }
		}
	}
}