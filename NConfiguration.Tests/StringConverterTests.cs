using NUnit.Framework;
using NConfiguration.Serialization;

namespace NConfiguration
{
	[TestFixture]
	public class StringConverterTests
	{
		public enum ByteEn : byte
		{
			One = 1,
			Two = 2,
			Max = 255
		}

		[TestCase("One", ByteEn.One)]
		[TestCase("Two", ByteEn.Two)]
		[TestCase("Max", ByteEn.Max)]
		[TestCase(null, null)]
		[TestCase("", null)]
		public void NEnumByte(string text, ByteEn? expected)
		{
			Assert.AreEqual(expected, DefaultDeserializer.Instance.Deserialize<ByteEn?>(new ViewPlainField(text)));
		}
	}
}

