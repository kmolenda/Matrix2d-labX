#nullable disable

using System.Numerics;

namespace Matrix2dLib;

// immutable 2x2 matrix
public class Matrix2d : IEquatable<Matrix2d>
{
    private int _a, _b, _c, _d;

    // ctor's
    public Matrix2d(int a, int b, int c, int d)
    {
        _a = a;
        _b = b;
        _c = c;
        _d = d;
    }

    public Matrix2d() : this(1, 0, 0, 1) { }

    // properties
    public int A => _a;
    public int B => _b;
    public int C => _c;
    public int D => _d;

    public static Matrix2d Id => new Matrix2d();
    public static Matrix2d Zero => new Matrix2d(0, 0, 0, 0);

    // methods
    override public string ToString() => $"[[{_a}, {_b}], [{_c}, {_d}]]";

    #region Equals
    public bool Equals(Matrix2d other)
    {
        if( other is null ) return false;

        return _a == other._a && 
               _b == other._b && 
               _c == other._c && 
               _d == other._d;
    }

    public static bool operator ==(Matrix2d left, Matrix2d right) 
        => left.Equals(right);

    public static bool operator !=(Matrix2d left, Matrix2d right)
        => !left.Equals(right);
    #endregion

    #region Arytmetyka
    public static Matrix2d operator +(Matrix2d left, Matrix2d right)
        => new Matrix2d(left._a + right._a, 
                        left._b + right._b, 
                        left._c + right._c, 
                        left._d + right._d);


    // operator jednoargumentowy zmiany znaku
    public static Matrix2d operator -(Matrix2d m)
        => new Matrix2d(-m._a, -m._b, -m._c, -m._d);
    #endregion

    #region Konwersje

    // konwersja jawna z Matrix2d do int[,]
    public static explicit operator int[,](Matrix2d m)
        => new int[,] { { m._a, m._b }, { m._c, m._d } };

    // konwersja niejawna z int[,] do Matrix2d
    public static implicit operator Matrix2d(int[,] m)
        => new Matrix2d(m[0, 0], m[0, 1], m[1, 0], m[1, 1]);

    #endregion
}

