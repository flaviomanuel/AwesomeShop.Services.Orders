# AwesomeShop.Services.Customers - Formação Microsserviços com ASP.NET Core

A arquitetura do AwesomeShop, sistema de e-commerce baseado na arquitetura de microsserviços, contém 6 microsserviços:

- Customers
- Products
- Orders
- Payments
- Notifications
- API Gateway

Todos os serviços acima foram utilizados nas regras de negocios do projeto

## Tecnologias, práticas e arquitetura utilizadas
- ASP.NET Core
- Arquitetura de Microsserviços
- Princípios do Domain-Driven Design
- MongoDB
- Clean Architecture
- CQRS
- RabbitMQ e arquitetura orientada a eventos
- API Gateway com Ocelot 
- Service Discovery com Consul
- Cache Com Redis

## Funcionalidades do Orders
- Cadastro
- Busca por Id
- Atualização de Status consumindo evento PaymentAccepted
