SELECT LEFT(NAME_,1)+LEFT(SURNAME,1) BASHARF,COUNT(*) SAYI
	FROM LAB07
GROUP BY LEFT(NAME_,1),LEFT(SURNAME,1)
ORDER BY 1 


