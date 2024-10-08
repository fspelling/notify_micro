declare @usuarioId varchar(450) = '123'

insert into Usuario
values(@usuarioId, 'Teste usuario', 'email@email.com', '123', '111111111')

insert into usuarioEmail
values('svfhsjfj', @usuarioId, 'template email geral', 'pt-br')

insert into usuarioSms
values('hfodfmkld', @usuarioId, 'template sms geral', 'pt-br')