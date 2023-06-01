SELECT 
DB_NAME(database_id),
*
FROM sys.dm_exec_procedure_stats

WHERE DB_NAME(database_id)='HR'