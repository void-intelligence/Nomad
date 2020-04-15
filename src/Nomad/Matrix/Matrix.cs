// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

/********************************************\
         Primary Matrix class logic.
\********************************************/

using System;

namespace Nomad.Matrix
{
    public partial class Matrix
    {
        private double[,] _matrix;

        public int Rows { get { return _matrix.GetLength(0); } }

        public int Columns { get { return _matrix.GetLength(1); } }

        public double this[int row, int column]
        {
            get
            {
                return _matrix[row, column];
            }

            set
            {
                _matrix[row, column] = value;
            }
        }

        public Matrix(int Rows, int Columns)
        {
            _matrix = new double[Rows, Columns];
        }

        public Matrix(int m) : this(m, m) { }

        #region Dot Product

        public void InDot(Matrix matrix)
        {
            if (Columns != matrix.Rows)
            {
                throw new InvalidOperationException("Cannot multiply matrices of different sizes.");
            }

            var _result = new double[Rows, matrix.Columns];
            for (int _row = 0; _row < Rows; _row++)
            {
                for (int _col = 0; _col < matrix.Columns; _col++)
                {
                    double _sum = 0;
                    for (int i = 0; i < Columns; i++)
                    {
                        _sum += _matrix[_row, i] * matrix[i, _col];
                    }
                    _result[_row, _col] = _sum;
                }
            }

            _matrix = _result;
        }

        public Matrix Dot(Matrix matrix)
        {
            var _mat = Duplicate();
            _mat.InDot(matrix);
            return _mat;
        }

        #endregion

        #region Hadamard (Element Multiplication)

        public void InHadamard(Matrix matrix)
        {
            if (Columns != matrix.Columns || Rows != matrix.Rows)
            {
                throw new InvalidOperationException("Cannot multiply matrices of different sizes.");
            }

            for (int _row = 0; _row < Rows; _row++)
            {
                for (int _col = 0; _col < Columns; _col++)
                {
                    _matrix[_row, _col] *= matrix[_row, _col];
                }
            }
        }

        public Matrix Hadamard(Matrix matrix)
        {
            var _mat = Duplicate();
            _mat.InHadamard(matrix);
            return _mat;
        }

        #endregion

        #region Scale Operation

