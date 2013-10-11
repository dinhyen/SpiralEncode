SpiralEncode
============

Encodes an arbitrary string by "wrapping" it in a spiral inside a square. The square is the smallest which can accommodate the string.  Starting at the top left, the spiral goes left to right along the top edge, down along the right edge, right to left along the bottom edge, up along the left edge, and keep turning until there are no more characters.  The remaining space should be filled with an arbitrary character, like a space.  The encoded string is then read by concatenating one row at a time, left to right, top to bottom.

For ex, if the input is "abcde", the required square is 3x3 and is populated as:
```
abc
$$d
$$e
```
The encode string is then "abc$$d$$e".
