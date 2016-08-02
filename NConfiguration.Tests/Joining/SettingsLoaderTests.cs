﻿using NConfiguration.Joining;
using NConfiguration.Xml;
using NUnit.Framework;
using System.Linq;

namespace NConfiguration.Tests.Joining
{
	[TestFixture]
	public class SettingsLoaderTests
	{
		[Test]
		public void IncludeInMiddle()
		{
			var loader = new SettingsLoader();
			loader.XmlFileBySection();

			var settings = loader
				.LoadSettings(XmlFileSettings.Create("Joining/AppDirectory/IncludeInMiddle.config".ResolveTestPath()))
				.Joined.ToAppSettings();

			Assert.That(settings.LoadSections<AdditionalConfig>().Select(_ => _.F), Is.EquivalentTo(new[] { "InMainPre", "InAdditional", "InMainPost" }));
		}

		[Test]
		public void RelativeInclude()
		{
			var loader = new SettingsLoader();
			loader.XmlFileBySection();

			var settings = loader
				.LoadSettings(XmlFileSettings.Create("Joining/AppDirectory/Deeper/RelativeInclude.config".ResolveTestPath()))
				.Joined.ToAppSettings();

			Assert.That(settings.LoadSections<AdditionalConfig>().Select(_ => _.F), Is.EquivalentTo(
				new[] { "BeginMain", "BeginUpper", "InAdditional", "EndUpper", "EndMain" }));
		}

		[Test]
		public void BaseInclude()
		{
			var loader = new SettingsLoader();
			loader.XmlFileBySection();

			var settings = loader
				.LoadSettings(XmlFileSettings.Create("Joining/AppDirectory/Deeper/BaseInclude.config".ResolveTestPath()))
				.Joined.ToAppSettings();

			Assert.That(settings.LoadSections<AdditionalConfig>().Select(_ => _.F), Is.EquivalentTo(
				new[] { "BeginMain", "BeginUpper", "InDeeperAdditional", "InAdditional", "EndUpper", "EndMain" }));
		}


	}
}
