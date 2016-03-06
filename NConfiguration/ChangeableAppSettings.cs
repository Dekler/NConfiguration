using NConfiguration.Combination;
using NConfiguration.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NConfiguration
{
	public sealed class ChangeableAppSettings : IAppSettings, IChangeable
	{
		public ChangeableAppSettings(IConfigNodeProvider nodeProvider)
			: this(nodeProvider, DefaultDeserializer.Instance, DefaultCombiner.Instance)
		{
		}

		public ChangeableAppSettings(IConfigNodeProvider nodeProvider, IDeserializer deserializer, ICombiner combiner)
		{
			Nodes = nodeProvider;
			Deserializer = deserializer;
			Combiner = combiner;
		}

		public IConfigNodeProvider Nodes { get; private set; }

		public IDeserializer Deserializer { get; private set; }

		public ICombiner Combiner { get; private set; }

		public event EventHandler Changed
		{
			add
			{
				var changeable = Nodes as IChangeable;
				if (changeable != null)
					changeable.Changed += value;
			}
			remove
			{
				var changeable = Nodes as IChangeable;
				if (changeable != null)
					changeable.Changed -= value;
			}
		}
	}
}
