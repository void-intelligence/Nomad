// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Nomad.Utility;

namespace Nomad.Core
{
    public partial class Matrix
    {
        public List<Matrix> Cache { get; }

        // ReSharper disable once InconsistentNaming
        public Guid GUID { get; }

        private double[,] _matrix;
        public int Rows => _matrix.GetLength(0);
        public int Columns => _matrix.GetLength(1);
        public double this[int row, int column]
        {
            get => _matrix[row, column];
            set => _matrix[row, column] = value;
        }

        public Matrix(int rows, int columns)
        {
            _matrix = new double[rows, columns];
            Cache = new List<Matrix>();
            GUID = Guid.NewGuid();
        }

        public Matrix(int rows, int columns, double value) : this(rows, columns)
        {
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] = value;
        }

        public Matrix(int m) : this(m, m)
        {
        }

        public Matrix(int m, double values) : this(m, m, values)
        {
        }

        public Matrix(double[,] values)
        {
            var rows = values.GetLength(0);
            var cols = values.GetLength(1);
            _matrix = new double[rows, cols];
            for (var i = 0; i < rows; i++)
            for (var j = 0; j < cols; j++)
                _matrix[i, j] = values[i, j];
        }

        public Matrix(IReadOnlyList<double> vectorValues)
        {
            _matrix = new double[vectorValues.Count, 1];
            for (var i = 0; i < vectorValues.Count; i++)
                _matrix[i, 0] = vectorValues[i];
        }

        public Matrix Duplicate()
        {
            var result = new Matrix(Rows, Columns);
            for (var row = 0; row < Rows; row++)
            for (var col = 0; col < Columns; col++)
                result[row, col] = _matrix[row, col];
            return result;
        }

        public Matrix SubMatrix(int startX, int startY, uint dX, uint dY)
        {
            if (!(startX >= 0 && startX + dX <= Rows && startY >= 0 && startY + dY <= Columns))
                throw new InvalidOperationException("Index out of bounds.");

            var result = new Matrix((int)dX, (int)dY);
            for (var i = startX; i < startX + dX; i++)
            for (var j = startY; j < startY + dY; j++)
                result._matrix[i - startX, j - startY] = _matrix[i, j];

            return result;
        }

        public void InMap(Func<double, double> func)
        {
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] = func(_matrix[row, col]);
        }

        public Matrix Map(Func<double, double> func)
        {
            var mat = Duplicate();
            mat.InMap(func);
            return mat;
        }

        public Shape Shape()
        {
            return new Shape(Rows, Columns);
        }

        public EType Type()
        {
            return Shape().Type();
        }

        public override string ToString()
        {
            var buffer = string.Empty;
            buffer += "[";
            for (var row = 0; row < Rows; row++)
            {
                for (var col = 0; col < Columns; col++)
                    buffer += _matrix[row, col].ToString(CultureInfo.InvariantCulture) + ", ";
                buffer += "\n";
            }

            buffer = buffer.TrimEnd();
            buffer += "]";
            return buffer;
        }

        public void FromString(string matrixString)
        {
            matrixString = matrixString.Replace("[", string.Empty);
            matrixString = matrixString.Replace("]", string.Empty);

            var cols = matrixString.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var rows = cols.Select(col => col.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();

            _matrix = new double[cols.Length, rows.Count];
            for (var i = 0; i < Rows; i++)
            for (var j = 0; j < Columns; j++)
                if (rows[i][j] != string.Empty) _matrix[i, j] = double.Parse(rows[i][j]);
        }

        public string Save()
        {
            return ToString();
        }

        public void Load(string matrixString)
        {
            FromString(matrixString);
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }
        
        public override bool Equals(object obj)
        {
            return this == obj as Matrix;
        }

        public override int GetHashCode()
        {
            var matrixString = new StringBuilder();
            matrixString.Append(Rows).Append("x").Append(Columns).Append("=");
            for (var row = 0; row < Rows; row++)
            for (var col = 0; col < Columns; col++) matrixString.Append(this[row, col]).Append(";");

            return matrixString.ToString().GetHashCode();
        }
    }
}
