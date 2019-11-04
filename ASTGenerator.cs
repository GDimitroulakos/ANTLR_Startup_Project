using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;

namespace ANTLR_Startup_Project {
    class ASTGenerator : firstBaseVisitor<int> {

        Stack<ASTElement> m_parents = new Stack<ASTElement>();

        public override int VisitExpr_MULDIV(firstParser.Expr_MULDIVContext context) {
            return base.VisitExpr_MULDIV(context);
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
            CASTAssignment newnode = new CASTAssignment(nodeType.NT_ASSIGNMENT,m_parents.Peek(),2);
            m_parents.Push(newnode);

            base.VisitExpr_ASSIGNMENT(context);
            
            m_parents.Pop();
            return 0;
        }

        public override int VisitCompileUnit(firstParser.CompileUnitContext context) {
            CASTAssignment newnode = new CASTAssignment(nodeType.NT_COMPILEUNIT, m_parents.Peek(), 1);
            m_parents.Push(newnode);

            base.VisitCompileUnit(context);

            m_parents.Pop();
            return 0;
        }

        public override int VisitTerminal(ITerminalNode node) {
            return base.VisitTerminal(node);
        }
    }
}
