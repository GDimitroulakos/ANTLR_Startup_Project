grammar first;

/*
 * Parser Rules
 */

compileUnit
	:	(expr ';')+
	;

expr
	: NUMBER 
	| expr '+' expr
	;

/*
 * Lexer Rules
 */

WS
	:	' ' -> skip
	;

NUMBER 
		: '0' | [1-9] [0-9]*
		;
