SELECT DISTINCT Categories.CategLabel, Categories.idCategory, LangCateg.idIT from LangCateg
JOIN DevLang
ON Devlang.idIT = LangCateg.idIT
JOIN Categories
ON Categories.idCategory = LangCateg.idCategory
WHERE idDev = 2