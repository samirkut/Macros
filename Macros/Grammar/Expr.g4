grammar Expr;

expr	
	:	LPAREN expr RPAREN									# Parens
	|	expr POINT VARIABLE									# Property
	|	expr L_SQUARE_BRACKET expr R_SQUARE_BRACKET			# Indexer 
	|	FUNCTION (expr (COMMA expr)*)? RPAREN		# Function
	|	op=(PLUS | MINUS) expr								# UnaryAddSub
	|	STRING												# String
	|	NUMBER												# Number
	|	VARIABLE											# Variable	
	|	expr POW expr										# Power
	|	expr op=(MUL | DIV) expr							# MulDiv
	|	expr op=(PLUS | MINUS) expr							# AddSub
	;

L_SQUARE_BRACKET
   : '['
   ;

R_SQUARE_BRACKET
   : ']'
   ;

LPAREN
   : '('
   ;

RPAREN
   : ')'
   ;

PLUS
   : '+'
   ;

MINUS
   : '-'
   ;

MUL
   : '*'
   ;

DIV
   : '/'
   ;

POW
   : '^'
   ;

COMMA
   : ','
   ;

POINT
   : '.'
   ;

fragment DOUBLE_QUOTE
   : '"'
   ;

fragment SINGLE_QUOTE
   : '\''
   ;

fragment UNDERSCORE
	: '_'
	;

fragment LETTER
   : ('a' .. 'z') | ('A' .. 'Z')
   ;

fragment DIGIT
   : ('0' .. '9')
   ;

//had to inline the double_quote and single_quote here since Antlr4 doesnt support using references for ~ operator
STRING
   : DOUBLE_QUOTE ~('"')* DOUBLE_QUOTE
   | SINGLE_QUOTE ~('\'')* SINGLE_QUOTE
   ;

NUMBER	
   : MINUS? DIGIT+ (POINT DIGIT+)?
   ;

VARIABLE
   : (UNDERSCORE | LETTER) (DIGIT | UNDERSCORE | LETTER)*
   ;

FUNCTION
	: (LETTER | UNDERSCORE) (DIGIT | UNDERSCORE | LETTER)* LPAREN
	;

WS
   : [ \r\n\t] + -> skip
   ;