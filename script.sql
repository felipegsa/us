-- CRIA��O DAS TABELAS (BANCO UNI_SW) 12-09-12


CREATE TABLE TIPO_USUARIO
(
 ID_TIPO_USUARIO SERIAL NOT NULL,
 DS_TIPO_USUARIO VARCHAR(50) NOT NULL,
 DT_CADASTRO TIMESTAMP WITHOUT TIME ZONE NOT NULL
);

ALTER TABLE TIPO_USUARIO
ADD CONSTRAINT PK_TIPO_USUARIO
PRIMARY KEY (ID_TIPO_USUARIO);

----------------------------------------------------------------------

CREATE TABLE USUARIO
(
 ID_USUARIO SERIAL NOT NULL,
 ID_TIPO_USUARIO INTEGER NOT NULL,
 NM_USUARIO VARCHAR(100) NOT NULL,
 EMAIL_USUARIO VARCHAR(50) NOT NULL,
 SENHA_USUARIO CHAR(6) NOT NULL,
 DT_CADASTRO TIMESTAMP WITHOUT TIME ZONE NOT NULL,
 LINK_IMAGEM_USUARIO VARCHAR(300) NULL
);

ALTER TABLE USUARIO
ADD CONSTRAINT PK_USUARIO
PRIMARY KEY (ID_USUARIO);

ALTER TABLE USUARIO
ADD CONSTRAINT FK_USUARIO
FOREIGN KEY (ID_TIPO_USUARIO) REFERENCES TIPO_USUARIO(ID_TIPO_USUARIO);

ALTER TABLE USUARIO
ADD CONSTRAINT UK_USUARIO
UNIQUE (EMAIL_USUARIO);

----------------------------------------------------------------------

CREATE TABLE CURSO
(
 ID_CURSO SERIAL NOT NULL,
 TL_CURSO VARCHAR(50) NOT NULL,
 DS_CURSO VARCHAR(1000) NOT NULL,
 DT_CADASTRO TIMESTAMP WITHOUT TIME ZONE NOT NULL
);

ALTER TABLE CURSO
ADD CONSTRAINT PK_CURSO
PRIMARY KEY (ID_CURSO);

ALTER TABLE CURSO
ADD CONSTRAINT UK_CURSO
UNIQUE (TL_CURSO);

----------------------------------------------------------------------

CREATE TABLE USUARIO_CURSO
(
 ID_USUARIO SERIAL NOT NULL,
 ID_CURSO INTEGER NOT NULL,
 DT_CADASTRO TIMESTAMP WITHOUT TIME ZONE NOT NULL
);

ALTER TABLE USUARIO_CURSO
ADD CONSTRAINT PK_USUARIO_CURSO
PRIMARY KEY(ID_USUARIO, ID_CURSO);

ALTER TABLE USUARIO_CURSO
ADD CONSTRAINT FK_USUARIO_CURSO
FOREIGN KEY (ID_USUARIO) REFERENCES USUARIO(ID_USUARIO);

ALTER TABLE USUARIO_CURSO
ADD CONSTRAINT FK2_USUARIO_CURSO
FOREIGN KEY (ID_CURSO) REFERENCES CURSO(ID_CURSO);

----------------------------------------------------------------------

CREATE TABLE AULA
(
 ID_AULA SERIAL NOT NULL,
 TL_AULA VARCHAR(50) NOT NULL,
 DS_AULA VARCHAR(1000) NOT NULL,
 ID_CURSO INTEGER NOT NULL,
 LINK_AULA VARCHAR(300) NOT NULL,
 DT_CADASTRO TIMESTAMP WITHOUT TIME ZONE NOT NULL
);

ALTER TABLE AULA
ADD CONSTRAINT PK_AULA
PRIMARY KEY (ID_AULA);

ALTER TABLE AULA
ADD CONSTRAINT FK_AULA
FOREIGN KEY (ID_CURSO) REFERENCES CURSO(ID_CURSO);

ALTER TABLE AULA
ADD CONSTRAINT UK_AULA
UNIQUE(TL_AULA);

----------------------------------------------------------------------

CREATE TABLE USUARIO_AULA
(
 ID_USUARIO INTEGER NOT NULL,
 ID_AULA INTEGER NOT NULL,
 DT_CADASTRO TIMESTAMP WITHOUT TIME ZONE NOT NULL
);

ALTER TABLE USUARIO_AULA
ADD CONSTRAINT PK_USUARIO_AULA
PRIMARY KEY (ID_USUARIO, ID_AULA);

ALTER TABLE USUARIO_AULA
ADD CONSTRAINT FK_USUARIO_AULA
FOREIGN KEY (ID_AULA) REFERENCES AULA(ID_AULA);

ALTER TABLE USUARIO_AULA
ADD CONSTRAINT FK2_USUARIO_AULA
FOREIGN KEY (ID_USUARIO) REFERENCES USUARIO(ID_USUARIO);

----------------------------------------------------------------------

CREATE TABLE QUESTAO
(
 ID_QUESTAO SERIAL NOT NULL,
 DS_QUESTAO VARCHAR(1000) NOT NULL,
 ID_CURSO INTEGER NOT NULL,
 DT_CADASTRO TIMESTAMP WITHOUT TIME ZONE NOT NULL
);

ALTER TABLE QUESTAO
ADD CONSTRAINT PK_QUESTAO
PRIMARY KEY (ID_QUESTAO);

ALTER TABLE QUESTAO
ADD CONSTRAINT FK_QUESTAO
FOREIGN KEY (ID_CURSO) REFERENCES CURSO(ID_CURSO);

----------------------------------------------------------------------

CREATE TABLE RESPOSTA
(
 ID_RESPOSTA SERIAL NOT NULL,
 DS_RESPOSTA VARCHAR(1000) NOT NULL,
 FL_CORRETA BOOLEAN NOT NULL,
 ID_QUESTAO INTEGER NOT NULL,
 DT_CADASTRO TIMESTAMP WITHOUT TIME ZONE NOT NULL
);

ALTER TABLE RESPOSTA
ADD CONSTRAINT PK_RESPOSTA
PRIMARY KEY (ID_RESPOSTA);

ALTER TABLE RESPOSTA
ADD CONSTRAINT FK_RESPOSTA
FOREIGN KEY (ID_QUESTAO) REFERENCES QUESTAO(ID_QUESTAO);

----------------------------------------------------------------------


