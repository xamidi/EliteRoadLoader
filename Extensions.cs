using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Runtime.InteropServices;

namespace AutomationLib
{
    public static class Interop
    {
        public class Kernel32
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern uint GetCurrentThreadId();
        }
    }

    public static class Extensions
    {
        public static bool FitsAbsoluteInto(this Point pt, Rectangle rect)
        {
            return pt.X >= rect.X && pt.X < rect.Right && pt.Y >= rect.Y && pt.Y < rect.Bottom;
        }
        public static bool FitsRelativeInto(this Point pt, Rectangle rect)
        {
            return pt.X >= 0 && pt.X < rect.Width && pt.Y >= 0 && pt.Y < rect.Height;
        }
        public static IntPtr ToIntPtr(this UIntPtr uintPtr)
        {
            if (UIntPtr.Size == 4)
                return unchecked((IntPtr)(int)uintPtr);
            else if (UIntPtr.Size == 8)
                return unchecked((IntPtr)(long)uintPtr);
            else
                throw new InvalidCastException("UIntPtr.Size == " + UIntPtr.Size + ". This function supports only 32 and 64 bit architectures.");
        }
        public static UIntPtr ToUIntPtr(this IntPtr intPtr)
        {
            if (IntPtr.Size == 4)
                return unchecked((UIntPtr)(uint)intPtr);
            else if (IntPtr.Size == 8)
                return unchecked((UIntPtr)(ulong)intPtr);
            else
                throw new InvalidCastException("IntPtr.Size == " + IntPtr.Size + ". This function supports only 32 and 64 bit architectures.");
        }
        public static Rectangle ToRectangle(this System.Windows.Rect value)
        {
            return new Rectangle((int)value.X, (int)value.Y, (int)value.Width, (int)value.Height);
        }
        public static System.Windows.Rect ToRect(this Rectangle value)
        {
            return new System.Windows.Rect(value.X, value.Y, value.Width, value.Height);
        }
        public static Point ToPoint(this System.Windows.Point value)
        {
            return new Point((int)value.X, (int)value.Y);
        }
        public static System.Windows.Point ToWindowsPoint(this Point value)
        {
            return new System.Windows.Point(value.X, value.Y);
        }
        public static void Add<T>(this T[] arr, T elem)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = elem;
        }
    }

    public sealed class AppDomainExtender
    {
        public static int GetCurrentThreadId_New()
        {
            return unchecked((int)Interop.Kernel32.GetCurrentThreadId());
        }
    }

    public static class Timing
    {
        /// <summary>
        /// Thread.Sleep(millisecondsTimeout + new Random().Next(0, millisecondsTimeout / 2));
        /// </summary>
        /// <param name="millisecondsTimeout">The number of milliseconds for which the thread is at least blocked.</param>
        /// <param name="randomFactor">The factor which is at most added to the waiting time.</param>
        public static void RandomizedSleep(int millisecondsTimeout, double randomFactor = 0.5)
        {
            Thread.Sleep(millisecondsTimeout + new Random().Next(0, (int)(millisecondsTimeout * randomFactor)));
        }
        public static void RandomizedSleep(uint millisecondsTimeout, double randomFactor = 0.5)
        {
            Thread.Sleep((int)millisecondsTimeout + new Random().Next(0, (int)(millisecondsTimeout * randomFactor)));
        }
    }

    public class OptionalOut<Type>
    {
        public Type Result { get; set; }
    }
}
