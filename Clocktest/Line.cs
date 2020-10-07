using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Clocktest
{
    public class Line
    {
        public int _x0;
        public int _x1;
        public int _y0;
        public int _y1;

        public Line(int x0, int y0, int x1, int y1)
        {
            _x0 = x0;
            _x1 = x1;
            _y0 = y0;
            _y1 = y1;
        }
        public void CalcLine()
        {
            var steep = Math.Abs(_y1 - _y0) > Math.Abs(_x1 - _x0);
            if (steep)
            {
                int t;
                t = _x0; // swap x0 and y0
                _x0 = _y0;
                _y0 = t;
                t = _x1; // swap x1 and y1
                _x1 = _y1;
                _y1 = t;
            }
            if (_x0 > _x1)
            {
                int t;
                t = _x0; // swap x0 and x1
                _x0 = _x1;
                _x1 = t;
                t = _y0; // swap y0 and y1
                _y0 = _y1;
                _y1 = t;
            }
            var dx = _x1 - _x0;
            var dy = Math.Abs(_y1 - _y0);
            var error = dx / 2;
            var ystep = (_y0 < _y1) ? 1 : -1;
            var y = _y0;
            for (var x = _x0; x <= _x1; x++)
            {
                error = error - dy;
                if (error >= 0) continue;
                y += ystep;
                error += dx;
                DrawPixel((steep ? y : x), (steep ? x : y));
            }
        }

        public void DrawPixel(int x, int y)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.Write("█");
        }
    }
}
