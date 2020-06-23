using System.Drawing;
using Bodoconsult.Core.Typography.Charts;

namespace Bodoconsult.Core.Typography
{
    /// <summary>
    /// Provides a compact typograph based on sans serif fonts at default. Use non-default constructor to change fonts
    /// </summary>
    public class CompactTypographyPageHeader : TypographyBase
    {
        /// <summary>
        /// Default ctor. Sets font names to Calibri
        /// </summary>
        public CompactTypographyPageHeader()
        {
            BaseConstructor("Calibri", "Calibri", "Calibri");
        }

        /// <summary>
        /// Ctor to set font names
        /// </summary>
        /// <param name="primaryFontname">Font name for text</param>
        /// <param name="secondaryFontName">Font name for headings</param>
        /// <param name="thirdFontName">Font name for titles</param>
        public CompactTypographyPageHeader(string primaryFontname, string secondaryFontName, string thirdFontName)
        {
            BaseConstructor(primaryFontname, secondaryFontName, thirdFontName);
        }

        private void BaseConstructor(string primaryFontname, string secondaryFontName, string thirdFontName)
        {
            // Default page DIN A4 
            PageHeight = 29.4;
            PageWidth = 21.0;

            FontName = primaryFontname;
            FontSize = 10;
            SmallFontSize = FontSize - 2;
            ExtraSmallFontSize = SmallFontSize - 2;

            HeadingFontName = secondaryFontName;
            HeadingFontSize5 = FontSize;
            HeadingFontSize4 = HeadingFontSize5;
            HeadingFontSize3 = HeadingFontSize4;
            HeadingFontSize2 = HeadingFontSize3;
            HeadingFontSize1 = HeadingFontSize2 + 2;

            LineHeight = 0.5;
            ColumnDividerWidth = 0.5;
            ColumnWidth = 2.0;
            ColumnCount = 6;
            DotsPerInch = 300;
            LogoWidth = 2 * ColumnWidth + ColumnDividerWidth;

            TitleFontName = thirdFontName;
            SubTitleFontName = thirdFontName;

            TitleFontSize = HeadingFontSize1 + 4;
            SubTitleFontSize = HeadingFontSize1 + 2;


            MarginLeftFactor = 1.5;
            MarginRightFactor = 1.5;
            MarginTopFactor = 2;
            MarginBottomFactor = 1.5;

            SetMargins();

            PageFooterHeight = 0.5;
            PageHeaderHeight = 1;
            PageHeaderMargin = 1;
            PageFooterMargin = ColumnDividerWidth;


            ChartStyle = new ChartStyle
            {
                FontName = FontName,
                TitleFontName = HeadingFontName,
                FontSize = (float)FontSize,
                Width = GetPixelWidth(6),
                Height = GetPixelHeight(6),
                PaperColor = Color.White
            };

            TableBodyBackground = Color.White;
            TableHeaderBackground = Color.White;
            TableBodyUnborderedBackground = Color.Transparent;
            TableHeaderUnborderedBackground = Color.Transparent;
            TableCornerRadius = 0.3;
            TableBorderWidth = 0.05;
            TableBorderColor = Color.FromArgb(178, 204, 255);
        }

    }
}