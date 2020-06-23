using System.Drawing;
using Bodoconsult.Core.Typography.Charts;

namespace Bodoconsult.Core.Typography
{
    /// <summary>
    /// Interface for typographic data
    /// </summary>
    public interface ITypography
    {
        /// <summary>
        /// Page width in cm (Papierbreite in   )
        /// </summary>
        double PageWidth { get; set; }

        /// <summary>
        /// Page height in cm (Papierh�he in cm)
        /// </summary>
        double PageHeight { get; set; }

        /// <summary>
        /// Default font name
        /// </summary>
        string FontName { get; set; }

        /// <summary>
        /// Default font size in pt
        /// </summary>
        double FontSize { get; set; }

        /// <summary>
        /// Small font size in pt
        /// </summary>
        double SmallFontSize { get; set; }

        /// <summary>
        /// Extra small font size in pt
        /// </summary>
        double ExtraSmallFontSize { get; set; }

        /// <summary>
        /// Title font name
        /// </summary>
        string TitleFontName { get; set; }

        /// <summary>
        /// Title font size in pt
        /// </summary>
        double TitleFontSize { get; set; }


        /// <summary>
        /// Subtitle font name
        /// </summary>
        string SubTitleFontName { get; set; }

        /// <summary>
        /// Subtitle font size in pt
        /// </summary>
        double SubTitleFontSize { get; set; }


        /// <summary>
        /// Font name used for headings
        /// </summary>
        string HeadingFontName { get; set; }

        /// <summary>
        /// Font size used for headings of level 1 in pt
        /// </summary>
        double HeadingFontSize1 { get; set; }

        /// <summary>
        /// Font size used for headings of level 2 in pt
        /// </summary>
        double HeadingFontSize2 { get; set; }

        /// <summary>
        /// Font size used for headings of level 3 in pt
        /// </summary>
        double HeadingFontSize3 { get; set; }

        /// <summary>
        /// Font size used for headings of level 4 in pt
        /// </summary>
        double HeadingFontSize4 { get; set; }

        /// <summary>
        /// Font size used for headings of level 5 in pt
        /// </summary>
        double HeadingFontSize5 { get; set; }

        /// <summary>
        /// Line height in cm (Zeilenabstand ZAB in cm)
        /// </summary>
        double LineHeight { get; set; }

        /// <summary>
        /// Width of the column divider in cm (Spaltenabstand in cm)
        /// </summary>
        double ColumnDividerWidth { get; set; }

        /// <summary>
        /// Column width in cm
        /// </summary>
        double ColumnWidth { get; set; }

        /// <summary>
        /// Sets the factor for the calculation of the left margin. See <see cref="SetMargins"/> for details
        /// </summary>
        double MarginLeftFactor { get; set; }

        /// <summary>
        /// Sets the factor for the calculation of the right margin. See <see cref="SetMargins"/> for details
        /// </summary>
        double MarginRightFactor { get; set; }

        /// <summary>
        /// Sets the factor for the calculation of the top margin. See <see cref="SetMargins"/> for details
        /// </summary>
        double MarginTopFactor { get; set; }


        /// <summary>
        /// Sets the factor for the calculation of the bottom margin. See <see cref="SetMargins"/> for details
        /// </summary>
        double MarginBottomFactor { get; set; }


        /// <summary>
        /// Number of columns to use for the layout in the type area
        /// </summary>
        int ColumnCount { get; set; }

        /// <summary>
        /// Unit used for margins in cm (Teil in cm)
        /// </summary>
        double MarginUnit { get; }

        /// <summary>
        /// Left margin in cm
        /// </summary>
        double MarginLeft { get; }

        /// <summary>
        /// Right margin in cm
        /// </summary>
        double MarginRight { get; }

        /// <summary>
        /// Top margin in cm
        /// </summary>
        double MarginTop { get; }

        /// <summary>
        /// Bottom margin in cm
        /// </summary>
        double MarginBottom { get; }

        /// <summary>
        /// Height of the page header in cm
        /// </summary>
        double PageHeaderHeight { get; set; }

