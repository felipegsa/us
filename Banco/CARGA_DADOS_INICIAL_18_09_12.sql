-- CARGA DE DADOS INICIAL 18/09/2012

INSERT INTO TIPO_USUARIO (DS_TIPO_USUARIO, DT_CADASTRO)
VALUES ('ADMINISTRADOR', CURRENT_TIMESTAMP), ('ALUNO', CURRENT_TIMESTAMP);

-----------------------------------------------------------------------------------------------

INSERT INTO USUARIO (ID_TIPO_USUARIO, NM_USUARIO, EMAIL_USUARIO, SENHA_USUARIO, DT_CADASTRO)
VALUES (1, 'admin', 'felipe_gsa@hotmail.com', '$unsof', CURRENT_TIMESTAMP);

-----------------------------------------------------------------------------------------------

INSERT INTO CURSO (TL_CURSO, DS_CURSO, OBJ_CURSO, TOPICOS_CURSO, PRE_REQ_CURSO, DURACAO_CURSO, DT_CADASTRO)
VALUES ('Estimativas métricas', 'Estimativas métricas', 'Objetivo do curso de Estimativas métricas', 'Tópicos do curso de Estimativas métricas', 'Pré-requisitos do curso de Estimativas métricas', '40 horas', CURRENT_TIMESTAMP),
       ('Qualidade de software', 'Qualidade de software', 'Objetivo do curso de Qualidade de software', 'Tópicos do curso de Qualidade de software', 'Pré-requisitos do curso de Qualidade de software', '50 horas', CURRENT_TIMESTAMP),
       ('Processos de software', 'Processos de software', 'Objetivo do curso de Processos de software', 'Tópicos do curso de Processos de software','Pré-requisitos do curso de Processos de software', '45 horas', CURRENT_TIMESTAMP),
       ('Padrões de software', 'Padrões de software', 'Objetivo do curso de Padrões de software', 'Tópicos do curso de Padrões de software', 'Pré-requisitos do curso de Padrões de software', '65 horas', CURRENT_TIMESTAMP),
       ('Teste de software', 'Teste de software', 'Objetivo do curso de Teste de software', 'Tópicos do curso de Teste de software', 'Pré-requisitos do curso de Teste de software', '35 horas', CURRENT_TIMESTAMP),
       ('Engenharia de requisitos', 'Engenharia de requisitos', 'Objetivo do curso de Engenharia de requisitos', 'Tópicos do curso de Engenharia de requisitos', 'Pré-requisitos do curso de Engenharia de requisitos', '60 horas', CURRENT_TIMESTAMP),
       ('Engenharia de projetos', 'Engenharia de projetos', 'Objetivo do curso de Engenharia de projetos', 'Tópicos do curso de Engenharia de projetos', 'Pré-requisitos do curso de Engenharia de projetos', '60 horas', CURRENT_TIMESTAMP),
       ('UML', 'UML', 'Objetivo do curso de UML', 'Tópicos do curso de UML', 'Pré-requisitos do curso de UML', '80 horas', CURRENT_TIMESTAMP),
       ('ITIL', 'ITIL', 'Objetivo do curso de ITIL', 'Tópicos do curso de ITIL', 'Pré-requisitos do curso de ITIL', '50 horas', CURRENT_TIMESTAMP),
       ('COBIT', 'COBIT', 'Objetivo do curso de COBIT', 'Tópicos do curso de COBIT', 'Pré-requisitos do curso de COBIT', '50 horas', CURRENT_TIMESTAMP),
       ('Arquitetura de software', 'Arquitetura de software', 'Objetivo do curso de Arquitetura de software', 'Tópicos do curso de Arquitetura de software', 'Pré-requisitos do curso de Arquitetura de software', '50 horas', CURRENT_TIMESTAMP);
-----------------------------------------------------------------------------------------------



