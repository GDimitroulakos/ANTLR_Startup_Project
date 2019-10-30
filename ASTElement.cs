using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR_Startup_Project {
    public enum nodeType { NA = -1 };
    public abstract class ASTElement {
        private int m_serial;
        private static int ms_serialCounter = 0;
        private nodeType m_nodeType;
        private ASTElement m_parent;
        private string m_nodeName;

        public nodeType MNodeType => m_nodeType;

        public virtual string GenerateNodeName() {
            return "_" + m_serial;
        }

        public ASTElement MParent {
            get { return m_parent; }
        }

        public string MNodeName => m_nodeName;

        protected ASTElement(nodeType type, ASTElement parent) {
            m_nodeType = type;
            m_parent = parent;
            m_serial = ms_serialCounter++;
            m_nodeName = GenerateNodeName();
        }
    }
}
