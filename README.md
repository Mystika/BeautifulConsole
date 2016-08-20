BeautifulConsole
=====

**BeautifulConsole** is a light-weight `System.Console` wrapping library that supports `System.Drawing.Color`.

## Usage

#### Basic Usage
```cs
using System.Drawing;
using Console = Beautiful.Console;

/* ... */

Console.WriteLine("normal text");
Console.WriteLine("orange flavored text", Color.Orange);
Console.WriteLine("lime flavored text", Color.Lime);
Console.WriteLine("normal text");
```

#### Let's playing with System.Drawing.Color

```cs
int rgb = 255;
for (int i = 1; i <= 15; i++)
{
    Console.WriteLine("Greyscale gradient " + i, Color.FromArgb(rgb, rgb, rgb));
    rgb -= 17;
}
```
