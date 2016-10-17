
[![Build status](https://ci.appveyor.com/api/projects/status/7tanl6yqn5ddnq4h/branch/master?svg=true)](https://ci.appveyor.com/project/samirkut/macros/branch/master)


## Macros

This is a simple library to parse expressions and evaluate them. A typical use case would be to provide a macro like functionality in an application.

### Installation

The easiest way is to install via Nuget. Check out [Nuget](https://www.nuget.org/packages/Macros/) for more details on how to do this.

### Examples

For example, the following code sample will generate a result of 15
~~~~
var runner = new Runner();
runner.Scope.SetVariable(x, 5);

var result = runner.Evaluate("x+10");
~~~~ 

There is also support for custom functions.