        /// <summary>
        /// Margin between page hedaer and type area in cm
        /// </summary>
        double PageHeaderMargin { get; set; }

        /// <summary>
        /// Height of the page header in cm
        /// </summary>
        double PageFooterHeight { get; set; }

        /// <summary>
        /// Margin between page hedaer and type area in cm
        /// </summary>
        double PageFooterMargin { get; set; }

        /// <summary>
        /// Dots per inch (for converting to pixels). Default: 96dpi
        /// </summary>
        double DotsPerInch { get; set; }

        /// <summary>
        /// Width of the type area in cm (Breite des Satzspiegels in cm)
        /// </summary>
        double TypeAreaWidth { get; }

        /// <summary>
        /// Height of the type area in cm (H�he des Satzspiegels in cm)
        /// </summary>
        double TypeAreaHeight { get; set; }


        /// <summary>
        /// Path to logo to print in the page header
        /// </summary>
        string LogoPath { get; set; }



        /// <summary>
        /// Width of the logo in the page header
        /// </summary>
        double LogoWidth { get; set; }



        /// <summary>
        /// Styling for charts in the document
        /// </summary>
        ChartStyle ChartStyle { get; set; }

        /// <summary>
        /// Copyright to print in charts and other items
        /// </summary>
        string Copyright { get; set; }


        /// <summary>
        /// Color for table header background
        /// </summary>
        Color TableHeaderBackground { get; set; }


        /// <summary>
        /// Color for table body background
        /// </summary>
        Color TableBodyBackground { get; set; }


        /// <summary>
        /// Color for table header background
        /// </summary>
        Color TableHeaderUnborderedBackground { get; set; }


        /// <summary>
        /// Color for table body background
        /// </summary>
        Color TableBodyUnborderedBackground { get; set; }

        /// <summary>
        /// Corner radius of a table in cm
        /// </summary>
        double TableCornerRadius { get; set; }

        /// <summary>
        /// Border color of the table
        /// </summary>
        Color TableBorderColor { get; set; }


        /// <summary>
        /// Border width of a table in cm
        /// </summary>
        double TableBorderWidth { get; set; }


        /// <summary>
        /// Calculate margins and store it. Margins are calculate as follows:
        /// 
        /// <see cref="MarginUnit"/> = <see cref="PageWidth"/> - <see cref="TypeAreaWidth"/> / (<see cref="MarginLeftFactor"/> + <see cref="MarginRightFactor"/>)
        /// 
        /// <see cref="MarginLeft"/> = <see cref="MarginLeftFactor"/> * <see cref="MarginUnit"/>
        /// <see cref="MarginRight"/> = <see cref="MarginRightFactor"/> * <see cref="MarginUnit"/>
        /// <see cref="MarginTop"/> = <see cref="MarginTopFactor"/> * <see cref="MarginUnit"/>
        /// <see cref="MarginBottom"/> = <see cref="MarginBottomFactor"/>* <see cref="MarginUnit"/>
        /// 
        /// </summary>
        void SetMargins();

        /// <summary>
        /// Get the width of an landscape element which should a certain number of layout columns in cm
        /// </summary>
        /// <param name="numberOfColumnsUsed"></param>
        /// <returns></returns>
        double GetWidth(int numberOfColumnsUsed);

        /// <summary>
        /// Get the height of an element using the Golden Schnitt ratio in cm
        /// </summary>
        /// <param name="numberOfColumnsUsed"></param>
        /// <param name="landscape"></param>
        /// <returns></returns>
        double GetHeight(int numberOfColumnsUsed, bool landscape = true);

        /// <summary>
        /// Get the width of an landscape element which should a certain number of layout columns in pixels
        /// </summary>
        /// <param name="numberOfColumnsUsed"></param>
        /// <returns></returns>
        int GetPixelWidth(int numberOfColumnsUsed);

        /// <summary>
        /// Get the height of an element using the Golden Schnitt ratio in pixels
        /// </summary>
        /// <param name="numberOfColumnsUsed"></param>
        /// <param name="landscape"></param>
        /// <returns></returns>
        int GetPixelHeight(int numberOfColumnsUsed, bool landscape = true);
    }
}