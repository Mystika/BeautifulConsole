using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Security;

namespace Beautiful
{
    public static class Console
    {
        static ColorMapper colorMapper = new ColorMapper();

        #region re-written console functions
        private static void WriteInColor<T>(Action<T> action, T value, Color color)
        {
            System.Console.ForegroundColor = colorMapper.GetMappedConsoleColor(color);
            action.Invoke(value);
            System.Console.ResetColor();
        }
        private static void WriteInColor<T,A>(Action<T,A> action, T value, A arg0, Color color)
        {
            System.Console.ForegroundColor = colorMapper.GetMappedConsoleColor(color);
            action.Invoke(value, arg0);
            System.Console.ResetColor();
        }
        private static void WriteInColor<T, A>(Action<T, A, A> action, T value, A arg0, A arg1, Color color)
        {
            System.Console.ForegroundColor = colorMapper.GetMappedConsoleColor(color);
            action.Invoke(value, arg0, arg1);
            System.Console.ResetColor();
        }

        public static Color BackgroundColor
        {
            get { return colorMapper.GetColor(System.Console.BackgroundColor); }
            set { colorMapper.SetColor(System.Console.BackgroundColor, value); }
        }
        public static Color ForegroundColor
        {
            get { return colorMapper.GetColor(System.Console.ForegroundColor); }
            set { colorMapper.SetColor(System.Console.ForegroundColor, value); }
        }

