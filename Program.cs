using System;
using System.Collections.Generic;
using System.Text;

namespace SpiralEncode
{
   class Program
   {
      static void Main(string[] args)
      {
         if (args.Length != 1)
         {
            Print("Usage: SpiralEncode [string]");
            return;
         }

         SpiralEncoder encoder = new SpiralEncoder(args[0]);
         Print("Input:\t" + args[0]);
         Print("Output:\t" + encoder.GetEncodedString());

         Print("Press any key to continue...");
         Console.ReadKey();
      }

      private static void Print(string text)
      {
         Console.WriteLine(text);
      }

   }  // class

   class SpiralEncoder
   {
      #region Fields

      private string _message = string.Empty;
      private Queue<char> _queue = null;

      private Array _square = null;
      private int _side, _maxIndex;
      private int _ring;

      #endregion

      public SpiralEncoder(string message)
      {
         _message = message;
         int length = message.Length;

         _queue = new Queue<char>(length);
         foreach (char c in _message)
            _queue.Enqueue(c);

         _side = GetMaxSquareRoot(length);
         _maxIndex = _side - 1;
         _square = new char[_side, _side];

         Encode();
      }

      private void Encode()
      {
         for (int top = _side; top > 0; top -= 2)
         {
            _ring = (_side - top) / 2;
            Top();
            if (top > 1)
            {
               Right();
               Bottom();
               Left();
            }
         }
      }

      public string GetEncodedString()
      {
         StringBuilder builder = new StringBuilder();
         for (int row = 0; row <= _maxIndex; ++row)
            for (int col = 0; col <= _maxIndex; ++col)
               builder.Append(_square.GetValue(row, col));

         return builder.ToString();
      }

      public void Top()
      {
         int row = _ring;
         for (int col = _ring; col <= _maxIndex - _ring; ++col)
            SetCell(row, col);
      }
      public void Bottom()
      {
         int row = _maxIndex - _ring;
         for (int col = _maxIndex - _ring - 1; col >= _ring; --col)
            SetCell(row, col);
      }
      public void Right()
      {
         int col = _maxIndex - _ring;
         for (int row = 1 + _ring; row <= _maxIndex - _ring; ++row)
            SetCell(row, col);
      }
      public void Left()
      {
         int col = _ring;
         for (int row = _maxIndex - _ring - 1; row >= _ring + 1; --row)
            SetCell(row, col);
      }

      #region Utils

      private static int GetMaxSquareRoot(int target)
      {
         return (int)(Math.Ceiling(Math.Sqrt((double)target)));
         //for (int i = 0; i <= target; ++i)
         //   if (i * i >= target)
         //      return i;
         //return target;
      }

      private void SetCell(int row, int col)
      {
         char c;
         if (_queue.Count > 0)
            c = _queue.Dequeue();
         else
            c = '$';

         if (row > _maxIndex && col > _maxIndex)
            throw new IndexOutOfRangeException("Specified index exceeds dimension of square");
         _square.SetValue(c, row, col);
      }

      #endregion
   }

}  // namespace
