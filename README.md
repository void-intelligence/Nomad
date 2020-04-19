# NOMAD [![Void-Intelligence](https://circleci.com/gh/void-intelligence/Nomad.svg?style=shield)](https://app.circleci.com/pipelines/github/void-intelligence/Nomad)

<p align="center">
  <img src="https://github.com/void-intelligence/Nomad/blob/master/resources/Nomad.png" alt="Nomad Logo" width="920" height="343">
</p>

Welcome To **Nomad**, A lightweight Matrix manipulation library currently under development.

Nomad's Matrix class supports a variaty of different functions such as **Norm Calculation**, **Dot Product**, **Inverse Calculation**, **Transpose Operation**, **Function Mapping**, **Random Initialization**, **Reshape Operation**, **Vector Broadcasting**, **Uniform and Gaussian Random Distribution**, etc...

You can find the full list of all the capabilities in the [matrix class documentation page](https://github.com/void-intelligence/Nomad/blob/master/docs/Matrix.md).

## Documentation
 
The full API Documentation explaination on all aspects of the library, you can check it out [**here**](https://github.com/void-intelligence/Nomad/blob/master/docs/README.md).

## Quickstart

The quickstart guide will get you up and running with the nomad library in no time.

```
PM> Install-Package VI-Nomad -Version 1.0.0
```

```C#
using System;
using Nomad.Matrix;
using Nomad.Utility;

namespace Sample
{
    public class Program
    {
        public static void Main()
        {
            // Create a matrix of size 5 (rows) and 10 (columns)
            Matrix mat = new Matrix(5, 10);

            // Randomly Initialize the values of your matrix with Gaussian Distribution 
            // Gaussian Dispersion will be ((high - low) / 2)
            mat.InRandomize(0.0, 1.0, EDistribution.Gaussian);

            // Transpose the Matrix mat and put it in matT
            Matrix matT = mat.T();

            // Calculate the dot product between the two matrices mat and matT and store the result in product
            Matrix product = mat * matT;

            // Flatten the product matrix inplace
            product.InFlatten();

            // Make sure the matrix has been transformed into a vector as expected
            Console.WriteLine(product.Type().ToString());

            // Transpose the vector inplace so it will print in 1 line
            product.InTranspose();

            // Convert the product vector into a string
            string str = product.ToString();

            // Print the product Vector
            Console.WriteLine(str);

            // End the program
            return;
        }
    }
}
```
