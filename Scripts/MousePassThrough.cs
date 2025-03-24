using Godot;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

public partial class MousePassThrough : Node
{
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/
	
	[DllImport("user32.dll")]
	private static extern IntPtr GetActiveWindow(); // GetActiveWindow() retrieves the handle of the window. 

	[DllImport("user32.dll")]
	private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
	// SetWindowLong() modifies a specific flag value associated with a window.
	// We pass the window handle, the index of the property, and the flags the property will have

	[DllImport("user32.dll")]
	static extern int SetLayeredWindowAttributes(IntPtr hWnd, uint crKey, byte bAlpha, uint dwFlags); // Sets the opacity and transparency color key of a layered window.

	[DllImport("user32.dll")]
	static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags); // Changes the size, position, and Z order of a child, pop-up, or top-level window. These windows are ordered according to their appearance on the screen. The topmost window receives the highest rank and is the first window in the Z order.

	[DllImport("user32.dll")]
	static extern bool SetForegroundWindow(IntPtr hWnd); // Brings the thread that created the specified window into the foreground and activates the window. Keyboard input is directed to the window, and various visual cues are changed for the user. The system assigns a slightly higher priority to the thread that created the foreground window than it does to other threads.
	
	const int GWL_EXSTYLE = -20; // Sets a new extended window style. 
	const int WS_EX_LAYERED = 0x00080000; // The window is a layered window. This style cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC. Windows 8: The WS_EX_LAYERED style is supported for top-level windows and child windows. Previous Windows versions support WS_EX_LAYERED only for top-level windows.
	const int WS_EX_TRANSPARENT = 0x00000020; // The window should not be painted until siblings beneath the window (that were created by the same thread) have been painted. The window appears transparent because the bits of underlying sibling windows have already been painted. To achieve transparency without these restrictions, use the SetWindowRgn function.
	const int WS_EX_TOPMOST = 0x000000008; // The window is palette window, which is a modeless dialog box that presents an array of commands.
	const int LWA_COLORKEY = 1; // Use crKey as the transparency color.
	

	static readonly IntPtr HWND_TOPMOST = new IntPtr(-1); // Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated.
	const UInt32 SWP_NOSIZE = 0x0001; // Retains the current size (ignores the cx and cy parameters).
	const UInt32 SWP_NOMOVE = 0x0002; // Retains the current position (ignores X and Y parameters).
	const UInt32 SWP_SHOWWINDOW = 0x0040; // Displays the window.
	const UInt32 SWP_NOZORDER = 0x0004; // Retains the current Z order (ignores the hWndInsertAfter parameter).
	const UInt32 SWP_FRAMECHANGED = 0x0020; // Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to the window, even if the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE is sent only when the window's size is being changed.

	IntPtr hWnd;

	public override void _Ready()
	{
		hWnd = GetActiveWindow();
		SetWindowLong(hWnd, GWL_EXSTYLE, WS_EX_LAYERED);
		SetLayeredWindowAttributes(hWnd, 0, 0, LWA_COLORKEY);
		SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED | SWP_SHOWWINDOW);
	}
}
