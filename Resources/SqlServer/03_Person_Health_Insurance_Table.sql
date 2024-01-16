CREATE TABLE Person_Health_Insurance (
  	PersonId INT NOT NULL,
  	HealthInsuranceId INT NOT NULL,
  	CONSTRAINT PK_Person_Health_Insurance PRIMARY KEY (PersonId, HealthInsuranceId),
  	CONSTRAINT FK_Person FOREIGN KEY(PersonId) REFERENCES Person(Id),
  	CONSTRAINT FK_Health_Insurance FOREIGN KEY(HealthInsuranceId) REFERENCES Health_Insurance(Id)
);
