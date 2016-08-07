﻿using DocumentFormat.OpenXml.Wordprocessing;
using MvvX.Open_XML_SDK.Core.Word;

namespace MvvX.Open_XML_SDK.Shared.Word
{
    public abstract class PlatformDecimalNumberType : PlatformOpenXmlElement, IDecimalNumberType
    {
        private readonly DecimalNumberType openXmlElement;

        public PlatformDecimalNumberType(DecimalNumberType openXmlElement)
            : base(openXmlElement)
        {
            this.openXmlElement = openXmlElement;
        }

        public int Val
        {
            get
            {
                if (openXmlElement.Val.HasValue)
                    return openXmlElement.Val.Value;
                else
                    return 0;
            }
            set
            {
                openXmlElement.Val = value;
            }
        }
    }
}