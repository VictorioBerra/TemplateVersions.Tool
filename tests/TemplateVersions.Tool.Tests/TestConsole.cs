using McMaster.Extensions.CommandLineUtils;
using System;
using System.IO;

namespace TemplateVersions.Tool.Tests
{
    public class TestConsole : IConsole
    {
        public TextWriter allTextWriter { get; }

        public TestConsole(TextWriter allTextWriter)
        {
            this.allTextWriter = allTextWriter;
        }

        public TextWriter Out => allTextWriter;

        public TextWriter Error => allTextWriter;

        public TextReader In => throw new NotImplementedException();

        public bool IsInputRedirected => throw new NotImplementedException();

        public bool IsOutputRedirected => throw new NotImplementedException();

        public bool IsErrorRedirected => throw new NotImplementedException();

        public ConsoleColor ForegroundColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ConsoleColor BackgroundColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event ConsoleCancelEventHandler CancelKeyPress;

        public void ResetColor()
        {
            throw new NotImplementedException();
        }
    }
}
