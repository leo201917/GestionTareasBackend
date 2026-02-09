# Gestión de Tareas – Backend (.NET)

API REST para la gestión de tareas (listar, filtrar y ver detalle).  
Arquitectura basada en capas (estilo Clean Architecture) con Dapper y SQL Server.

---

## Requisitos

- .NET SDK (recomendado **.NET 6**)
- SQL Server (LocalDB / instancia local / SQL Server Express o superior)
- (Opcional) IIS para despliegue

---

## Arquitectura / Proyectos

La solución está separada en 4 proyectos:

- **GestionTareas.API**  
  Capa de presentación (Controllers, Swagger, DI)

- **GestionTareas.Aplicacion**  
  Casos de uso/servicios, DTOs e interfaces

- **GestionTareas.Dominio**  
  Entidades y enums (modelo de negocio)

- **GestionTareas.Infraestructura**  
  Persistencia (Dapper), conexión y repositorios

---

## Configuración

### 1) Connection String

Edita `appsettings.json` en `GestionTareas.API`:

**Ejemplo (SQL Server con usuario/clave):**
```json
{
  "ConnectionStrings": {
    "Default": "Data Source=DESKTOP-V62JRJ8\\SQL130;Initial Catalog=GestionTareasDB;User Id=sa;Password=TU_PASSWORD;"
  }
}
