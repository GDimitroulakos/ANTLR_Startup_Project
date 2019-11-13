using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR_Startup_Project
{
    class Program
    {
        static void Main(string[] args) {
            StreamReader astream = new StreamReader("test.txt");

            AntlrInputStream antlrStream = new AntlrInputStream(astream);

            firstLexer lexer = new firstLexer(antlrStream);

            CommonTokenStream tokens = new CommonTokenStream(lexer);

            firstParser parser = new firstParser(tokens);

            IParseTree tree =parser.compileUnit();

            GraphvizPrinterVisitor ptPrinter = new GraphvizPrinterVisitor();
            ptPrinter.Visit(tree);

            ASTGenerator astGenerator = new ASTGenerator();
            astGenerator.Visit(tree);

            ASTPrinter astPrinter = new ASTPrinter("test.dot");
            astPrinter.Visit(astGenerator.M_Root);

            ASTGenerator astGenerator = new ASTGenerator();
            astGenerator.Visit(tree);

            Console.WriteLine(tree.ToStringTree());

        }
    }
}
