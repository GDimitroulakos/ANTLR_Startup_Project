6/11/2019  
Partial Implemented Step 13
1) ASTElement 			: We have added an public abstract Generic Accept method into the ASTElement
2) ASTElementConcrete 	: We have added the Accept implementation for the CASTIDENTIFIER node
							HOMEWORK : Do the same for the others
3) ASTBaseVisitor 		:1) We have added a Visit<Type> method for each type of AST Node described in the	
							public enum nodeType in the ASTElement.cs
							HOMEWORK : Do the same for the others
						 2) We have added a VisitChildren() method into  ASTBaseVisitor class

