s-- ADD DATA
INSERT INTO Person (Name, Birthday) VALUES('Adrian De Oleo', '1991-08-08');
INSERT INTO Person (Name, Birthday) VALUES('Juan Trigo', '2003-07-27');
INSERT INTO Person (Name, Birthday) VALUES('Lourdes Contreras', '1980-05-16');
INSERT INTO Person (Name, Birthday) VALUES('Manolo Henriquez', '1998-01-20');
INSERT INTO Person (Name, Birthday) VALUES('Julian Suarez', '2003-07-02');

INSERT INTO Health_Insurance (Name, Description) VALUES('Optima', 'The best Health Insurance in the world');
INSERT INTO Health_Insurance (Name, Description) VALUES('Normal', 'A good Health Insurance');
INSERT INTO Health_Insurance (Name, Description) VALUES('LowCost', 'A basic Health Insurance');

INSERT INTO Person_Health_Insurance (PersonId, HealthInsuranceId) VALUES(1, 1);
INSERT INTO Person_Health_Insurance (PersonId, HealthInsuranceId) VALUES(2, 1);
INSERT INTO Person_Health_Insurance (PersonId, HealthInsuranceId) VALUES(3, 2);
INSERT INTO Person_Health_Insurance (PersonId, HealthInsuranceId) VALUES(4, 3);
INSERT INTO Person_Health_Insurance (PersonId, HealthInsuranceId) VALUES(5, 1);