        public static void Write(long value, Color foregroundColor)
        {
            WriteInColor(System.Console.Write, value, foregroundColor);
        }
        public static void Write(string value, Color foregroundColor)
        {
            WriteInColor(System.Console.Write, value, foregroundColor);
        }
        public static void Write(ulong value, Color foregroundColor)
        {
            WriteInColor(System.Console.Write, value, foregroundColor);
        }
        public static void Write(uint value, Color foregroundColor)
        {
            WriteInColor(System.Console.Write, value, foregroundColor);
        }
        public static void Write(object value, Color foregroundColor)
        {
            WriteInColor(System.Console.Write, value, foregroundColor);
        }
        public static void Write(float value, Color foregroundColor)
        {
            WriteInColor(System.Console.Write, value, foregroundColor);
        }
        public static void Write(decimal value, Color foregroundColor)
        {
            WriteInColor(System.Console.Write, value, foregroundColor);
        }
        public static void Write(double value, Color foregroundColor)
        {
            WriteInColor(System.Console.Write, value, foregroundColor);
        }
        public static void Write(char[] buffer, Color foregroundColor)
        {
            WriteInColor(System.Console.Write, buffer, foregroundColor);
        }
        public static void Write(char value, Color foregroundColor)
        {
            WriteInColor(System.Console.Write, value, foregroundColor);
        }
        public static void Write(bool value, Color foregroundColor)
        {
            WriteInColor(System.Console.Write, value, foregroundColor);
        }
        public static void Write(int value, Color foregroundColor)
        {
            WriteInColor(System.Console.Write, value, foregroundColor);
        }
        public static void Write(string format, object arg0, Color foregroundColor)
        {
            WriteInColor(System.Console.Write, format, arg0, foregroundColor);
        }
        public static void Write(string format, Color foregroundColor, params object[] arg)
        {
            WriteInColor(System.Console.WriteLine, format, arg, foregroundColor);
        }
        public static void Write(string format, object arg0, object arg1, Color foregroundColor)
        {
            WriteInColor(System.Console.Write, format, new object[] { arg0, arg1 }, foregroundColor);
        }
        public static void Write(char[] buffer, int index, int count, Color foregroundColor)
        {
            WriteInColor(System.Console.Write, buffer, index, count, foregroundColor);
        }
        public static void Write(string format, object arg0, object arg1, object arg2, Color foregroundColor)
        {
            WriteInColor(System.Console.Write, format, new object[] { arg0, arg1, arg2 }, foregroundColor);
        }
        public static void Write(string format, object arg0, object arg1, object arg2, object arg3, Color foregroundColor)
        {
            WriteInColor(System.Console.Write, format, new object[] { arg0, arg1, arg2, arg3 }, foregroundColor);
        }
        public static void WriteLine(bool value, Color foregroundColor)
        {
            WriteInColor(System.Console.WriteLine, value, foregroundColor);
        }
        public static void WriteLine(float value, Color foregroundColor)
        {
            WriteInColor(System.Console.WriteLine, value, foregroundColor);
        }
        public static void WriteLine(int value, Color foregroundColor)
        {
            WriteInColor(System.Console.WriteLine, value, foregroundColor);
        }
        public static void WriteLine(uint value, Color foregroundColor)
        {
            WriteInColor(System.Console.WriteLine, value, foregroundColor);
        }
        public static void WriteLine(long value, Color foregroundColor)
        {
            WriteInColor(System.Console.WriteLine, value, foregroundColor);
        }
        public static void WriteLine(ulong value, Color foregroundColor)
        {
            WriteInColor(System.Console.WriteLine, value, foregroundColor);
        }
        public static void WriteLine(object value, Color foregroundColor)
        {
            WriteInColor(System.Console.WriteLine, value, foregroundColor);
        }
        public static void WriteLine(string value, Color foregroundColor)
        {
            WriteInColor(System.Console.WriteLine, value, foregroundColor);
        }
        public static void WriteLine(double value, Color foregroundColor)
        {
            WriteInColor(System.Console.WriteLine, value, foregroundColor);
        }
        public static void WriteLine(decimal value, Color foregroundColor)
        {
            WriteInColor(System.Console.WriteLine, value, foregroundColor);
        }
        public static void WriteLine(char[] buffer, Color foregroundColor)
        {
            WriteInColor(System.Console.WriteLine, buffer, foregroundColor);
        }
        public static void WriteLine(char value, Color foregroundColor)
        {
            WriteInColor(System.Console.WriteLine, value, foregroundColor);
        }
        public static void WriteLine(string format, Color foregroundColor, params object[] arg)
        {
            WriteInColor(System.Console.WriteLine,format, arg, foregroundColor);
        }
        public static void WriteLine(string format, object arg0, Color foregroundColor)
        {
            WriteInColor(System.Console.WriteLine, format, arg0, foregroundColor);
        }
        public static void WriteLine(string format, object arg0, object arg1, Color foregroundColor)
        {
            WriteInColor(System.Console.WriteLine, format, new object[] { arg0, arg1 }, foregroundColor);
        }
        public static void WriteLine(char[] buffer, int index, int count, Color foregroundColor)
        {
            WriteInColor(System.Console.WriteLine, buffer, index, count, foregroundColor);
        }
        public static void WriteLine(string format, object arg0, object arg1, object arg2, Color foregroundColor)
        {
            WriteInColor(System.Console.WriteLine, format, new object[] { arg0, arg1, arg2 }, foregroundColor);
        }
        public static void WriteLine(string format, object arg0, object arg1, object arg2, object arg3, Color foregroundColor)
        {
            WriteInColor(System.Console.WriteLine, format, new object[] { arg0, arg1, arg2, arg3 }, foregroundColor);
        }
        public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop, char sourceChar, Color sourceForeColor, Color sourceBackColor)
        {
            ConsoleColor foreColor = colorMapper.GetMappedConsoleColor(sourceForeColor);
            ConsoleColor backColor = colorMapper.GetMappedConsoleColor(sourceBackColor);
            System.Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, sourceChar, foreColor, backColor);
        }
        #endregion

        #region native console functions
        public static int BufferHeight
        {
            get { return System.Console.BufferHeight; }
            set { System.Console.BufferHeight = value; }
        }
        public static int BufferWidth
        {
            get { return System.Console.BufferWidth; }
            set { System.Console.BufferWidth = value; }
        }
        public static bool CapsLock{
            get { return System.Console.CapsLock; }
        }
        public static int CursorLeft
        {
            get { return System.Console.CursorLeft; }
            set { System.Console.CursorLeft = value; }
        }
        public static int CursorSize
        {
            get { return System.Console.CursorSize; }
            set { System.Console.CursorSize = value; }
        }
        public static int CursorTop
        {
            get { return System.Console.CursorTop; }
            set { System.Console.CursorTop = value; }
        }
        public static bool CursorVisible
        {
            get { return System.Console.CursorVisible; }
            set { System.Console.CursorVisible = value; }
        }
        public static TextWriter Error {
            get { return System.Console.Error;}
        }
        public static TextReader In {
            get { return System.Console.In; }
        }
        public static Encoding InputEncoding
        {
            get { return System.Console.InputEncoding; }
            set { System.Console.InputEncoding = value;  }
        }
        #if NET45
        public static bool IsErrorRedirected {
            get { return System.Console.IsErrorRedirected; }
        }
        public static bool IsInputRedirected {
            get { return System.Console.IsInputRedirected; }
        }
        public static bool IsOutputRedirected {
            get { return System.Console.IsOutputRedirected; }
        }
        #endif
        public static bool KeyAvailable {
            get { return System.Console.KeyAvailable; }
        }
        public static int LargestWindowHeight {
            get { return System.Console.LargestWindowHeight; }
        }
        public static int LargestWindowWidth {
            get { return System.Console.LargestWindowWidth; }
        }
        public static bool NumberLock {
            get { return System.Console.NumberLock; }
        }
        public static TextWriter Out {
            get { return System.Console.Out; }
        }
        public static Encoding OutputEncoding
        {
            get { return System.Console.OutputEncoding; }
            set { System.Console.OutputEncoding = value; }
        }
        public static string Title
        {
            get { return System.Console.Title; }
            set { System.Console.Title = value; }
        }
        public static bool TreatControlCAsInput
        {
            get { return System.Console.TreatControlCAsInput; }
            set { System.Console.TreatControlCAsInput = value; }
        }
        public static int WindowHeight
        {
            get { return System.Console.WindowHeight; }
            set { System.Console.WindowHeight = value; }
        }
        public static int WindowLeft
        {
            get { return System.Console.WindowLeft; }
            set { System.Console.WindowLeft = value; }
        }
        public static int WindowTop
        {
            get { return System.Console.WindowTop; }
            set { System.Console.WindowTop = value; }
        }
        public static int WindowWidth
        {
            get { return System.Console.WindowWidth; }
            set { System.Console.WindowWidth = value; }
        }

        public static event ConsoleCancelEventHandler CancelKeyPress = delegate {};

        
        public static void Beep()
        {
            System.Console.Beep();
        }
        [SecuritySafeCritical]
        public static void Beep(int frequency, int duration)
        {
            System.Console.Beep(frequency,duration);
        }
        [SecuritySafeCritical]
        public static void Clear()
        {
            System.Console.Clear();
        }
        public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop)
        {
            System.Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop);
        }
        #if !NETSTANDARD1_3
        public static Stream OpenStandardError()
        {
            return System.Console.OpenStandardError();
        }
        public static Stream OpenStandardError(int bufferSize)
        {
            return System.Console.OpenStandardError(bufferSize);
        }
        public static Stream OpenStandardInput()
        {
            return System.Console.OpenStandardInput();
        }
        public static Stream OpenStandardInput(int bufferSize)
        {
            return System.Console.OpenStandardInput(bufferSize);
        }
        public static Stream OpenStandardOutput()
        {
            return System.Console.OpenStandardOutput();
        }
        public static Stream OpenStandardOutput(int bufferSize)
        {
            return System.Console.OpenStandardOutput(bufferSize);
        }
        #endif
        public static int Read()
        {
            return System.Console.Read();
        }
        [SecuritySafeCritical]
        public static ConsoleKeyInfo ReadKey()
        {
            return System.Console.ReadKey();
        }
        public static ConsoleKeyInfo ReadKey(bool intercept)
        {
            return System.Console.ReadKey(intercept);
        }
        public static string ReadLine()
        {
            return System.Console.ReadLine();
        }
        [SecuritySafeCritical]
        public static void ResetColor()
        {
            System.Console.ResetColor();
        }
        [SecuritySafeCritical]
        public static void SetBufferSize(int width, int height)
        {
            System.Console.SetBufferSize(width, height);
        }
        [SecuritySafeCritical]
        public static void SetCursorPosition(int left, int top)
        {
            System.Console.SetCursorPosition(left, top);
        }
        [SecuritySafeCritical]
        public static void SetError(TextWriter newError)
        {
            System.Console.SetError(newError);
        }
        [SecuritySafeCritical]
        public static void SetIn(TextReader newIn)
        {
            System.Console.SetIn(newIn);
        }
        [SecuritySafeCritical]
        public static void SetOut(TextWriter newOut)
        {
            System.Console.SetOut(newOut);
        }
        [SecuritySafeCritical]
        public static void SetWindowPosition(int left, int top)
        {
            System.Console.SetWindowPosition(left, top);
        }
        [SecuritySafeCritical]
        public static void SetWindowSize(int width, int height)
        {
            System.Console.SetWindowSize(width, height);
        }

        public static void Write(long value)
        {
            System.Console.Write(value);
        }
        public static void Write(string value)
        {
            System.Console.Write(value);
        }
        public static void Write(ulong value)
        {
            System.Console.Write(value);
        }
        public static void Write(uint value)
        {
            System.Console.Write(value);
        }
        public static void Write(object value)
        {
            System.Console.Write(value);
        }
        public static void Write(float value)
        {
            System.Console.Write(value);
        }
        public static void Write(decimal value)
        {
            System.Console.Write(value);
        }
        public static void Write(double value)
        {
            System.Console.Write(value);
        }
        public static void Write(char[] buffer)
        {
            System.Console.Write(buffer);
        }
        public static void Write(char value)
        {
            System.Console.Write(value);
        }
        public static void Write(bool value)
        {
            System.Console.Write(value);
        }
        public static void Write(int value)
        {
            System.Console.Write(value);
        }
        public static void Write(string format, object arg0)
        {
            System.Console.Write(format, arg0);
        }
        public static void Write(string format, params object[] arg)
        {
            System.Console.Write(format, arg);
        }
        public static void Write(string format, object arg0, object arg1)
        {
            System.Console.Write(format, arg0, arg1);
        }
        public static void Write(char[] buffer, int index, int count)
        {
            System.Console.Write(buffer, index, count);
        }
        public static void Write(string format, object arg0, object arg1, object arg2)
        {
            System.Console.Write(format, arg0, arg1, arg2);
        }
        public static void Write(string format, object arg0, object arg1, object arg2, object arg3)
        {
            System.Console.Write(format, arg0, arg1, arg2, arg3);
        }
        public static void WriteLine()
        {
            System.Console.WriteLine();
        }
        public static void WriteLine(bool value)
        {
            System.Console.WriteLine(value);
        }
        public static void WriteLine(float value)
        {
            System.Console.WriteLine(value);
        }
        public static void WriteLine(int value)
        {
            System.Console.WriteLine(value);
        }
        public static void WriteLine(uint value)
        {
            System.Console.WriteLine(value);
        }
        public static void WriteLine(long value)
        {
            System.Console.WriteLine(value);
        }
        public static void WriteLine(ulong value)
        {
            System.Console.WriteLine(value);
        }
        public static void WriteLine(object value)
        {
            System.Console.WriteLine(value);
        }
        public static void WriteLine(string value)
        {
            System.Console.WriteLine(value);
        }
        public static void WriteLine(double value)
        {
            System.Console.WriteLine(value);
        }
        public static void WriteLine(decimal value)
        {
            System.Console.WriteLine(value);
        }
        public static void WriteLine(char[] buffer)
        {
            System.Console.WriteLine(buffer);
        }
        public static void WriteLine(char value)
        {
            System.Console.WriteLine(value);
        }
        public static void WriteLine(string format, params object[] arg)
        {
            System.Console.WriteLine(format, arg);
        }
        public static void WriteLine(string format, object arg0)
        {
            System.Console.WriteLine(format, arg0);
        }
        public static void WriteLine(string format, object arg0, object arg1)
        {
            System.Console.WriteLine(format, arg0, arg1);
        }
        public static void WriteLine(char[] buffer, int index, int count)
        {
            System.Console.WriteLine(buffer, index, count);
        }
        public static void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            System.Console.WriteLine(format, arg0, arg1, arg2);
        }
        public static void WriteLine(string format, object arg0, object arg1, object arg2, object arg3)
        {
            System.Console.WriteLine(format, arg0, arg1, arg2, arg3);
        }
        #endregion
    }
}
