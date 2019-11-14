using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR_Startup_Project {


        /*
        Θέλουμε να επεκτείνουμε την λειτουργικότητα της κλάσης AbstractParseTreeVisitor. έτσι:
            1) δημιουργούμε την στατική κλάση ANTLRVisitorExtensions
            2) Υλοποιούμε τις μεθόδους που θέλουμε να προσθέσουμε στην 
               λειτουργικότητα της αρχικής κλάσης, δηλώνοντάς τις ως static.
            3) Η πρώτη παράμετρος των μεθόδων αυτών πρέπει να είναι το this, 
               ακολουθούμενο απο τον τύπο της κλάσης που θέλουμε να επεκτείνουμε.

        Η παραπάνω κλάση δημιουργήθηκε με σκοπό να χρησιμοποιηθεί σε αντίστοιχο
        κώδικα, για οποιαδήποτε γραμματική. Εξού και υλοποιήθηκε ως generic.
         */


    public static class ANTLRVisitorExtensions {

        /// ###########################################################################|
        /// GetTerminalNode ###########################################################|
        /// ###########################################################################|
        /// Αυτή η μέδοδος κάνει ένα είδος casting στους τερματικούς κόμβους,       ###|
        /// προκειμένου να χρησιμοποιηθεί στην VisitTerminalInContext για να βρεί   ###|
        /// ποιος κόμβος του δεντρου αντιστοιχεί στο δωθεν token.                   ###|
        /// ###########################################################################|
        private static ITerminalNode GetTerminalNode<Result>(this AbstractParseTreeVisitor<Result> t,ParserRuleContext node, IToken terminal) {

            for (int i = 0; i < node.ChildCount; i++) {
                ITerminalNode child = node.GetChild(i) as ITerminalNode;
                if (child != null) {
                    if (child.Symbol == terminal) {
                        return child;
                    }
                }
            }
            return null;
        }

        /// ###########################################################################|
        /// VisitElementInContext #####################################################|
        /// ###########################################################################|
        /// Αυτή η μέδοδος επισκέπτεται έναν child κομβο, μεταφέροντας το context   ###|
        /// του parent κομβου στο οποίο ανοίκει                                     ###|
        /// ###########################################################################|
        public static Result VisitElementInContext<E, Result>(this AbstractParseTreeVisitor<Result> t,ParserRuleContext node,Stack<E> s,E context) where E : System.Enum {
            s.Push(context);
            Result res = t.Visit(node);
            s.Pop();
            return res;
        }
        
        /// ###########################################################################|
        /// VisitElementsInContext ####################################################|
        /// ###########################################################################|
        /// Αυτή η μέδοδος επισκέπτεται μια collection child κομβων, μεταφέροντας   ###|
        /// το context του parent κομβου στο οποίο ανοίκει καθε child               ###|
        /// ###########################################################################|
        public static Result VisitElementsInContext<E, Result>(this AbstractParseTreeVisitor<Result> t, IEnumerable<IParseTree> nodeset, Stack<E> s, E context) where E : System.Enum {
            Result res=default(Result);
            s.Push(context);
            foreach (IParseTree node in nodeset) {
                 res = t.Visit(node);
            }
            s.Pop();
            return res;
        }
        
        /// ###########################################################################|
        /// VisitTerminalInContext ####################################################|
        /// ###########################################################################|
        /// Αυτή η μέδοδος επισκέπτεται έναν terminal κομβο, μεταφέροντας το        ###|
        /// context του parent κομβου στο οποίο ανοίκει                             ###|
        /// ###########################################################################|
        public static Result VisitTerminalInContext<E, Result>(this AbstractParseTreeVisitor<Result> t,ParserRuleContext tokenParent, IToken node, Stack<E> s, E context) where E : System.Enum {
            s.Push(context);
            Result res = t.Visit(GetTerminalNode<Result>(t,tokenParent,node));
            s.Pop();
            return res;
        }

    }
}
