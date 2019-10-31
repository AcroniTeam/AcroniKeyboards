using System.Runtime.InteropServices;

namespace AcroniUI
{
    public class FontResource
    {
        [DllImport("gdi32.dll", EntryPoint = "AddFontResourceW", SetLastError = true)]
        public static extern int Add([In][MarshalAs(UnmanagedType.LPWStr)]
                                         string lpFileName);
    }
}
