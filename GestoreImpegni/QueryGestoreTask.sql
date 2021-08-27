
--CREATE
INSERT INTO Task VALUES('Studiare', 'Capitolo 4 di Analisi 2', '2021-09-30', 1, 0);

--READ
SELECT *
FROM Task;

--UPDATE
UPDATE Task
SET Descrizione = 'Capitolo 3 di Analisi 2'
WHERE Id = 4;

--DELETE
DELETE FROM Task WHERE Id = 11;

--Visualizzare gli impegni con data maggiore o uguale a quella inserita
SELECT *
FROM Task
WHERE DataScadenza>= CURRENT_TIMESTAMP
ORDER BY  DataScadenza ASC

--Visualizzare gli impegni del livello di importanza inserito
SELECT *
FROM Task
WHERE Importanza = 3;

--Visualizzare gli impegni portati a termine
SELECT *
FROM Task
WHERE Terminato = 1;

--Impostare un impegno come terminato
UPDATE Task
SET Terminato = 1
WHERE Id = 3;
