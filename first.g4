grammar first;

/*
 * Parser Rules
 */

compileUnit
	:	(expr ';')+			
	;

expr
	: NUMBER					#expr_NUMBER
	| IDENTIFIER				#expr_IDENTIFIER
	| expr op=('*'|'/') expr	#expr_MULDIV
	| expr op=('+'|'-') expr	#expr_PLUSMINUS
	| IDENTIFIER '=' expr		#expr_ASSIGNMENT
	| '(' expr ')'				#expr_PARENTHESIZED
	;

/*
 * Lexer Rules
 */

WS: [ \r\n\t]-> skip;
MULT : '*' ;
DIV : '/' ;
PLUS : '+';
MINUS : '-';
EQUAL : '=';
LP : '(';
RP : ')';
QMARK : ';';
IDENTIFIER : [a-zA-Z][a-zA-Z0-9_]*;
NUMBER 
		: '0' | [1-9] [0-9]*
		;
