using System;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bodoconsult.Core.Typography.Test
{
    [TestFixture]
    public class UnitTestTypographyBase
    {

        private const double Tolerance = 0.0001;

        private readonly string ExportFolderName;

        public UnitTestTypographyBase()
        {
            var directoryInfo = new DirectoryInfo(Assembly.GetExecutingAssembly().Location).Parent;
            var dir = directoryInfo?.Parent?.Parent?.Parent;

            if (dir != null) ExportFolderName = Path.Combine(dir.FullName, "SampleData");
        }


        [Test]
        public void TestSetLayout()
        {

            var t = new TypographyBase();

            t.SetMargins();

            Assert.IsTrue(t.TypeAreaWidth - 175 < Tolerance);
            Assert.IsTrue(Math.Abs(t.MarginUnit - 0.875) < Tolerance);
            Assert.IsTrue(Math.Abs(t.MarginLeft - 1.75) < Tolerance);
            Assert.IsTrue(Math.Abs(t.MarginRight - 1.75) < Tolerance);
            Assert.IsTrue(Math.Abs(t.MarginTop - 0.875) < Tolerance);
            Assert.IsTrue(Math.Abs(t.MarginBottom - 1.75) < Tolerance);


            //var erg = t.GetPixelHeight(4);

            Assert.IsTrue(Math.Abs(t.GetWidth(4) - 11.5) < Tolerance);
            Assert.IsTrue(Math.Abs(t.GetHeight(4) - 7.11) < Tolerance);

            Assert.IsTrue(Math.Abs(t.GetPixelWidth(4) - (int)(11.5 * TypographicConstants.InchPerCentimeter * 96)) < Tolerance);
            Assert.IsTrue(Math.Abs(t.GetPixelHeight(4) - (int)(7.11 * TypographicConstants.InchPerCentimeter * 96)) < Tolerance);
        }

        [Test]
        public void TestExportImport_Elegant()
        {
            var t = new ElegantTypographyPageHeader("Cambria", "Calibri", "Calibri")
            {
                MarginLeftFactor = 1,
                MarginRightFactor = 1,
                MarginTopFactor = 1,
                MarginBottomFactor = 1
            };


            t.SetMargins();

            var fileName = Path.Combine(ExportFolderName, "ElegantTypography.json");

            if (File.Exists(fileName)) File.Delete(fileName);

            ExportToJson(t, fileName);

            var typo2 = ImportFromJson<ElegantTypographyPageHeader>(fileName);
            typo2.SetMargins();


            Assert.IsTrue(File.Exists(fileName));
            Assert.IsFalse(typo2 == null);
            Assert.IsTrue(t.MarginUnit - typo2.MarginUnit < Tolerance);

        }

        [Test]
        public void TestExportImport_Elegant_Bodoprivate()
        {
            var t = new ElegantTypographyPageHeader("Cambria", "Cambria", "Cambria")
                        {
                            LogoPath = @"C:\bodoconsult\Logos\logoStatera.jpg"
                        };


            t.SetMargins();

            var fileName = Path.Combine(ExportFolderName, "ElegantTypographyBodoPrivate.json");

            if (File.Exists(fileName)) File.Delete(fileName);

            ExportToJson(t, fileName);

            var typo2 = ImportFromJson<ElegantTypographyPageHeader>(fileName);
            typo2.SetMargins();


            Assert.IsTrue(File.Exists(fileName));
            Assert.IsFalse(typo2 == null);
            Assert.IsTrue(t.MarginUnit - typo2.MarginUnit < Tolerance);

        }


        [Test]
        public void TestExportImport_Compact()
        {
            var t = new CompactTypographyPageHeader("Cambria", "Calibri", "Calibri")
            {
                MarginLeftFactor = 1,
                MarginRightFactor = 1,
                MarginTopFactor = 1,
                MarginBottomFactor = 1
            };


            t.SetMargins();

            var fileName = Path.Combine(ExportFolderName, "CompactTypography.json");

            if (File.Exists(fileName)) File.Delete(fileName);

            ExportToJson(t, fileName);

            var typo2 = ImportFromJson<CompactTypographyPageHeader>(fileName);
            typo2.SetMargins();


            Assert.IsTrue(File.Exists(fileName));
            Assert.IsFalse(typo2 == null);
            Assert.IsTrue(t.MarginUnit - typo2.MarginUnit < Tolerance);

        }

        private static void ExportToJson(ITypography typography, string fileName)
        {

            var json = JsonConvert.SerializeObject(
                            typography,
                            Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                TypeNameHandling = TypeNameHandling.All
                            });

            //json = Encrypt(json);

            var sw11 = new StreamWriter(fileName, false, Encoding.UTF8);
            sw11.WriteLine(json);
            sw11.Close();
        }


        private static T ImportFromJson<T>(string fileName) where T : ITypography
        {

            var json = File.ReadAllText(fileName, Encoding.UTF8);

            //json = Decrypt(json);

            var erg = (T)JsonConvert.DeserializeObject(json, typeof(T),
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    });

            return erg;
        }

    }
}
