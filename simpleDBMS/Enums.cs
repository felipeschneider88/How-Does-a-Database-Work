public enum MetaCommandResult
{
    META_COMMAND_RUN,
    META_COMMAND_EXIT,
    META_COMMAND_SUCCESS,
    META_COMMAND_UNRECOGNIZED_COMMAND
}

public enum PrepareResult
{
    PREPARE_SUCCESS,
    PREPARE_UNRECOGNIZED_STATEMENT
}

//Vamos a definir por ahora una sentencia para insertar y otra para elegir
public enum StatementType
{
    STATEMENT_INSERT,
    STATEMENT_SELECT
}