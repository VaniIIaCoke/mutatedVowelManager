CREATE DATABASE DBPhonebook;

GO

USE DBPhonebook;

CREATE TABLE tbl_phonebook(
phonebookId INT NOT NULL IDENTITY(1,1),
last_name NVARCHAR(100) NOT NULL,

CONSTRAINT pk_phonebookId PRIMARY KEY (phonebookId)
);

INSERT INTO tbl_phonebook (last_name) VALUES ('KÖSTNER'), ('RÜßWURM'), ('DÜRMÜLLER'), ('JÄÄSKELÄINEN'), ('GROßSCHÄDL');