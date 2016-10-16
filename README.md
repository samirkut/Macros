# Macros

This is a simple library to parse expressions and evaluate them. A typical use case would be to provide a macro like functionality in an application.

For example, the following code sample will generate a result of 15
~~~~
var runner = new Runner();
runner.Scope.SetVariable(x, 5);

var parsedExpr = runner.Parse("x+10");
var result = runner.Evaluate(parsedExpr);
~~~~ 