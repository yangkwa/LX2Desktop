using System.Numerics;
using System.Runtime.InteropServices;
using AppKit;

namespace LX2Desktop;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new AppShell();

        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        {
/*
 #if WINDOWS
            var nativeWindow = handler.PlatformView;
            nativeWindow.Activate();
            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
            ShowWindow(windowHandle, 3);
            SetWindowPos(windowHandle, -1, 0, 0, 0, 0, 0x0002 | 0x0001);
#endif
*/

        });
   }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window =  base.CreateWindow(activationState);
        window.Width = 1600;

        return window;
    }
   
 #if WINDOWS
    [DllImport("user32.dll")]
    public static extern bool ShowWindow(IntPtr hWnd, int cmdShow);
    [DllImport("user32.dll")]
    public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint nFlasgs);
 #endif
   
}

