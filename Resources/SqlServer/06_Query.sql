-- QUERY
SELECT p.Id, p.Name, p.Birthday, hi.Name AS HealthInsurance
FROM Person p
JOIN Person_Health_Insurance phi 
ON phi.PersonId = p.Id 
JOIN Health_Insurance hi
ON phi.HealthInsuranceId = hi.Id 
WHERE hi.Name = 'Optima';