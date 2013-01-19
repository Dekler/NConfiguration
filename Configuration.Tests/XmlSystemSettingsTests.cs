using Configuration.Xml;
using NUnit.Framework;
using Configuration.GenericView;

namespace Configuration
{
	[TestFixture]
	public class XmlSystemSettingsTests
	{
		[Test]
		public void ReadForDefaultName()
		{
			var cfg = new XmlSystemSettings("ExtConfigure", new XmlViewConverter(), new GenericDeserializer()).Load<MyXmlConfig>();
			
			Assert.AreEqual("attr field text", cfg.AttrField);
			Assert.AreEqual("elem field text", cfg.ElemField);
		}
	}
}

