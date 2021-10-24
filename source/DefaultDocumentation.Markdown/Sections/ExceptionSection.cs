﻿using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ExceptionSection : ISectionWriter
    {
        public string Name => "exception";

        public void Write(IWriter writer)
        {
            bool titleWritten = false;
            foreach (XElement exception in writer.GetCurrentItem().Documentation?.Elements(Name) ?? Enumerable.Empty<XElement>())
            {
                if (!titleWritten)
                {
                    titleWritten = true;
                    writer
                        .EnsureLineStart()
                        .AppendLine()
                        .Append("#### Exceptions");
                }

                string cref = exception.GetCRefAttribute();

                writer
                    .AppendLine()
                    .AppendLine()
                    .AppendLink(cref)
                    .AppendLine("  ")
                    .AppendAsMarkdown(exception);
            }
        }
    }
}
