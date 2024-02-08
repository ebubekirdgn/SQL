SELECT Id,CreationDate,Text,
	(
	SELECT COUNT(*) FROM string_split(TEXT,' ')
	) WordCount,
	(
	SELECT COUNT(*) FROM string_split(TEXT,' ') where value like '%SQL%'
	) SQL_WordCount,
	(
	SELECT COUNT(*) FROM string_split(TEXT,' ') where value = 'SQL'
	) SQL_WordCount2
FROM LAB05 
ORDER BY Id 

