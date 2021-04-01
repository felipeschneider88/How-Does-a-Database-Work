using System;

namespace simpleDBMS.Compiler
{
    class Program
    {
     

        public static void print_promt(string _content)
        {
            Console.WriteLine("db > " + _content);
        }

        //prepare_statement (our “SQL Compiler”) does not understand SQL right now. 
        //In fact, it only understands two words INSERT and SELECT
        public static void prepare_statement(Statement _statement)
        {
            _statement.prepareResult = PrepareResult.PREPARE_SUCCESS;
            if (_statement.queryText.StartsWith("insert") == true)
            {
                _statement.statementType = StatementType.STATEMENT_INSERT;
            }
            else if (_statement.queryText.StartsWith("select") == true)
            {
                _statement.statementType = StatementType.STATEMENT_SELECT;
            }
            else
            {
                _statement.prepareResult = PrepareResult.PREPARE_UNRECOGNIZED_STATEMENT;
            }
        }
        public static void execute_statement(Statement _statement)
        {
            switch(_statement.statementType)
            {
                case (StatementType.STATEMENT_INSERT):
                    print_promt("This is where we would do an insert.");
                    break;
                case (StatementType.STATEMENT_SELECT):
                    print_promt("This is where we would do a select.");
                    break;

            }
        }

        //do_meta_command is just a wrapper for existing functionality that leaves room for more commands
        private static MetaCommandResult do_meta_comand(string inputBuffer)
        {
            if (String.Compare(inputBuffer, ".exit") == 0)
            {
                return MetaCommandResult.META_COMMAND_EXIT;
            }
            else
            {
                return MetaCommandResult.META_COMMAND_UNRECOGNIZED_COMMAND;
            }
        }
        static void Main(string[] args)
        {
            MetaCommandResult metaCommandResult = MetaCommandResult.META_COMMAND_RUN;
            string inputBuffer = null;
            while (metaCommandResult != MetaCommandResult.META_COMMAND_EXIT)
            {
                print_promt("");
                inputBuffer = Console.ReadLine();
                if (inputBuffer[0].Equals('.'))
                {
                    switch (do_meta_comand(inputBuffer))
                    {
                        case MetaCommandResult.META_COMMAND_EXIT:
                            metaCommandResult = MetaCommandResult.META_COMMAND_EXIT;
                            break;
                        case MetaCommandResult.META_COMMAND_SUCCESS:
                            continue;
                        case
                            MetaCommandResult.META_COMMAND_UNRECOGNIZED_COMMAND:
                            print_promt("Unrecognized keyword at start of " + inputBuffer);
                            continue;
                    }
                }
                else
                {
                    Statement newStatement = new Statement(inputBuffer);
                    prepare_statement(newStatement);
                    switch (newStatement.prepareResult)
                    {
                        case PrepareResult.PREPARE_SUCCESS:
                            execute_statement(newStatement);
                            print_promt("Executed.");
                            break;
                        case PrepareResult.PREPARE_UNRECOGNIZED_STATEMENT:
                            print_promt("Unrecognized keyword at start of " + inputBuffer);
                            break;
                    }
                }

            }
            Environment.Exit(-1);
        }
    }
}
