﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NConfiguration.GenericView
{
	internal class NameComparer
	{
		public static readonly IEqualityComparer<string> Instance = StringComparer.InvariantCultureIgnoreCase;

		public static bool Equals(string x, string y)
		{
			return Instance.Equals(x, y);
		}
	}
}
