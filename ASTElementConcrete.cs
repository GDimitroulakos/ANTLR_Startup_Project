using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR_Startup_Project {

    public class CASTIDENTIFIER : ASTComposite {
        public CASTIDENTIFIER(nodeType type, ASTElement parent, int numContexts) : base(type, parent, numContexts) { }

        public override T Accept<T>(ASTBaseVisitor<T> visitor){
            return visitor.VisitIDENTIFIER(this);
        }
    }

    public class CASTNUMBER : ASTComposite {
        public CASTNUMBER(nodeType type, ASTElement parent, int numContexts) : base(type, parent, numContexts) { }
    }
    public class CASTAddition : ASTComposite {
        public CASTAddition(nodeType type, ASTElement parent, int numContexts) : base(type, parent, numContexts) { }
    }

    public class CASTSubtraction : ASTComposite {
        public CASTSubtraction(nodeType type, ASTElement parent, int numContexts) : base(type, parent, numContexts) { }
    }

    public class CASTMultiplication : ASTComposite {
        public CASTMultiplication(nodeType type, ASTElement parent, int numContexts) : base(type, parent, numContexts) { }
    }
    public class CASTDivision : ASTComposite {
        public CASTDivision(nodeType type, ASTElement parent, int numContexts) : base(type, parent, numContexts) { }
    }
   public class CASTAssignment : ASTComposite {
       public CASTAssignment(nodeType type, ASTElement parent, int numContexts) : base(type, parent, numContexts) { }
   }

   public class CASTCompileUnit : ASTComposite {
       public CASTCompileUnit(nodeType type, ASTElement parent, int numContexts) : base(type, parent, numContexts) { }
   }

    
}
