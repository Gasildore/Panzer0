﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panzer0.Base
{
    internal class ConsoleRenderer
    {
        public int _width { get; private set; }
        public int _height { get; private set; }

        private const int MaxColors = 8;
        private readonly ConsoleColor[] _colors;
        private readonly string[,] _pixels;
        private readonly byte[,] _pixelColors;
        private readonly int _maxWidth;
        private readonly int _maxHeight;

        public ConsoleColor bgColor { get; set; }

        public string this[int w, int h]
        {
            get { return _pixels[w, h]; }
            set { _pixels[w, h] = value; }
        }

        public ConsoleRenderer(ConsoleColor[] colors)
        {
            if (colors.Length > MaxColors)
            {
                var tmp = new ConsoleColor[MaxColors];
                Array.Copy(colors, tmp, tmp.Length);
                colors = tmp;
            }

            _colors = colors;

            _maxWidth = Console.LargestWindowWidth;
            _maxHeight = Console.LargestWindowHeight;
            _width = Console.WindowWidth;
            _height = Console.WindowHeight;

            _pixels = new string[_maxWidth, _maxHeight];
            _pixelColors = new byte[_maxWidth, _maxHeight];
        }

        public void SetPixel(int w, int h, string val, byte colorIdx)
        {
            if (w < _maxWidth && h < _maxHeight)
            {
                _pixels[w, h] = val;
                _pixelColors[w, h] = colorIdx;
            }
        }

        public void Render()
        {
            Console.Clear();
            Console.BackgroundColor = bgColor;

            for (var w = 0; w < _width; w++)
                for (var h = 0; h < _height; h++)
                {
                    var colorIdx = _pixelColors[w, h];
                    var color = _colors[colorIdx];
                    var symbol = _pixels[w, h];

                    if (symbol == null || color == bgColor)
                        continue;

                    Console.ForegroundColor = color;

                    Console.SetCursorPosition(w, h);
                    Console.Write(symbol);
                }

            Console.ResetColor();
            Console.CursorVisible = false;
        }

        public void DrawString(string text, int atWidth, int atHeight, ConsoleColor color)
        {
            var colorIdx = Array.IndexOf(_colors, color);
            if (colorIdx < 0)
                return;

            for (int i = 0; i < text.Length; i++)
            {
                if (atWidth + i < _maxWidth && atHeight < _maxHeight)
                {
                    _pixels[atWidth + i, atHeight] = text[i].ToString();
                    _pixelColors[atWidth + i, atHeight] = (byte)colorIdx;
                }
            }
        }

        public void Clear()
        {
            for (int w = 0; w < _width; w++)
            {
                for (int h = 0; h < _height; h++)
                {
                    _pixelColors[w, h] = 0;
                    _pixels[w, h] = null;
                }
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is not ConsoleRenderer casted)
                return false;

            if (_maxWidth != casted._maxWidth || _maxHeight != casted._maxHeight ||
                _width != casted._width || _height != casted._height ||
                _colors.Length != casted._colors.Length)
            {
                return false;
            }

            for (int i = 0; i < _colors.Length; i++)
            {
                if (_colors[i] != casted._colors[i])
                    return false;
            }

            for (int w = 0; w < _width; w++)
                for (var h = 0; h < _height; h++)
                {
                    if (_pixels[w, h] != casted._pixels[w, h] || _pixelColors[w, h] != casted._pixelColors[w, h])
                    {
                        return false;
                    }
                }
            return true;
        }

        public override int GetHashCode()
        {
            var hash = HashCode.Combine(_maxWidth, _maxHeight, _width, _height);

            for (int i = 0; i < _colors.Length; i++)
            {
                hash = HashCode.Combine(hash, _colors[i]);
            }

            for (int w = 0; w < _width; w++)
                for (var h = 0; h < _height; h++)
                {
                    hash = HashCode.Combine(hash, _pixelColors[w, h], _pixels[w, h]);
                }

            return hash;
        }
    }
}