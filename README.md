# Event-Driven PoC com RabbitMQ e Webhooks

Este projeto é uma **Prova de Conceito (PoC)** que demonstra uma arquitetura baseada em eventos, utilizando **RabbitMQ** como broker de mensagens e **webhooks** para notificar eventos aos clientes integrados.

---

## ⚒️ Tecnologias Utilizadas

- **.NET**: Plataforma de desenvolvimento principal.
- **RabbitMQ**: Broker de mensagens para gerenciar filas e troca de mensagens.
- **MassTransit**: Framework para simplificar a comunicação com o RabbitMQ.
- **Redis**: Cache distribuído para armazenamento rápido.
- **EF Core**: ORM para gerenciamento de banco de dados.
- **FluentValidation**: Validação de objetos e dados de entrada.
- **Refit**: gerencia e facilita o consumo de APIs Rest.
- **Docker**: Containerização para ambiente de desenvolvimento local.

---

## 📋 Objetivo

- Implementar uma arquitetura baseada em eventos com foco em mensageria.
- Permitir que clientes cadastrados sejam notificados via **webhooks** sobre eventos específicos.
- Demonstrar boas práticas no uso de ferramentas de mensageria e integração.

---

## 📲 Funcionalidades

1. **Publicação de Eventos**:
   - Aplicação publica mensagens no RabbitMQ ao ocorrerem eventos significativos.

2. **Processamento de Mensagens**:
   - Mensagens na fila são consumidas e processadas com o **MassTransit**.

3. **Notificação via Webhook**:
   - Clientes cadastrados recebem notificações HTTP sobre os eventos.

4. **Gerenciamento de Cache**:
   - **Redis** é usado para armazenar informações temporárias, como estados de mensagens.

5. **Validação**:
   - Todas as entradas de dados passam por validações com o **FluentValidation**.

---

## 🌐 Fluxo geral do sistema

1. **Publicação do Evento**:
   - O evento `PagamentoCreatedEvent` é publicado pelo `Poc.NotifyPublish` na mensageria (**RabbitMQ**).

2. **Orquestração**:
   - O `Poc.NotifyOrchestrator` consome o evento e realiza:
     - A geração de comandos para o envio de notificações (e-mail, SMS).
     - O envio de notificações via webhook para os clientes registrados.

3. **Envio de Notificações**:
   - O `Poc.NotifySend` consome os comandos de notificação e realiza o envio efetivo das mensagens.

4. **Consumo pelo Cliente**:
   - A API `Poc.NotifyMicro.WebhookClient` simula um cliente que recebe as notificações via webhook e processa conforme necessário.

---

## 📁 Estrutura do Projeto

A PoC é organizada de forma modular, separando os micro serviços de negócio principais dos serviços de cliente. Essa estrutura permite escalabilidade, manutenibilidade e reutilização de código.

### **projects/Services**
Contém todos os micro serviços de negócio integrados à mensageria, responsáveis pelo fluxo de eventos e comandos.

- **Poc.Messaging.Library**  
  Biblioteca compartilhada que define todas as mensagens do tipo **event** e **command** utilizadas na mensageria.  
  Utilizada por todos os micro serviços para garantir a padronização da comunicação e dos contratos de mensagens.

- **Poc.NotifyPublish**  
  API principal que publica o evento `PagamentoCreatedEvent` na mensageria (**RabbitMQ**).  
  Este serviço simula o início do fluxo de pagamento, gerando eventos consumidos pelos demais serviços.

- **Poc.NotifyOrchestrator**  
  Micro serviço responsável por consumir mensagens do evento `PagamentoCreatedEvent` e gerenciar o fluxo de mensagens do tipo **command** para os serviços de notificações.  
  **Responsabilidades principais:**
  - Orquestrar o envio de notificações (e-mail, SMS, etc.).
  - Enviar requisições para os **webhooks** registrados.

- **Poc.NotifySend**  
  Micro serviço dedicado ao consumo de mensagens de notificação enviadas pelo `Poc.NotifyOrchestrator`.  
  Realiza o envio efetivo de notificações como **e-mail** e **SMS**.

### **projects/ClientServices**
Contém as APIs de clientes que simulam o consumo de notificações enviadas pelos webhooks.

- **Poc.NotifyMicro.WebhookClient**  
  API de teste que simula a integração de um cliente com o sistema.  
  Consome as notificações enviadas pelos webhooks, validando o fluxo de entrega e o comportamento esperado do cliente ao receber mensagens.

---

## 🔍 Requisitos

- Docker e Docker Compose instalados.
- RabbitMQ e Redis configurados via Docker Compose.
- *SDK do .NET 6 ou superior* instalado para desenvolvimento e testes locais.

---

## 🔧 Configuração

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/sua-poc.git
   cd sua-poc
   ```
1. Configure as varíaveis de ambiente do rabbitmq se necessário no arquivo docker-compose.yaml:
   ```bash
   environment:
     RABBITMQ_DEFAULT_USER: guest
     RABBITMQ_DEFAULT_PASS: guest
   ```
3. Suba os containers com Docker Compose:
   ```bash
   docker-compose up -d
   ```
---

## 💫 Exemplos de Uso

1. Cadastrar um Cliente Webhook:
   - Envie uma requisição POST para `/api/Webhook/Register` com o paylod:
   
   ```bash
   {
     "endpoint": "meuEndpoint/notificacao",
     "event": "PagamentoCreatedEvent"
   }
   ```

2. Realizar o "pagamento":
   - Envie uma requisição POST para `/api/Pagamento` com o paylod:
   
   ```bash
   {
     "usuarioID": "123",
     "formaPagamento": 1
   }
   ```

3. Receber notificação do pagamento:
   - Após um evento a ser publicado, os clientes cadastrados receberão notificações no formato:
   
   ```bash
   {
     "EventName": "PagamentoCreatedEvent",
     "data": {
         "UsuarioId": "123",
         "FormaPagamento": "PIX",
         "DataCriacao": "2024-12-01",
     }
   }
   ```

---

## 📌 Proximos Passos

- Adicioanr autenticação para os webhooks.
- Implementar mecanismo de retry para notificações com falhas.

---

## 📫 Contribuições
Contribuições são bem-vindas! Sinta-se à vontade para abrir uma issue ou enviar um pull request.

---

## 📃 Licença
Este projeto está licenciado sob a MIT License.
