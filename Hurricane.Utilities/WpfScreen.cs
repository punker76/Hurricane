﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using Point = System.Windows.Point;

namespace Hurricane.Utilities
{
    public class WpfScreen
    {
        public static IEnumerable<WpfScreen> AllScreens()
        {
            return Screen.AllScreens.Select(screen => new WpfScreen(screen));
        }

        public static WpfScreen GetScreenFrom(Window window)
        {
            var windowInteropHelper = new WindowInteropHelper(window);
            Screen screen = Screen.FromHandle(windowInteropHelper.Handle);
            WpfScreen wpfScreen = new WpfScreen(screen);
            return wpfScreen;
        }

        public static WpfScreen GetScreenFrom(Point point)
        {
            var x = (int)Math.Round(point.X);
            var y = (int)Math.Round(point.Y);

            System.Drawing.Point drawingPoint = new System.Drawing.Point(x, y);
            var screen = Screen.FromPoint(drawingPoint);
            return new WpfScreen(screen);
        }

        public static double MaxHeight
        {
            get
            {
                double i = 0;
                foreach (var s in Screen.AllScreens)
                    if (s.Bounds.Height > i) i = s.Bounds.Height;
                return i;
            }
        }

        private static double? _mostRightX;
        public static double MostRightX
        {
            get
            {
                if (!_mostRightX.HasValue)
                {
                    foreach (var screen in AllScreens())
                    {
                        if (_mostRightX == null || _mostRightX <= screen.WorkingArea.X) _mostRightX = screen.WorkingArea.X + screen.WorkingArea.Width;
                    }
                }
                // ReSharper disable once PossibleInvalidOperationException
                return _mostRightX.Value;
            }
        }

        private static double? _mostLeftX;
        public static double MostLeftX
        {
            get
            {
                if (!_mostLeftX.HasValue)
                {
                    foreach (var screen in AllScreens())
                    {
                        if (_mostLeftX == null || _mostLeftX > screen.WorkingArea.X) _mostLeftX = screen.WorkingArea.X;
                    }
                }
                // ReSharper disable once PossibleInvalidOperationException
                return _mostLeftX.Value;
            }
        }

        public static WpfScreen Primary => new WpfScreen(Screen.PrimaryScreen);

        private readonly Screen _screen;

        internal WpfScreen(Screen screen)
        {
            _screen = screen;
        }

        public Rect DeviceBounds => GetRect(_screen.Bounds);

        public Rect WorkingArea => GetRect(_screen.WorkingArea);

        private Rect GetRect(Rectangle value)
        {
            return new Rect
            {
                X = value.X,
                Y = value.Y,
                Width = value.Width,
                Height = value.Height
            };
        }

        public bool IsPrimary => _screen.Primary;

        public string DeviceName => _screen.DeviceName;
    }
}