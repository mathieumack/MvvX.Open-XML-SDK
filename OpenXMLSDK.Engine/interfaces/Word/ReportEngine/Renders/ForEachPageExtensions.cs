﻿using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using OpenXMLSDK.Engine.Word.ReportEngine.BatchModels;
using OpenXMLSDK.Engine.Word.ReportEngine.Models;
using System;

namespace OpenXMLSDK.Engine.Word.ReportEngine.Renders
{
    public static class ForEachPageExtensions
    {
        public static void Render(this ForEachPage forEach, Document document, OpenXmlElement wdDoc, ContextModel context, MainDocumentPart mainDocumentPart, IFormatProvider formatProvider)
        {
            context.ReplaceItem(forEach, formatProvider);

            if (!string.IsNullOrEmpty(forEach.DataSourceKey))
            {
                if (context.ExistItem<DataSourceModel>(forEach.DataSourceKey))
                {
                    var datasource = context.GetItem<DataSourceModel>(forEach.DataSourceKey);

                    if (datasource != null && datasource.Items.Count > 0)
                    {
                        int i = 0;

                        foreach (var item in datasource.Items)
                        {
                            var newPage = forEach.Clone();                          
                            // doc inherit margin from page
                            if (document.Margin == null && newPage.Margin != null)
                                document.Margin = newPage.Margin;
                            // newPage inherit margin from doc
                            else if (document.Margin != null && newPage.Margin == null)
                                newPage.Margin = document.Margin;

                            if (!string.IsNullOrWhiteSpace(forEach.AutoContextAddItemsPrefix))
                            {
                                // We add automatic keys :
                                // Is first item
                                item.AddItem("#" + forEach.AutoContextAddItemsPrefix + "_ForEachPage_IsFirstItem#", new BooleanModel(i == 0));
                                // Is last item
                                item.AddItem("#" + forEach.AutoContextAddItemsPrefix + "_ForEachPage_IsLastItem#", new BooleanModel(i == datasource.Items.Count - 1));
                                // Index of the element (Based on 0, and based on 1)
                                item.AddItem("#" + forEach.AutoContextAddItemsPrefix + "_ForEachPage_IndexBaseZero#", new StringModel(i.ToString()));
                                item.AddItem("#" + forEach.AutoContextAddItemsPrefix + "_ForEachPage_IndexBaseOne#", new StringModel((i + 1).ToString()));
                                item.AddItem("#" + forEach.AutoContextAddItemsPrefix + "_ForEachPage_IsOdd#", new BooleanModel(i % 2 == 1));
                                item.AddItem("#" + forEach.AutoContextAddItemsPrefix + "_ForEachPage_IsEven#", new BooleanModel(i % 2 == 0));
                            }

                            newPage.Clone().Render(document, wdDoc, item, mainDocumentPart, formatProvider);

                            i++;
                        }
                    }
                }
            }
        }
    }
}