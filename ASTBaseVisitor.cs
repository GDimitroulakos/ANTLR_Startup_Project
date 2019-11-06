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
        /*NT_COMPILEUNIT = 0,
        NT_ADDITION = 1,
        NT_SUBSTRACTION = 3,
        NT_MULTIPLICATION = 5,
        NT_DIVISION = 7,
        NT_ASSIGNMENT=9,
        NT_NUMBER=11 ,
        NT_IDENTIFIER=12 */
    }
}
