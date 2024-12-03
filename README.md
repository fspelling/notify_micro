# Event-Driven PoC com RabbitMQ e Webhooks

Este projeto é uma **Prova de Conceito (PoC)** que demonstra uma arquitetura baseada em eventos, utilizando **RabbitMQ** como broker de mensagens e **webhooks** para notificar eventos aos clientes integrados.

## Tecnologias Utilizadas

- **.NET**: Plataforma de desenvolvimento principal.
- **RabbitMQ**: Broker de mensagens para gerenciar filas e troca de mensagens.
- **MassTransit**: Framework para simplificar a comunicação com o RabbitMQ.
- **Redis**: Cache distribuído para armazenamento rápido.
- **EF Core**: ORM para gerenciamento de banco de dados.
- **FluentValidation**: Validação de objetos e dados de entrada.
- **Docker**: Containerização para ambiente de desenvolvimento local.

## Objetivo

- Implementar uma arquitetura baseada em eventos com foco em mensageria.
- Permitir que clientes cadastrados sejam notificados via **webhooks** sobre eventos específicos.
- Demonstrar boas práticas no uso de ferramentas de mensageria e integração.

## Funcionalidades

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

## Estrutura do Projeto

