# MATRIX CLASS

### OVERVIEW

The matrix class is split into four separate files to improve code readability and maintenance.  

The four files are as follows.

1- **Matrix.cs**
Primary logic functionality of the Matrix class.

2- **Matrices.cs**
Methods for creating special types of ready-made matrices. 

3- **Operators.cs**
Matrix's operators are all overloaded in this file.

4- **Transformation.cs**
2D and 3D Matrix Transformation logic.

## Matrix.cs Methods

There are two types of Methods in the Matrix class, in-place and normal methods. The in-place functions make changes to the instance they're being called on. the normal methods however, make a new instance of the matrix class and work on the new instance.

The In-place functions are all prefixed with **In**

Below you can see a list of all the functions currently implemented in the matrix class.

### DOT PRODUCT
Calculates the Dot Product between two matrices. (or a matrix and a Vector)

1- ```public Matrix Dot(Matrix matrix);```
2- ```public void InDot(Matrix matrix);```

```C#
Matrix a = new Matrix(5, 10);
Matrix b = new Matrix(10, 8);
// TODO: Fill in matrices a and b
// ...

// Calculates the Dot product between a and b
// and puts the resulting matrix in c
Matrix c = a.Dot(b);

// Can also be written as
Matrix d = a * b;

// Calculates the Dot product between a and b
// and puts the resulting matrix in a
a.InDot(b);
```

### HADAMARD PRODUCT


Calculates the Hadamard Product (Element-wise multiplication) of two matrices.

1- ```public Matrix Hadamard(Matrix matrix);```
2- ```public void InHadamard(Matrix matrix);```

```C#
Matrix a = new Matrix(5, 10);
Matrix b = new Matrix(5, 10);
// TODO: Fill in matrices a and b
// ...

// Calculates the Hadamard product between a and b
// and puts the resulting matrix in c
Matrix c = a.Hadamard(b);

// Calculates the Hadamard product between a and b
// and puts the resulting matrix in a
a.InHadamard(b);
```

### SCALE OPERATION

Scales the matrix with a scalar value. (*double*)

1- ```public Matrix Scale(double scalar);```
2- ```public void InScale(double scalar);```

```C#
Matrix a = new Matrix(5, 10);
// TODO: Fill in matrix a
// ...

// Scales the matrix a and puts the result in c
Matrix c = a.Scale(10);

// Can also be written as
Matrix d = a * 10;

// Scales the matrix a and puts the result in a
a.InScale(10);
```

### ADD OPERATION

Calculates the sum of two matrices.

##### SUPPORTS VECTOR BROADCASTING

1- ```public Matrix Add(Matrix matrix);```
2- ```public void InAdd(Matrix matrix);```

```C#
Matrix a = new Matrix(5, 10);
Matrix b = new Matrix(5, 10);
// TODO: Fill in matrices a and b
// ...

// Calculates the Sum of a and b
// and puts the resulting matrix in c
Matrix c = a.Add(b);

// Can also be written as
Matrix d = a + b;

// Calculates the Sum of a and b
// and puts the resulting matrix in a
a.InAdd(b);
```

### SUBTRACT OPERATION

Calculates the difference of two matrices.

##### SUPPORTS VECTOR BROADCASTING

1- ```public Matrix Sub(Matrix matrix);```
2- ```public void InSub(Matrix matrix);```

```C#
Matrix a = new Matrix(5, 10);
Matrix b = new Matrix(5, 10);
// TODO: Fill in matrices a and b
// ...

// Calculates the difference of a and b
// and puts the resulting matrix in c
Matrix c = a.Sub(b);

// Can also be written as
Matrix d = a - b;

// Calculates the difference of a and b
// and puts the resulting matrix in a
a.InSub(b);
```


### INVERSE OPERATION

Calculates the inverse of a matrix.

1- ```public Matrix Inverse();```
2- ```public void InInverse();```

```C#
Matrix a = new Matrix(5, 10);
// TODO: Fill in matrix a
// ...

// Calculates the inverse of a
// and puts the resulting matrix in b
Matrix b = a.Inverse();

// Can also be written as 
Matrix d = !a;

// Calculates the inverse of a
// and puts the resulting matrix in a
a.InInverse();
```

### TRANSPOSE OPERATION

Calculates the Transpose of a matrix.

1- ```public void InTranspose();```
2- ```public Matrix Transpose();```
3- ```public void InT();```
4- ```public Matrix T();```


```C#
Matrix a = new Matrix(5, 10);
// TODO: Fill in matrices a
// ...

// Calculates the transpose of a
// and puts the resulting matrix in b
Matrix b = a.Transpose();
b = a.T();

// Calculates the transpose of a
// and puts the resulting matrix in a
a.InTranspose();
a.InT();
```

### MAP FUNCTIONALITY

Applies a function to all elements of the matrix.


1- ```public void InMap(Func<double, double> func);```
2- ```public Matrix Map(Func<double, double> func);```

```C#
// Let's assume this is the function we want to map to our matrix object
public double Square(double val) 
{
	return val * val;
}
```

```C#
Matrix a = new Matrix(5, 10);
// TODO: Fill in matrices a
// ...

// Maps the function Square(double) to the matrix
// and puts the resulting matrix in b
Matrix b = a.Map(Square);

// Maps the function Square(double) to the matrix
// and puts the resulting matrix in a
a.InMap(Square);
```

### RANDOMIZATION

Fills in the matrix with random values.

There are two overloads of these functions. You can either determine lower and upper limits to randomization or let it be 0.0 and 1.0 by default.

1- ```public void InRandomize(double lowest, double highest);```
2- ```public Matrix Randomize(double lowest, double highest);```
3- ```public void InRandomize();```
4- ```public Matrix Randomize();```


```C#
Matrix a = new Matrix(5, 10);

// Randomizes the values of matrix a (0.0, 1.0)
a.InRandomize();

// Creates a matrix of size a, randomizes it and puts it in matrix b (0.0, 1.0)
Matrix b = a.Randomize();
```

### UTILITY FUNCTIONS

1- ```public Matrix Duplicate();```

Grabs a duplicate instance of the matrix
```C#
Matrix a = new Matrix(5, 10);
a.InRandomize();

Matrix b = a.Duplicate();
```

2- ```public Nomad.Utility.Shape Shape()```

Grabs the shape of the Matrix
```C#
Matrix a = new Matrix(5, 5);
a.InRandomize();

// Shape is (5, 5) of type Square Matrix
Shape s = a.Shape();
```

3- ```public Utility.EType Type()```

Grabs the type of the Matrix
```C#
Matrix a = new Matrix(10, 1);
a.InRandomize();

// In this case a vector
EType t = a.Type();
```

## Matrices.cs Methods

There are four public methods in the Matrices.cs

1- ```public static Matrix Zero(int size)```

Returns a Square Matrix(size, size) filled with zeros.

2- ```public static Matrix Zero(int rows, int cols)```

Returns a Square Matrix(rows, cols) filled with zeros.

3- ```public static Matrix Identity(int size)```

Returns an Identity Matrix(Size, Size).

4- ```public static Matrix Vandermonde(int rows, int cols)```

Returns a Vandermonde Matrix(rows, cols) filled with Vandermonde formula.
