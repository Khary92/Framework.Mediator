# How to Use the Mediator

This guide explains how to integrate the **Mediator framework** into your solution.


## Prerequisites

- .NET SDK installed
- A solution containing the target project


## Setup Instructions

### 1. Clone the Repository

Clone the repository containing the framework:

```bash
git clone <repository-url>
```

### 2. Copy the Generator Project

Copy the project  
`Framework.Generator`  
into your solution.

### 3. Copy the Mediator Framework

Copy the folders from  
`Framework.Mediator`  
into your **target project**.

### 4. Update the `.csproj` File

Add the following `ProjectReference` to the implementing project’s `.csproj` file:

```xml
<ItemGroup>
   <ProjectReference Include="..\Framework.Generator\Framework.Generator.csproj"
                     OutputItemType="Analyzer"
                     ReferenceOutputAssembly="false" />
</ItemGroup>
```

This ensures the generator runs at build time without being referenced at runtime.

### 5. Register the Mediator and Handlers
```bash
services.AddSingleton<IMediator, Mediator>();
services.AddSingleton<IRequestHandler<SimpleRequest, SimpleResponse>, SimpleRequestHandler>();
```


### 6. Clean the Solution

```bash
dotnet clean
```

### 7. Restore Dependencies

```bash
dotnet restore
```


### 8. Build the Solution

```bash
dotnet build
```
## Done ✅

The Mediator framework is now integrated and ready to use.

