using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;

namespace ANTLR_Startup_Project {
    public class ASTGenerator : firstBaseVisitor<int> {
        private ASTComposite m_root;

        Stack<ASTComposite> m_parents = new Stack<ASTComposite>();

        Stack<contextType> m_parentContext = new Stack<contextType>();
        

        public override int VisitExpr_MULDIV(firstParser.Expr_MULDIVContext context) {
            ASTComposite m_parent = m_parents.Peek();
            if (context.op.Type == firstParser.MULT) {
                CASTMultiplication newnode = new CASTMultiplication(nodeType.NT_MULTIPLICATION, m_parents.Peek(), 2);
                m_parent.AddChild(newnode,m_parentContext.Peek());
                m_parents.Push(newnode);

                this.VisitElementInContext(context.expr(0), m_parentContext, contextType.CT_MULTIPLICATION_LEFT);
                this.VisitElementInContext(context.expr(1), m_parentContext, contextType.CT_MULTIPLICATION_RIGHT);
            }
            else if (context.op.Type == firstParser.DIV) {
                CASTDivision newnode = new CASTDivision(nodeType.NT_DIVISION, m_parents.Peek(), 2);
                m_parent.AddChild(newnode, m_parentContext.Peek());
                m_parents.Push(newnode);

                this.VisitElementInContext(context.expr(0), m_parentContext, contextType.CT_DIVISION_LEFT);
                this.VisitElementInContext(context.expr(1), m_parentContext, contextType.CT_DIVISION_RIGHT);
            }

           m_parents.Pop();
            return 0;
        }

        public override int VisitExpr_PLUSMINUS(firstParser.Expr_PLUSMINUSContext context) {
            ASTComposite m_parent = m_parents.Peek();
            if (context.op.Type == firstParser.MINUS) {
                CASTSubtraction newnode = new CASTSubtraction(nodeType.NT_SUBSTRACTION, m_parents.Peek(), 2);
                m_parent.AddChild(newnode, m_parentContext.Peek());
                m_parents.Push(newnode);

                this.VisitElementInContext(context.expr(0), m_parentContext, contextType.CT_SUBSTRACTION_LEFT);
                this.VisitElementInContext(context.expr(1), m_parentContext, contextType.CT_SUBSTRACTION_RIGHT);
            }
            else if (context.op.Type == firstParser.PLUS) {
                CASTAddition newnode = new CASTAddition(nodeType.NT_ADDITION, m_parents.Peek(), 2);
                m_parent.AddChild(newnode, m_parentContext.Peek());
                m_parents.Push(newnode);

                this.VisitElementInContext(context.expr(0), m_parentContext, contextType.CT_ADDITION_LEFT);
                this.VisitElementInContext(context.expr(1), m_parentContext, contextType.CT_ADDITION_RIGHT);
            }

            m_parents.Pop();
            return 0;
        }

        public override int VisitExpr_ASSIGNMENT(firstParser.Expr_ASSIGNMENTContext context) {
            ASTComposite m_parent = m_parents.Peek();
            CASTAssignment newnode = new CASTAssignment(nodeType.NT_ASSIGNMENT, m_parents.Peek(), 2);
            m_parent.AddChild(newnode, m_parentContext.Peek());
            m_parents.Push(newnode);

            this.VisitTerminalInContext(context,context.IDENTIFIER().Symbol, m_parentContext, contextType.CT_ASSIGNMENT_LEFT);
            this.VisitElementInContext(context.expr(), m_parentContext, contextType.CT_ASSIGNMENT_RIGHT);

            m_parents.Pop();
            return 0;
        }

        public override int VisitCompileUnit(firstParser.CompileUnitContext context) {
            CASTAssignment newnode = new CASTAssignment(nodeType.NT_COMPILEUNIT, null, 1);
            m_root = newnode;
            m_parents.Push(newnode);

            this.VisitElementsInContext(context.expr(), m_parentContext, contextType.CT_COMPILEUNIT_EXPRESSIONS);

            m_parents.Pop();
            return 0;
        }

        public override int VisitTerminal(ITerminalNode node) {
            ASTComposite m_parent = m_parents.Peek();
            switch (node.Symbol.Type){
                case firstLexer.NUMBER:
                    CASTNUMBER newnode1 = new CASTNUMBER(nodeType.NT_NUMBER,m_parents.Peek(),0);
                    m_parent.AddChild(newnode1,m_parentContext.Peek());
                    break;
                case firstLexer.IDENTIFIER:
                    CASTIDENTIFIER newnode2 = new CASTIDENTIFIER(nodeType.NT_IDENTIFIER, m_parents.Peek(), 0);
                    m_parent.AddChild(newnode2, m_parentContext.Peek());
                    break;
                default:
                    break;
            }
            return base.VisitTerminal(node);
        }
    }
}
