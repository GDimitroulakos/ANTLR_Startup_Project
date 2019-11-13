using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR_Startup_Project {

    public class CASTIDENTIFIER : ASTComposite {
        public CASTIDENTIFIER(string idText, nodeType type, ASTElement parent, int numContexts) : base(idText, type,
            parent, numContexts) {
            m_nodeName = GenerateNodeName();
        }

        public override T Accept<T>(ASTBaseVisitor<T> visitor){
            return visitor.VisitIDENTIFIER(this);
        }
        public override string GenerateNodeName() {
            return "\"" + MNodeType + "_" + MSerial + "_(" + m_text + ")\"";
        }
    }

    public class CASTNUMBER : ASTComposite {
        private int m_value;
        public int Value => m_value;

        public CASTNUMBER(string numberText, nodeType type, ASTElement parent, int numContexts) : base(numberText, type,
            parent, numContexts) {
            m_value = Int32.Parse(numberText);
            m_nodeName = GenerateNodeName();
        }

        public override T Accept<T>(ASTBaseVisitor<T> visitor) {
            return visitor.VisitNUMBER(this);
        }

        public override string GenerateNodeName() {
            return "\"" + MNodeType + "_" + MSerial + "_("+ m_value + ")\"";
        }
    }

    public class CASTAddition : ASTComposite {
        public CASTAddition(string text, nodeType type, ASTElement parent, int numContexts) : base(text, type, parent, numContexts) { }

        public override T Accept<T>(ASTBaseVisitor<T> visitor) {
            return visitor.VisitAddition(this);
        }
    }

    public class CASTSubtraction : ASTComposite {
        public CASTSubtraction(string text, nodeType type, ASTElement parent, int numContexts) : base(text, type, parent, numContexts) { }

        public override T Accept<T>(ASTBaseVisitor<T> visitor) {
            return visitor.VisitSubtraction(this);
        }
    }

    public class CASTMultiplication : ASTComposite {
        public CASTMultiplication(string text, nodeType type, ASTElement parent, int numContexts) : base(text, type, parent, numContexts) { }

        public override T Accept<T>(ASTBaseVisitor<T> visitor) {
            return visitor.VisitMultiplication(this);
        }
    }
    public class CASTDivision : ASTComposite {
        public CASTDivision(string text, nodeType type, ASTElement parent, int numContexts) : base(text, type, parent, numContexts) { }

        public override T Accept<T>(ASTBaseVisitor<T> visitor) {
            return visitor.VisitDivision(this);
        }
    }
   public class CASTAssignment : ASTComposite {
       public CASTAssignment(string text, nodeType type, ASTElement parent, int numContexts) : base(text, type, parent, numContexts) { }

       public override T Accept<T>(ASTBaseVisitor<T> visitor) {
           return visitor.VisitAssignment(this);
       }
    }

   public class CASTCompileUnit : ASTComposite {
       public CASTCompileUnit(string text,nodeType type, ASTElement parent, int numContexts) : base(text, type, parent, numContexts) { }

       public override T Accept<T>(ASTBaseVisitor<T> visitor) {
           return visitor.VisitCompileUnit(this);
       }
    }
    
}
