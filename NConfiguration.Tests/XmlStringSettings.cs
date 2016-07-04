using System.Xml.Linq;
using NConfiguration.Xml;

namespace NConfiguration
{
	public class XmlStringSettings : XmlSettings, IIdentifiedSource
	{
		private readonly XElement _root;
		private readonly string _hash;

		public XmlStringSettings(string text)
		{
			_hash = text.GetHashCode().ToString();
			_root = XDocument.Parse(text).Root;
		}

		protected override XElement Root
		{
			get
			{
				return _root;
			}
		}

		public string Identity
		{
			get
			{
				return _hash;
			}
		}
	}
}

