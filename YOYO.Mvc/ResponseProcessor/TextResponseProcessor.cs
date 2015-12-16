﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;

namespace YOYO.Mvc.ResponseProcessor
{
    internal class TextResponseProcessor : ResponseProcessor, IResponseProcessor
    {
        internal TextResponseProcessor(IOwinContext context) : base(context) { }

        public override bool CanProcess()
        {
            string contentType = _context.Request.Headers.ContentType;
            if (string.IsNullOrEmpty(contentType))
            {
                return true;
            }

            var contentMimeType = contentType.Split(';')[0];

            return contentMimeType.Equals("text/plain", StringComparison.OrdinalIgnoreCase);
        }

        public override string GetRawDataString(object model)
        {
            return model != null ? model.ToString() : string.Empty;
        }
    }
}
