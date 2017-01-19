using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace AutoClick_FirstBlood
{
    class MyMouseEventHandle
    {
        //public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        //public const int MOUSEEVENTF_LEFTUP = 0x04;
        //public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        //public const int MOUSEEVENTF_RIGHTUP = 0x10;
        //public const int MOUSEEVENTF_MOVE = 0x01;
        public const int MOUSEEVENTF_MOVE = 0x0001;
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const int MOUSEEVENTF_LEFTUP = 0x0004;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        [DllImport("user32.dll")]//, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //public static void DoLeftMouseSingleClick()
        //{
        //    //Call the imported function with the cursor's current position
        //    int X = Cursor.Position.X;
        //    int Y = Cursor.Position.Y;
        //    mouse_event(MOUSEEVENTF_LEFTDOWN
        //                | MOUSEEVENTF_LEFTUP,
        //                (uint)X + 100, (uint)Y + 100, 0, 0);
        //}

        //public static void DoRightMouseSingleClick()
        //{
        //    int X = Cursor.Position.X;
        //    int Y = Cursor.Position.Y;
        //    mouse_event(MOUSEEVENTF_RIGHTDOWN
        //                | MOUSEEVENTF_RIGHTUP,
        //                (uint)X, (uint)Y, 0, 0);
        //}

        //public static void DoLeftMouseDoubleClick()
        //{
        //    int X = Cursor.Position.X;
        //    int Y = Cursor.Position.Y;
        //    mouse_event(MOUSEEVENTF_LEFTDOWN
        //                | MOUSEEVENTF_LEFTUP,
        //                (uint)X, (uint)Y, 0, 0);
        //    mouse_event(MOUSEEVENTF_LEFTDOWN
        //                | MOUSEEVENTF_LEFTUP,
        //                (uint)X, (uint)Y, 0, 0);
        //}

        //public static void DoRightMouseDoubleClick()
        //{
        //    int X = Cursor.Position.X;
        //    int Y = Cursor.Position.Y;
        //    mouse_event(MOUSEEVENTF_RIGHTDOWN
        //                | MOUSEEVENTF_RIGHTUP,
        //                (uint)X, (uint)Y, 0, 0);
        //    mouse_event(MOUSEEVENTF_RIGHTDOWN
        //                | MOUSEEVENTF_RIGHTUP,
        //                (uint)X, (uint)Y, 0, 0);
        //}

        public static void DoLeftMouseSingleClickWithPostions(ref List<Point> posList)
        {
            foreach (Point pos in posList)
            {
                Cursor.Position = pos;
                int X = Cursor.Position.X;
                int Y = Cursor.Position.Y;
                mouse_event(MOUSEEVENTF_LEFTDOWN
                        | MOUSEEVENTF_LEFTUP,
                        (uint)X, (uint)Y, 0, 0);
            }
        }

        public static void DoLeftMouseDownWithPosition(ref List<Point> posList)
        {
            foreach (Point pos in posList)
            {
                Cursor.Position = pos;
                int X = Cursor.Position.X;
                int Y = Cursor.Position.Y;
                mouse_event(MOUSEEVENTF_LEFTDOWN,
                        (uint)X, (uint)Y, 0, 0);
            }
        }
    }
}
