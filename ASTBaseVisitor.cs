using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR_Startup_Project {
    public abstract class ASTBaseVisitor<T> {

        public T VisitChildren(ASTComposite node)
        {
            for (int i = 0; i < node.MChildren.Length; i++){
                foreach (ASTElement item in node.MChildren[i]){
                    item.Accept(this);
                }
            }
            return default(T);
        }

        public virtual T VisitCompileUnit(CASTCompileUnit node)
        {
            VisitChildren(node);
            return default(T);
        }

        public virtual T VisitIDENTIFIER(CASTIDENTIFIER node) {
            VisitChildren(node);
            return default(T);
        }

        public virtual T VisitNUMBER(CASTNUMBER node) {
            VisitChildren(node);
            return default(T);
        }

        public virtual T VisitCOMPILEUNIT(CASTCompileUnit node) {
            VisitChildren(node);
            return default(T);
        }

        public virtual T VisitAddition(CASTAddition node) {
            VisitChildren(node);
            return default(T);
        }

        public virtual T VisitSubtraction(CASTSubtraction node) {
            VisitChildren(node);
            return default(T);
        }

        public virtual T VisitMultiplication(CASTMultiplication node) {
            VisitChildren(node);
            return default(T);
        }


        public virtual T VisitDivision(CASTDivision node) {
            VisitChildren(node);
            return default(T);
        }

        public virtual T VisitAssignment(CASTAssignment node) {
            VisitChildren(node);
            return default(T);
        }
    }
}
