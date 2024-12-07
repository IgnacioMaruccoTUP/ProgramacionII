# Proyecto Cine - CRUD de Funciones y Reservas
**UNIVERSIDAD TECNOLÓGICA NACIONAL**  

**FACULTAD REGIONAL CÓRDOBA**

**Tecnicatura Universitaria en Programacion** 

**Programación II**

**Trabajo Práctico Integrador**

**Comisión 1W1 - Grupo 5**  

## Integrantes

- **412152** – Giorda, Brunella de Lourdes
- **412304** – Guzmán Olariaga, Facundo Nicolás
- **412366** – Marucco, Ignacio
- **412488** – Mendoza, Eduardo
- **412092** – Murúa, Nicolás Agustín
- **412012** – Rago, Tomás

Este proyecto es un Trabajo Práctico Integrador (TPI) que consiste en el desarrollo de una SPA para gestionar un sistema de cine. El sistema incluye operaciones CRUD para la tabla de **funciones** y un esquema maestro-detalle para **reservas** y **entradas**. También implementa autenticación con **JWT** (JSON Web Token) para controlar el acceso a los recursos.

## Índice

- [Proyecto Cine - CRUD de Funciones y Reservas](#proyecto-cine---crud-de-funciones-y-reservas)
  - [Integrantes](#integrantes)
  - [Índice](#índice)
  - [Objetivos](#objetivos)
  - [Estructura del Proyecto](#estructura-del-proyecto)
  - [Tecnologías Utilizadas](#tecnologías-utilizadas)


## Objetivos

El objetivo principal es desarrollar un sistema para gestionar las operaciones de un cine. Esto incluye:
1. CRUD completo para la tabla de **funciones**, que almacena la información de las películas programadas en el cine.
2. Gestión de **reservas** y **entradas** mediante un modelo maestro-detalle, donde los usuarios pueden realizar reservas para diferentes funciones.
3. Implementación de un sistema de autenticación basado en **JWT** para proteger el acceso a las funcionalidades de administración y gestión.

## Estructura del Proyecto

- **Controllers**: Controladores para manejar las solicitudes HTTP.
- **Models**: Modelos de datos que representan las tablas `funciones`, `reservas` y `entradas`.
- **Data**: Contexto de base de datos configurado con Entity Framework Core.
- **Repositories**: Repositorios que interactúan con la base de datos.

## Tecnologías Utilizadas

- **C#** y **.NET 8** para el backend
- **Entity Framework Core** para ORM y manejo de datos
- **SQL Server** como base de datos
- **JWT** para autenticación y autorización de usuarios
