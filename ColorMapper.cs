using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Beautiful
{
    public sealed class ColorMapper
    {
        #region win32 api
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetConsoleScreenBufferInfoEx(IntPtr hConsoleOutput, ref CONSOLE_SCREEN_BUFFER_INFO_EX csbe);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleScreenBufferInfoEx(IntPtr hConsoleOutput, ref CONSOLE_SCREEN_BUFFER_INFO_EX csbe);

        [StructLayout(LayoutKind.Sequential)]
        internal struct COORD
        {
            internal short X;
            internal short Y;
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct SMALL_RECT
        {
            internal short Left;
            internal short Top;
            internal short Right;
            internal short Bottom;
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct COLORREF
        {
            internal uint ColorDWORD;

            internal COLORREF(Color color)
            {
                ColorDWORD = color.R + (((uint)color.G) << 8) + (((uint)color.B) << 16);
            }

            internal COLORREF(uint r, uint g, uint b)
            {
                ColorDWORD = r + (g << 8) + (b << 16);
            }

            internal Color GetColor()
            {
                return Color.FromArgb((int)(0x000000FFU & ColorDWORD),
                   (int)(0x0000FF00U & ColorDWORD) >> 8, (int)(0x00FF0000U & ColorDWORD) >> 16);
            }

            internal void SetColor(Color color)
            {
                ColorDWORD = color.R + (((uint)color.G) << 8) + (((uint)color.B) << 16);
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct CONSOLE_SCREEN_BUFFER_INFO_EX
        {
            internal int cbSize;
            internal COORD dwSize;
            internal COORD dwCursorPosition;
            internal ushort wAttributes;
            internal SMALL_RECT srWindow;
            internal COORD dwMaximumWindowSize;
            internal ushort wPopupAttributes;
            internal bool bFullscreenSupported;
            internal COLORREF black;
            internal COLORREF darkBlue;
            internal COLORREF darkGreen;
            internal COLORREF darkCyan;
            internal COLORREF darkRed;
            internal COLORREF darkMagenta;
            internal COLORREF darkYellow;
            internal COLORREF gray;
            internal COLORREF darkGray;
            internal COLORREF blue;
            internal COLORREF green;
            internal COLORREF cyan;
            internal COLORREF red;
            internal COLORREF magenta;
            internal COLORREF yellow;
            internal COLORREF white;
        }

        const int STD_OUTPUT_HANDLE = -11;
        internal static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        public void SetColor(ConsoleColor consoleColor, Color targetColor)
        {
            SetColor(consoleColor, targetColor.R, targetColor.G, targetColor.B);
        }

        public void SetColor(ConsoleColor color, uint r, uint g, uint b)
        {
            CONSOLE_SCREEN_BUFFER_INFO_EX csbe = new CONSOLE_SCREEN_BUFFER_INFO_EX();
            csbe.cbSize = Marshal.SizeOf(csbe);                    // 96 = 0x60
            IntPtr hConsoleOutput = GetStdHandle(STD_OUTPUT_HANDLE);    // 7
            if (hConsoleOutput == INVALID_HANDLE_VALUE)
            {
                throw new Exception("Invalid handle value returned.");
            }
            bool brc = GetConsoleScreenBufferInfoEx(hConsoleOutput, ref csbe);
            if (!brc)
            {
                throw new Exception("Failed to get CSBE.");
            }

            switch (color)
            {
                case ConsoleColor.Black:
                    csbe.black = new COLORREF(r, g, b);
                    break;
                case ConsoleColor.DarkBlue:
                    csbe.darkBlue = new COLORREF(r, g, b);
                    break;
                case ConsoleColor.DarkGreen:
                    csbe.darkGreen = new COLORREF(r, g, b);
                    break;
                case ConsoleColor.DarkCyan:
                    csbe.darkCyan = new COLORREF(r, g, b);
                    break;
                case ConsoleColor.DarkRed:
                    csbe.darkRed = new COLORREF(r, g, b);
                    break;
                case ConsoleColor.DarkMagenta:
                    csbe.darkMagenta = new COLORREF(r, g, b);
                    break;
                case ConsoleColor.DarkYellow:
                    csbe.darkYellow = new COLORREF(r, g, b);
                    break;
                case ConsoleColor.Gray:
                    csbe.gray = new COLORREF(r, g, b);
                    break;
                case ConsoleColor.DarkGray:
                    csbe.darkGray = new COLORREF(r, g, b);
                    break;
                case ConsoleColor.Blue:
                    csbe.blue = new COLORREF(r, g, b);
                    break;
                case ConsoleColor.Green:
                    csbe.green = new COLORREF(r, g, b);
                    break;
                case ConsoleColor.Cyan:
                    csbe.cyan = new COLORREF(r, g, b);
                    break;
                case ConsoleColor.Red:
                    csbe.red = new COLORREF(r, g, b);
                    break;
                case ConsoleColor.Magenta:
                    csbe.magenta = new COLORREF(r, g, b);
                    break;
                case ConsoleColor.Yellow:
                    csbe.yellow = new COLORREF(r, g, b);
                    break;
                case ConsoleColor.White:
                    csbe.white = new COLORREF(r, g, b);
                    break;
            }
            ++csbe.srWindow.Bottom;
            ++csbe.srWindow.Right;
            brc = SetConsoleScreenBufferInfoEx(hConsoleOutput, ref csbe);
            if (!brc)
            {
                throw new Exception("Failed to get CSBE.");
            }
        }

        public Color GetColor(ConsoleColor color)
        {
            CONSOLE_SCREEN_BUFFER_INFO_EX csbe = new CONSOLE_SCREEN_BUFFER_INFO_EX();
            csbe.cbSize = Marshal.SizeOf(csbe);                    // 96 = 0x60
            IntPtr hConsoleOutput = GetStdHandle(STD_OUTPUT_HANDLE);    // 7
            if (hConsoleOutput == INVALID_HANDLE_VALUE)
            {
                throw new Exception("Invalid handle value returned");
            }
            bool brc = GetConsoleScreenBufferInfoEx(hConsoleOutput, ref csbe);
            if (!brc)
            {
                throw new Exception("Failed to get CSBE");
            }
            Color rgbColor = new Color();
            switch (color)
            {
                case ConsoleColor.Black:
                    rgbColor = csbe.black.GetColor();
                    break;
                case ConsoleColor.DarkBlue:
                    rgbColor = csbe.darkBlue.GetColor();
                    break;
                case ConsoleColor.DarkGreen:
                    rgbColor = csbe.darkGreen.GetColor();
                    break;
                case ConsoleColor.DarkCyan:
                    rgbColor = csbe.darkCyan.GetColor();
                    break;
                case ConsoleColor.DarkRed:
                    rgbColor = csbe.darkRed.GetColor();
                    break;
                case ConsoleColor.DarkMagenta:
                    rgbColor = csbe.darkMagenta.GetColor();
                    break;
                case ConsoleColor.DarkYellow:
                    rgbColor = csbe.darkYellow.GetColor();
                    break;
                case ConsoleColor.Gray:
                    rgbColor = csbe.gray.GetColor();
                    break;
                case ConsoleColor.DarkGray:
                    rgbColor = csbe.darkGray.GetColor();
                    break;
                case ConsoleColor.Blue:
                    rgbColor = csbe.blue.GetColor();
                    break;
                case ConsoleColor.Green:
                    rgbColor = csbe.green.GetColor();
                    break;
                case ConsoleColor.Cyan:
                    rgbColor = csbe.cyan.GetColor();
                    break;
                case ConsoleColor.Red:
                    rgbColor = csbe.red.GetColor();
                    break;
                case ConsoleColor.Magenta:
                    rgbColor = csbe.magenta.GetColor();
                    break;
                case ConsoleColor.Yellow:
                    rgbColor = csbe.yellow.GetColor();
                    break;
                case ConsoleColor.White:
                    rgbColor = csbe.white.GetColor();
                    break;
            }
            return rgbColor;
        }
        #endregion
        private static KeyValuePair<Color, ConsoleColor>[] Colors = null;
        private static int CURRENT_COLOR_SLOT = 1;
        private const int MAX_COLORS = 16;

        public ColorMapper()
        {
            //initialize
            if (Colors == null)
            {
                Colors = new KeyValuePair<Color, ConsoleColor>[16];
                for (int i = 0; i < MAX_COLORS; i++)
                    Colors[i] = new KeyValuePair<Color, ConsoleColor>(GetColor((ConsoleColor)i), (ConsoleColor)i);
            }
        }

        public ConsoleColor GetMappedConsoleColor(Color color)
        {
            //find and return if color is already exists
            for (int i = 0; i < MAX_COLORS; i++)
            {
                if (Colors[i].Key == color)
                    return Colors[i].Value;
            }

            //over-write color if slot is full
            if (CURRENT_COLOR_SLOT >= MAX_COLORS) CURRENT_COLOR_SLOT = 1;

            //update color
            Colors[CURRENT_COLOR_SLOT] = new KeyValuePair<Color, ConsoleColor>(color, Colors[CURRENT_COLOR_SLOT].Value);
            SetColor(Colors[CURRENT_COLOR_SLOT].Value, color);
            return Colors[CURRENT_COLOR_SLOT++].Value;
        }
    }
}
