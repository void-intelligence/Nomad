# MATRIX CLASS

### OVERVIEW

The matrix class is split into five separate files to improve code readability and maintenance.  

The five files are as follows.

1- [**Matrix.cs**](https://github.com/void-intelligence/Nomad/blob/master/docs/Matrix.md#matrixcs-methods)
Primary logic functionality of the Matrix class.

2- [**Matrices.cs**](https://github.com/void-intelligence/Nomad/blob/master/docs/Matrix.md#matricescs-methods)
Methods for creating special types of ready-made matrices. 

3- [**Operators.cs**](https://github.com/void-intelligence/Nomad/blob/master/docs/Matrix.md#operatorscs-methods)
Matrix's operators are all overloaded in this file.

4- [**Transformation.cs**](https://github.com/void-intelligence/Nomad/blob/master/docs/Matrix.md#transformationcs-methods)
2D and 3D Matrix Transformation logic.

5- [**Norm.cs**](https://github.com/void-intelligence/Nomad/blob/master/docs/Matrix.md#normcs-methods)
Various Norm calculation functions for the matrix class.

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
// and stores the resulting matrix in c
Matrix c = a.Dot(b);

// Can also be written as
Matrix d = a * b;

// Calculates the Dot product between a and b
// and stores the resulting matrix in a
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
// and stores the resulting matrix in c
Matrix c = a.Hadamard(b);

// Calculates the Hadamard product between a and b
// and stores the resulting matrix in a
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

// Scales the matrix a and stores the result in c
Matrix c = a.Scale(10);

// Can also be written as
Matrix d = a * 10;

// Scales the matrix a and stores the result in a
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
// and stores the resulting matrix in c
Matrix c = a.Add(b);

// Can also be written as
Matrix d = a + b;

// Calculates the Sum of a and b
// and stores the resulting matrix in a
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
// and stores the resulting matrix in c
Matrix c = a.Sub(b);

// Can also be written as
Matrix d = a - b;

// Calculates the difference of a and b
// and stores the resulting matrix in a
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
// and stores the resulting matrix in b
Matrix b = a.Inverse();

// Can also be written as 
Matrix d = !a;

// Calculates the inverse of a
// and stores the resulting matrix in a
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
// TODO: Fill in matrix a
// ...

// Calculates the transpose of a
// and stores the resulting matrix in b
Matrix b = a.Transpose();
b = a.T();

// Calculates the transpose of a
// and stores the resulting matrix in a
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
// TODO: Fill in matrix a
// ...

// Maps the function Square(double) to the matrix
// and stores the resulting matrix in b
Matrix b = a.Map(Square);

// Maps the function Square(double) to the matrix
// and stores the resulting matrix in a
a.InMap(Square);
```

### RANDOMIZATION

Fills in the matrix with random values.

There are two overloads of these functions. You can either determine lower and upper limits to randomization or let it be 0.0 and 1.0 by default.

1- ```public void InRandomize(double lowest = 0.0, double highest = 1.0, EDistribution distribution = EDistribution.Uniform);```

2- ```public Matrix Randomize(double lowest = 0.0, double highest = 1.0, EDistribution distribution = EDistribution.Uniform);```

```C#
Matrix a = new Matrix(5, 10);

// Randomizes the values of matrix a with values ranging between 10.0 and 15.0
// Using a uniform random number distribution to fill the matrix
// The result will be stored in matrix a
a.InRandomize(10.0, 15.0, EDistribution.Uniform);

// Randomizes the values of matrix a with values ranging between 10.0 and 15.0
// Using a uniform random number distribution to fill the matrix
// The result will be stored in matrix b while retaining the shape of a
Matrix b = a.Randomize(10.0, 15.0, EDistribution.Uniform);
```

You can read more about EDistribution enum [here](https://github.com/void-intelligence/Nomad/blob/master/docs/EDistribution.md).

### FILL OPERATION

Fills the matrix with a given value.

1- ```public void InFill(double value);```

2- ```public Matrix Fill(double value);```


```C#
Matrix a = new Matrix(5, 10);

// Fills the matrix a with the value 5 and stores it in matrix b
Matrix b = a.Fill(5);

// Fills the matrix a with the value 5 and stores it in matrix a
a.InFill(5);
```

### FLATTEN, WIDEN AND RESHAPE OPERATION

Flattening a matrix will transform it into vector form.

#### Flatten

1- ```public void InFlatten();```

2- ```public Matrix Flatten();```


```C#
Matrix a = new Matrix(5, 10);
// TODO: Fill in matrix a
// ...

// Flattens the matrix a and stores the resulting vector in b
Matrix b = a.Flatten();

// Flattens the matrix a and stores the resulting vector in a
a.InFlatten();
```

#### Widen

Widening a vector will transform it into a matrix form.

1- ```public void InWiden(int newX, int newY);```

2- ```public Matrix Widen(int newX, int newY);```

#### NOTE: newX * newY MUST EQUAL TO THE ROW COUNT OF THE CURRENT VECTOR

```C#
Matrix a = new Matrix(10, 1);
// TODO: Fill in vector a
// ...

// Widens the vector a and stores the resulting matrix in b
Matrix b = a.Widen(5, 2);

// Widens the vector a and stores the resulting matrix in a
a.InWiden(5, 2);
```

#### Reshape

Reshape will perform a flatten and a widen on the matrix to change the dimentions while retaining the data within the structure of the matrix.

1- ```public void InReshape(int newX, int newY);```

2- ```public Matrix Reshape(int newX, int newY)```

```C#
Matrix a = new Matrix(4, 2);
// TODO: Fill in vector a
// ...

// Reshapes the matrix a from (4, 2) into (2, 4) 
// and stores the resulting matrix into b
Matrix b = a.Reshape(2, 4);

// Reshapes the matrix a from (4, 2) into (2, 4) 
// and stores the resulting matrix into a
a.InReshape(2, 4);
```

<<<<<<< Updated upstream
#### Merge and Split
=======
<<<<<<< Updated upstream
=======
#### Element-Wise Function Operations

There are three helper functions in this section.

##### OneMinus

The OneMinus Operation produces the following value: ```1 - Mat```

1- ```public void InOneMinus();```

2- ```public Matrix OneMinus();```

##### OneOver

The OneOver Operation produces the following value: ```1 / Mat```

1- ```public void InOneOver();```

2- ```public Matrix OneOver();```

##### Power2

The OneOver Operation produces the following value: ```Mat.Hadamard(Mat)```

1- ```public void InPower2();```

2- ```public Matrix Power2();```

```C#
Matrix a = new Matrix(4, 2);
// TODO: Fill in matrix a
// ...

// a = 1 / a
a.InOneOver();

// a.Hadamard(a)
a.InPower2();

// a = 1 - a
a.InOneMinus();

// a = 1 / 1
a.InOneOver();
```

#### Softmax

Calculates the softmax of the matrix.

1- ```public void InSoftmax();```

2- ```public Matrix Softmax();```

```C#
Matrix a = new Matrix(4, 2);
// TODO: Fill in matrix a
// ...

// Calculates the softmax(a) and stores the result in b
Matrix b = a.Softmax();

// Calculates the softmax(a) and stores the result in a
a.InSoftmax();
```

#### Merge and Split
>>>>>>> Stashed changes
>>>>>>> Stashed changes

You can easily merge two matrices into a single vector, or split a single vector into two separate matrices.

For Merge we have two methods 

##### Note: The mergeIndex param is a reference int that returns the merge point in the new vector

1- ```public void InMerge(Matrix matrix, out int mergeIndex);```

2- ```public Matrix Merge(Matrix matrix, out int mergeIndex);```

For Split we have one method

3- ```public List<Matrix> Split(int mergeIndex);```

```C#
Matrix a = new Matrix(10, 1);
Matrix b = new Matrix(5, 12);
// TODO: Fill in vector a
// ...

// Merge a and b into a flat vector and put them into c
Matrix c = a.Merge(b);

// Widens the vector a and stores the resulting matrix in a
List<Matrix> matrices = c.Split(15);
```

#### Dropout

You can perform a Dropout Function with a chance input

##### Note: Chance is automatically clamped between 0.0 and 1.0

1- ```public void InDropout(float chance);```

2- ```public Matrix Dropout(float chance);```

```C#
Matrix a = new Matrix(5, 10);
// TODO: Fill in matrix a
// ...

// Dropout on a with a 75% chance of each value being set to 0.0f
Matrix a.InDropout(0.75f);
```

### UTILITY FUNCTIONS

1- ```public Matrix Duplicate();```

Grabs a duplicate instance of the matrix
```C#
Matrix a = new Matrix(5, 10);
// TODO: Fill in matrix a
// ...

Matrix b = a.Duplicate();
```

2- ```public Matrix SubMatrix(int startX, int startY, uint dX, uint dY);```

Calculates the Submatrix of the current matrix and retuns it.

#### FUNCTION PARAMETERS

1- ```startX```: Starting location for Rows

2- ```startY```: Starting location for Columns

3- ```dX```: Distance to read in Rows starting from startX

4- ```dY```: Distance to read in Columns starting from startY

```C#
Matrix a = new Matrix(5, 5);
// TODO: Fill in matrix a
// ...

// Grabs the submatrix of a and stores it in matrix b
Matrix b = a.SubMatrix(1, 1, 3, 3)
```

3- ```public Nomad.Utility.Shape Shape()```

Grabs the shape of the Matrix
```C#
Matrix a = new Matrix(5, 5);
// TODO: Fill in matrix a
// ...

// Shape is (5, 5) of type Square Matrix
Shape s = a.Shape();
```

You can read more about the Shape class [here](https://github.com/void-intelligence/Nomad/blob/master/docs/Shape.md).

4- ```public Utility.EType Type()```

Grabs the type of the Matrix
```C#
Matrix a = new Matrix(10, 1);
// TODO: Fill in vector a
// ...

// In this case a vector
EType t = a.Type();
```


You can read more about the EType enum [here](https://github.com/void-intelligence/Nomad/blob/master/docs/EType.md).

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


## Operators.cs Methods

The following operators are overloaded for the matrix class.

1- Inverse: operator !

2- Add: operator +

3- Subtract: operator -

4- Dot: operator *

5- Scale: operator *

6- Equality: operator == and Equals() function

7- Not Equal: operator !=

8- Greater than: operator >

9- Less than: operator <

10- Greater than or equal to: operator >=

11- Less than or equal to: operator <=

12- Hash Code


## Transformation.cs Methods

Transformation holds certain methods for manipluation the matrix object in a 2D or 3D space

##### THE INPUT TO ROTATION FUNCTIONS IS IN UNIT OF DEGREES

1- ```Rotation2D(double angle)```

For rotating the matrix in 2D space

2- ```Rotation3DX(double angle)```

For rotating the matrix along X axis in 3D space

3- ```Rotation3DY(double angle)```

For rotating the matrix along Y axis in 3D space

4- ```Rotation3DZ(double angle)```

For rotating the matrix along Z axis in 3D space

5- ```Scaling(double factor)```

For scaling the matrix in a uniform manner in 3D space (Supports 2D)

6- ```Scaling(double factorX, double factorY, double factorZ)```

For scaling the matrix in a precise manner in 3D space (Supports 2D)

7- ```Translation(double moveX, double moveY, double moveZ)```

For moving the matrix in 3D Space (Supports 2D)

## Norm.cs Methods

This file contains the logic to calculate various norms of the matrix.

1- ```Maximum Norm```

2- ```Manhattan Norm```

3- ```Taxicab Norm```

4- ```P-Norm```

5- ```Euclidean / Frobenius Norm```

6- ```Absolute Norm```

7- ```IntegrateCustomNorm(Func<double, double func)```

Note that the only method here that is a different to the ones mentioned so far is the ```IntegrateCustomNorm```

This method will take a function as input, map it to the matrix and calculate the sum of the results

```C#
// Let's assume this is the function we want to map to our matrix object
public double HyperTan(double val) 
{
	return Math.Tanh(val * val);
}
```

And now we use it

```C#
Matrix a = new Matrix(10, 10);
a.InRandomize();

double result = a.IntegrateCustomNorm(HyperTan);

// Result will have the value of Cumsum(HyperTan(a))
```

[**Back To Index**](https://github.com/void-intelligence/Nomad/blob/master/docs/README.md)
