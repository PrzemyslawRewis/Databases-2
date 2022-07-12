USE AdventureWorks;

SELECT * FROM Sales.Individual WHERE Demographics.value('declare default element namespace
"http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/IndividualSurvey";
(/IndividualSurvey/TotalChildren)[1]', 'integer') > 1;