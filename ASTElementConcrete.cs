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

        public override T Accept<T>(ASTBaseVisitor<T> visitor)
        {
            return visitor.VisitNUMBER(this);
            // DONE!
        }
    }
    public class CASTAddition : ASTComposite {
        public CASTAddition(nodeType type, ASTElement parent, int numContexts) : base(type, parent, numContexts) { }

        public override T Accept<T>(ASTBaseVisitor<T> visitor)
        {
            return visitor.VisitAddition(this);
            // DONE!
        }
    }

    public class CASTSubtraction : ASTComposite {
        public CASTSubtraction(nodeType type, ASTElement parent, int numContexts) : base(type, parent, numContexts) { }

        public override T Accept<T>(ASTBaseVisitor<T> visitor)
        {
            return visitor.VisitSubtraction(this);
            // DONE!
        }
    }

    public class CASTMultiplication : ASTComposite {
        public CASTMultiplication(nodeType type, ASTElement parent, int numContexts) : base(type, parent, numContexts) { }

        public override T Accept<T>(ASTBaseVisitor<T> visitor)
        {
            return visitor.VisitMultiplication(this);
            // DONE!
        }
    }
    public class CASTDivision : ASTComposite {
        public CASTDivision(nodeType type, ASTElement parent, int numContexts) : base(type, parent, numContexts) { }

        public override T Accept<T>(ASTBaseVisitor<T> visitor)
        {
            return visitor.VisitDivision(this);
            // DONE!
        }
    }
   public class CASTAssignment : ASTComposite {
       public CASTAssignment(nodeType type, ASTElement parent, int numContexts) : base(type, parent, numContexts) { }

        public override T Accept<T>(ASTBaseVisitor<T> visitor)
        {
            return visitor.VisitAssignment(this);
            // DONE!
        }
    }

   public class CASTCompileUnit : ASTComposite {
       public CASTCompileUnit(nodeType type, ASTElement parent, int numContexts) : base(type, parent, numContexts) { }

        public override T Accept<T>(ASTBaseVisitor<T> visitor)
        {
            return visitor.VisitCompileUnit(this);
            // DONE!
        }
    }

    
}
