﻿using System;
using System.Collections.Generic;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using MvvX.Plugins.OpenXMLSDK.Word.ReportEngine.Models.Attributes;

namespace MvvX.Plugins.OpenXMLSDK.Platform.Word.ReportEngine
{
    public static class BorderExtensions
    {
        /// <summary>
        /// Render a border for a table
        /// </summary>
        /// <param name="border"></param>
        /// <returns></returns>
        public static TableBorders Render(this BorderModel border)
        {
            TableBorders borders = new TableBorders();

            FillBorders(border, borders);

            return borders;
        }

        /// <summary>
        /// Render a border for a table cell
        /// </summary>
        /// <param name="border"></param>
        /// <returns></returns>
        public static TableCellBorders RenderCellBorder(this BorderModel border)
        {
            TableCellBorders borders = new TableCellBorders();

            FillBorders(border, borders);

            return borders;
        }

        /// <summary>
        /// Fill TableBorders or TableCellBorders element with borders.
        /// </summary>
        /// <param name="border"></param>
        /// <param name="borders"></param>
        private static void FillBorders(BorderModel border, OpenXmlCompositeElement borders)
        {
            if (border.BorderPositions.HasFlag(BorderPositions.LEFT))
            {
                LeftBorder leftBorder = new LeftBorder();
                leftBorder.Color = border.BorderColor;
                leftBorder.Val = BorderValues.Thick;
                leftBorder.Size = border.UseVariableBorders ? border.BorderWidthLeft : border.BorderWidth;
                borders.AppendChild(leftBorder);
            }

            if (border.BorderPositions.HasFlag(BorderPositions.TOP))
            {
                TopBorder topBorder = new TopBorder();
                topBorder.Color = border.BorderColor;
                topBorder.Val = BorderValues.Thick;
                topBorder.Size = border.UseVariableBorders ? border.BorderWidthTop : border.BorderWidth;
                borders.AppendChild(topBorder);
            }

            if (border.BorderPositions.HasFlag(BorderPositions.RIGHT))
            {
                RightBorder rightBorder = new RightBorder();
                rightBorder.Color = border.BorderColor;
                rightBorder.Val = BorderValues.Thick;
                rightBorder.Size = border.UseVariableBorders ? border.BorderWidthRight : border.BorderWidth;
                borders.AppendChild(rightBorder);
            }

            if (border.BorderPositions.HasFlag(BorderPositions.BOTTOM))
            {
                BottomBorder bottomBorder = new BottomBorder();
                bottomBorder.Color = border.BorderColor;
                bottomBorder.Val = BorderValues.Thick;
                bottomBorder.Size = border.UseVariableBorders ? border.BorderWidthBottom : border.BorderWidth;
                borders.AppendChild(bottomBorder);
            }

            if (border.BorderPositions.HasFlag(BorderPositions.INSIDEHORIZONTAL))
            {
                InsideHorizontalBorder insideHorizontalBorder = new InsideHorizontalBorder();
                insideHorizontalBorder.Color = border.BorderColor;
                insideHorizontalBorder.Val = BorderValues.Thick;
                insideHorizontalBorder.Size = border.UseVariableBorders ? border.BorderWidthInsideHorizontal : border.BorderWidth;
                borders.AppendChild(insideHorizontalBorder);
            }

            if (border.BorderPositions.HasFlag(BorderPositions.INSIDEVERTICAL))
            {
                InsideVerticalBorder insideVerticalBorder = new InsideVerticalBorder();
                insideVerticalBorder.Color = border.BorderColor;
                insideVerticalBorder.Val = BorderValues.Thick;
                insideVerticalBorder.Size = border.UseVariableBorders ? border.BorderWidthInsideVertical : border.BorderWidth;
                borders.AppendChild(insideVerticalBorder);
            }
        }
    }
}
