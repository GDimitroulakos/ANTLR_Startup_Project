using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;

namespace ANTLR_Startup_Project {
    public class ASTGenerator : firstBaseVisitor<int> {

        Stack<ASTElement> m_parents = new Stack<ASTElement>();

        public override int VisitExpr_MULDIV(firstParser.Expr_MULDIVContext context) {
            if (context.op.Type == firstParser.MULT) {
                CASTMultiplication newnode = new CASTMultiplication(nodeType.NT_MULTIPLICATION, m_parents.Peek(), 2);
                m_parents.Push(newnode);
            }
            else if (context.op.Type == firstParser.DIV) {
                CASTDivision newnode = new CASTDivision(nodeType.NT_DIVISION, m_parents.Peek(), 2);
                m_parents.Push(newnode);
            }
            base.VisitExpr_MULDIV(context);

           m_parents.Pop();
            return 0;
        }

        public override int VisitExpr_PLUSMINUS(firstParser.Expr_PLUSMINUSContext context) {

            if (context.op.Type == firstParser.MINUS) {
                CASTSubtraction newnode = new CASTSubtraction(nodeType.NT_SUBSTRACTION, m_parents.Peek(), 2);
                m_parents.Push(newnode);
            }
            else if (context.op.Type == firstParser.PLUS) {
                CASTAddition newnode = new CASTAddition(nodeType.NT_ADDITION, m_parents.Peek(), 2);
                m_parents.Push(newnode);
            }

            base.VisitExpr_PLUSMINUS(context);

            m_parents.Pop();
            return 0;
        }

        public override int VisitExpr_ASSIGNMENT(firstParser.Expr_ASSIGNMENTContext context) {
            CASTAssignment newnode = new CASTAssignment(nodeType.NT_ASSIGNMENT, m_parents.Peek(), 2);
            m_parents.Push(newnode);

            base.VisitExpr_ASSIGNMENT(context);

            m_parents.Pop();
            return 0;
        }

        public override int VisitCompileUnit(firstParser.CompileUnitContext context) {
            CASTAssignment newnode = new CASTAssignment(nodeType.NT_COMPILEUNIT, null, 1);
            m_parents.Push(newnode);

            base.VisitCompileUnit(context);

            m_parents.Pop();
            return 0;
        }

        public override int VisitTerminal(ITerminalNode node) {
            switch (node.Symbol.Type){
                case firstLexer.NUMBER:
                    CASTNUMBER newnode1 = new CASTNUMBER(nodeType.NT_NUMBER,m_parents.Peek(),0);
                    break;
                case firstLexer.IDENTIFIER:
                    CASTIDENTIFIER newnode2 = new CASTIDENTIFIER(nodeType.NT_IDENTIFIER, m_parents.Peek(), 0);
                    break;
                default:
                    break;
            }
            return base.VisitTerminal(node);
        }
    }
}