        public void InScale(double scalar)
        {
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] *= scalar;
                }
            }
        }

        public Matrix Scale(double scalar)
        {
            var _mat = Duplicate();
            _mat.InScale(scalar);
            return _mat;
        }

        #endregion

        #region Add Operation

        public void InAdd(Matrix matrix)
        {
            // Vector Broadcasting
            if (matrix.Shape().Type() == Utility.EType.VectorTransposed)
            {
                matrix.InTranspose();
            }

            if (matrix.Shape().Type() == Utility.EType.Vector)
            {
                if (Rows != matrix.Rows)
                {
                    throw new InvalidOperationException("Cannot broadcast Vector.");
                }

                for (int _row = 0; _row < Rows; _row++)
                {
                    for (int _col = 0; _col < Columns; _col++)
                    {
                        _matrix[_row, _col] += matrix[_row, 0];
                    }
                }
                return;
            }

            // Normal Addition
            if (Rows != matrix.Rows || Columns != matrix.Columns)
            {
                throw new InvalidOperationException("Cannot add matrices of different sizes.");
            }
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] += matrix[_row, _col];
                }
            }
        }

        public Matrix Add(Matrix matrix)
        {
            var _mat = Duplicate();
            _mat.InAdd(matrix);
            return _mat;
        }

        #endregion

        #region Subtraction Operation

        public void InSub(Matrix matrix)
        {
            // Vector Broadcasting
            if (matrix.Shape().Type() == Utility.EType.VectorTransposed)
            {
                matrix.InTranspose();
            }

            if (matrix.Shape().Type() == Utility.EType.Vector)
            {
                if (Rows != matrix.Rows)
                {
                    throw new InvalidOperationException("Cannot broadcast Vector.");
                }

                for (int _row = 0; _row < Rows; _row++)
                {
                    for (int _col = 0; _col < Columns; _col++)
                    {
                        _matrix[_row, _col] -= matrix[_row, 1];
                    }
                }
                return;
            }

            // Normal Subtraction
            if (Rows != matrix.Rows || Columns != matrix.Columns)
            {
                throw new InvalidOperationException("Cannot sub matrices of different sizes.");
            }
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] -= matrix[_row, _col];
                }
            }
        }

        public Matrix Sub(Matrix matrix)
        {
            var _mat = Duplicate();
            _mat.InSub(matrix);
            return _mat;
        }

        #endregion

        #region Inverse Operation

        public void InInverse()
        {
            if (Rows != Columns)
            {
                throw new InvalidOperationException("Only square matrices can be inverted.");
            }

            int _dimension = Rows;
            var _result = _matrix.Clone() as double[,];
            var _identity = _matrix.Clone() as double[,];

            //make identity matrix
            for (int _row = 0; _row < _dimension; _row++)
            {
                for (int _col = 0; _col < _dimension; _col++)
                {
                    _identity[_row, _col] = (_row == _col) ? 1.0 : 0.0;
                }
            }

            //invert
            for (int i = 0; i < _dimension; i++)
            {
                double _tmp = _result[i, i];
                for (int j = 0; j < _dimension; j++)
                {
                    _result[i, j] = _result[i, j] / _tmp;
                    _identity[i, j] = _identity[i, j] / _tmp;
                }
                for (int k = 0; k < _dimension; k++)
                {
                    if (i != k)
                    {
                        _tmp = _result[k, i];
                        for (int n = 0; n < _dimension; n++)
                        {
                            _result[k, n] = _result[k, n] - _tmp * _result[i, n];
                            _identity[k, n] = _identity[k, n] - _tmp * _identity[i, n];
                        }
                    }
                }
            }
            _matrix = _identity;
        }

        public Matrix Inverse()
        {
            var _mat = Duplicate();
            _mat.InInverse();
            return _mat;
        }

        #endregion

        #region Transpose Operation

        public void InTranspose()
        {
            var _result = new double[Columns, Rows];

            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _result[_col, _row] = _matrix[_row, _col];
                }
            }

            _matrix = _result;
        }

        public Matrix Transpose()
        {
            var _mat = Duplicate();
            _mat.InTranspose();
            return _mat;
        }

        public void InT()
        {
            InTranspose();
        }

        public Matrix T()
        {
            var _mat = Duplicate();
            _mat.InTranspose();
            return _mat;
        }

        #endregion

        #region Map Functionality

        public void InMap(Func<double, double> func)
        {
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] = func(_matrix[_row, _col]);
                }
            }
        }

        public Matrix Map(Func<double, double> func)
        {
            var _mat = Duplicate();
            _mat.InMap(func);
            return _mat;
        }

        #endregion

        #region Randomization

        public void InRandomize(double lowest = 0.0, double highest = 1.0)
        {
            Random _random = new Random();
            double _diff = highest - lowest;
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] = (_random.NextDouble() * _diff) + lowest;
                }
            }
        }

        public Matrix Randomize(double lowest = 0.0, double highest = 1.0)
        {
            var _mat = Duplicate();
            _mat.InRandomize(lowest, highest);
            return _mat;
        }

        #endregion

        #region Fill

        public void InFill(double value)
        {
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] = value;
                }
            }
        }

        public Matrix Fill(double value)
        {
            var _mat = Duplicate();
            _mat.InFill(value);
            return _mat;
        }

        #endregion

        #region Flatten & Widen Functionality

        public void InFlatten()
        {
            _matrix = Flatten()._matrix;
        }

        public Matrix Flatten()
        {
            Matrix _result = new Matrix(Rows * Columns, 1);
            int k = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    _result[k, 0] = _matrix[i, j];
                    k++;
                }
            }
            return _result;
        }

        public void InWiden(int newX, int newY)
        {
            _matrix = Widen(newX, newY)._matrix;
        }

        public Matrix Widen(int newX, int newY)
        {
            if (Rows != newX * newY)
            {
                throw new InvalidOperationException("Invalid matrix size.");
            }

            bool _transpose = false;
            if (Type() != Utility.EType.Vector && Type() != Utility.EType.VectorTransposed)
            {
                throw new InvalidOperationException("Cannot widen a non-vector matrix.");
            }
            if (Type() == Utility.EType.VectorTransposed)
            {
                InTranspose();
                _transpose = true;
            }

            Matrix _result = new Matrix(newX, newY);

            int k = 0;
            for (int i = 0; i < newX; i++)
            {
                for (int j = 0; j < newY; j++)
                {
                    _result[i, j] = this[k, 0];
                    k++;
                }
            }

            if (_transpose)
            {
                InTranspose();
            }

            return _result;
        }

        public void InReshape(int newX, int newY)
        {
            _matrix = Reshape(newX, newY)._matrix;
        }

        public Matrix Reshape(int newX, int newY)
        {
            Matrix _tmp = Flatten();
            Matrix _result = _tmp.Widen(newX, newY);
            return _result;
        }

        #endregion

        #region Utility

        public Matrix Duplicate()
        {
            var _result = new Matrix(Rows, Columns);
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    _result[row, col] = _matrix[row, col];
                }
            }
            return _result;
        }

        public Matrix SubMatrix(int startX, int startY, uint dX, uint dY)
        {
            if (!(startX >= 0 && startX + dX <= Rows && startY >= 0 && startY + dY <= Columns))
            {
                throw new InvalidOperationException("Index out of bounds.");
            }

            Matrix _result = new Matrix((int)dX, (int)dY);
            for (int i = startX; i < startX + dX; i++)
            {
                for (int j = startY; j < startY + dY; j++)
                {
                    _result._matrix[i - startX, j - startY] = _matrix[i, j];
                }
            }

            return _result;
        }

        public Nomad.Utility.Shape Shape()
        {
            return new Utility.Shape(Rows, Columns);
        }

        public Utility.EType Type()
        {
            return Shape().Type();
        }

        public override string ToString()
        {
            string buffer = string.Empty;
            buffer += "[";
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    buffer += _matrix[row, col].ToString() + ", ";
                }
                buffer += "\n";
            }
            buffer += "]";
            return buffer;
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        #endregion
    }
}