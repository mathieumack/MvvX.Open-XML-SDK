﻿using DocumentFormat.OpenXml;
using MvvX.Plugins.OpenXMLSDK.Word.ReportEngine.BatchModels;
using MvvX.Plugins.OpenXMLSDK.Word.ReportEngine.Models;

namespace MvvX.Plugins.OpenXMLSDK.Platform.Word.ReportEngine
{
    public static class LabelExtension
    {
        public static OpenXmlElement Render(this Label label, OpenXmlElement parent, ContextModel context)
        {
            context.ReplaceItem(label);

            var run = new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(label.Text));
            var runProperty = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
            if (!string.IsNullOrWhiteSpace(label.FontName))
                runProperty.RunFonts = new DocumentFormat.OpenXml.Wordprocessing.RunFonts() { Ascii = label.FontName };
            if (!string.IsNullOrWhiteSpace(label.FontSize))
                runProperty.FontSize = new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = label.FontSize };
            if (!string.IsNullOrWhiteSpace(label.FontSize))
                runProperty.Color = new DocumentFormat.OpenXml.Wordprocessing.Color() { Val = label.FontColor };
            if (!string.IsNullOrWhiteSpace(label.Shading))
                runProperty.Shading = new DocumentFormat.OpenXml.Wordprocessing.Shading() { Fill = label.Shading };

            run.RunProperties = runProperty;
            parent.Append(run);
            return run;
        }
    }
}
