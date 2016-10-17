
![Build Status](https://travis-ci.org/samirkut/Macros.svg?branch=master "Travis Build Status")

## Macros

This is a simple library to parse expressions and evaluate them. A typical use case would be to provide a macro like functionality in an application.

For example, the following code sample will generate a result of 15
~~~~
var runner = new Runner();
runner.Scope.SetVariable(x, 5);

var result = runner.Evaluate("x+10");
~~~~ 

There is also support for custom functions.

