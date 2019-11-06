using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace ANTLR_Startup_Project {
    class GraphvizPrinterVisitor : firstBaseVisitor<int> {
        private Stack<string> m_labels = new Stack<string>();
        private StreamWriter outFile;
        private static int ms_serialCounter = 0;

        public GraphvizPrinterVisitor() {
            outFile = new StreamWriter("test.dot");
        }

        public override int VisitCompileUnit([NotNull] firstParser.CompileUnitContext context) {
            int serial = ms_serialCounter++;
            string s = "CompileUnit_"+serial;
            m_labels.Push(s);
            
            outFile.WriteLine("digraph G{");


            base.VisitChildren(context);

            outFile.WriteLine("}");
            m_labels.Pop();
            outFile.Close();

            // Prepare the process dot to run
            ProcessStartInfo start = new ProcessStartInfo();
            // Enter in the command line arguments, everything you would enter after the executable name itself
            start.Arguments = "-Tgif " +
                              Path.GetFileName("test.dot") + " -o " +
                              Path.GetFileNameWithoutExtension("test") + ".gif";
            // Enter the executable to run, including the complete path
            start.FileName = "dot";
            // Do you want to show a console window?
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;
            int exitCode;

            // Run the external process & wait for it to finish
            using (Process proc = Process.Start(start)) {
                proc.WaitForExit();

                // Retrieve the app's exit code
                exitCode = proc.ExitCode;
            }
            return 0;
        }

        /*public override int VisitExpr([NotNull] firstParser.ExprContext context) {

            int serial = ms_serialCounter++;
            string s = "Expr_" + serial;
            // Preorder action
            outFile.WriteLine("\"{0}\"->\"{1}\";", m_labels.Peek(), s);

            m_labels.Push(s);

            base.VisitChildren(context);

            m_labels.Pop();
            return 0;
        }*/

        public override int VisitExpr_MULDIV(firstParser.Expr_MULDIVContext context)
        {
            int serial = ms_serialCounter++;
            string s="";
            switch (context.op.Type)
            {
                case firstParser.MULT:
                    s = "Mult_" + serial;
                    // Preorder action
                    outFile.WriteLine("\"{0}\"->\"{1}\";", m_labels.Peek(), s);
                    break;
                case firstParser.DIV:
                    s = "Div_" + serial;
                    // Preorder action
                    outFile.WriteLine("\"{0}\"->\"{1}\";", m_labels.Peek(), s);
                    break;
                default:
                    break;
            }
           
            m_labels.Push(s);

            base.VisitChildren(context);

            m_labels.Pop();
            return 0;
        }

        public override int VisitExpr_PLUSMINUS(firstParser.Expr_PLUSMINUSContext context){
            int serial = ms_serialCounter++;
            string s = "";
            switch (context.op.Type) {
                case firstParser.PLUS:
                    s = "Plus_" + serial;
                    // Preorder action
                    outFile.WriteLine("\"{0}\"->\"{1}\";", m_labels.Peek(), s);
                    break;
                case firstParser.MINUS:
                    s = "Minus_" + serial;
                    // Preorder action
                    outFile.WriteLine("\"{0}\"->\"{1}\";", m_labels.Peek(), s);
                    break;
                default:
                    break;
            }
           
            m_labels.Push(s);

            base.VisitChildren(context);

            m_labels.Pop();
            return 0;
        }

        public override int VisitExpr_ASSIGNMENT(firstParser.Expr_ASSIGNMENTContext context)
        {
            int serial = ms_serialCounter++;
            string s = "Assign_" + serial;
            // Preorder action
            outFile.WriteLine("\"{0}\"->\"{1}\";", m_labels.Peek(), s);

            m_labels.Push(s);

            base.VisitChildren(context);

            m_labels.Pop();
            return 0;
        }

        public override int VisitTerminal(ITerminalNode node){

            int serial = ms_serialCounter++;
            string s = "";
            switch (node.Symbol.Type) {
                case firstLexer.NUMBER:
                    s = "NUMBER_" + serial;
                    // Preorder action
                    outFile.WriteLine("\"{0}\"->\"{1}\";", m_labels.Peek(), s);
                    break;
                case firstLexer.IDENTIFIER:
                    s = "IDENTIFIER_" + serial;
                    // Preorder action
                    outFile.WriteLine("\"{0}\"->\"{1}\";", m_labels.Peek(), s);
                    break;
                default:
                    break;
            }
           
           return base.VisitTerminal(node);
        }
    }
}
