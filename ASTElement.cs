using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR_Startup_Project
{
    //##############################################################################
    // Type Definitions ############################################################
    //##############################################################################
    public enum nodeType
    {
        NA = -1,
        NT_COMPILEUNIT = 0,
        NT_ADDITION = 1,
        NT_SUBTRACTION = 3,
        NT_MULTIPLICATION = 5,
        NT_DIVISION = 7,
        NT_NUMBER = 9
    }; // Check first.g4 for all the different node types

    public enum contextType
    {
        NA = -1,
        CT_COMPILEUNIT_EXPRESSIONS, // = 0 (0 - 0 = 0)
        CT_ADDITION_LEFT,           // = 1 (1 - 1 = 0)
        CT_ADDITION_RIGHT,          // = 2 (2 - 1 = 1)
        CT_SUBTRACTION_LEFT,        // = 3 (3 - 3 = 0)
        CT_SUBTRACTION_RIGHT,       // = 4 (4 - 3 = 1)
        CT_MULTIPLICATION_LEFT,     // = 5 (5 - 5 = 0)
        CT_MULTIPLICATION_RIGHT,    // = 6 (6 - 5 = 1)
        CT_DIVISION_LEFT,           // = 7 (7 - 7 = 0)
        CT_DIVISION_RIGHT           // = 8 (8 - 7 = 1)
    }; // Check first.g4 for all the different node type definitions

    public abstract class ASTElement {
        ////////////////////////////////////////////////////////////////////////////
        // Basic Fields ////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////

        private int m_serial;
        private static int ms_serialCounter = 0;
        private nodeType m_nodeType;
        private ASTElement m_parent;
        private string m_nodeName;

        ////////////////////////////////////////////////////////////////////////////
        // Methods /////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////

        public virtual string GenerateNodeName()
        {
            /*  Generate unique name for each node.
                    This is neccessary in order to override it on child classes,
                    so we can generate custom names that fit their needs.*/

            return "_" + m_serial;
        }

        ////////////////////////////////////////////////////////////////////////////
        // Properties //////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////

        /*
        
        Typography

            public %type% %name% => %local_private_variable%;

        equals

            public %type% %name%
            {
                get
                {
                    return %local_private_variable%;
                }
                set
                {
                    %local_private_variable% = value;
                }
            }

        */

        public nodeType MNodeType => m_nodeType;

        public ASTElement MParent {
            get { return m_parent; }
        }

        public string MNodeName => m_nodeName;

        ////////////////////////////////////////////////////////////////////////////
        // Constructor /////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////

        protected ASTElement(nodeType type, ASTElement parent)
        {
            m_nodeType = type;
            m_parent = parent;
            m_serial = ms_serialCounter++;
            m_nodeName = GenerateNodeName();
        }
    }


    //##############################################################################
    // Composite AST Element #######################################################
    //##############################################################################
    public abstract class ASTComposite : ASTElement {
        private List<ASTElement>[] m_children;


        ////////////////////////////////////////////////////////////////////////////
        // Constructor /////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////

        protected ASTComposite(nodeType type, ASTElement parent, int numContexts) : base(type, parent) {
            m_children = new List<ASTElement>[numContexts];
        }


        ////////////////////////////////////////////////////////////////////////////
        // Child Methods ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////

        protected int GetContextIndex(contextType ct) {
            return (int)ct - (int)MNodeType;
        }

        protected void AddChild(ASTElement child, contextType ct) {
            int index = GetContextIndex(ct);
            m_children[index].Add(child);
        }

        protected ASTElement GetChild(contextType ct, int index) {
            int i = GetContextIndex(ct);
            return m_children[i][index];
        }
    }

    //##############################################################################
    // Terminal AST Element ########################################################
    //##############################################################################

    public abstract class ASTTerminal : ASTElement {

        ////////////////////////////////////////////////////////////////////////////
        // Constructor /////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////
        protected ASTTerminal(nodeType type, ASTElement parent) : base(type, parent)
        {
            // TODO: Add the construction procedure
        }

    }
}
