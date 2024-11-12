<h1>Entity Framework - Global Query Filter</h1>

<p>O Entity Framework disponibiliza uma maneira para que um filtro seja aplicável em todas as consultas, sem que haja a necessidade de repetir a mesma condição em cada consulta separadamente.</p>

<h2>Contexto</h2>

<p>Em determinadas casos, essa opção pode vir a ser muito útil pois uma determinada consulta na query SQL pode ser de extrema importância. Com isso, esquecer de aplicá-la pode retornar dados para um usuário nos quais ele não deveria ter acesso.</p>
<p>Um exemplo disso seria para aplicações Multi Tenancy em que o identificador do tenancy é um atributo comum em todas as tabela, a fim de saber quem é o dono daquele registro. Nesse cenário, seria `obrigatório` filtrar somente pelos registros que o Tenancy do request tem acesso.</p>


<h2>Exemplo</h2>

<p>No exemplo deste repositório, é aplicado um filtro comum para todas as consultas via Entity Framework. O dado para aplicar essa consulta vem de um informação que consta no request HTTP atual.</p>

<h3>IUserRequest - configurando as informações do usuário HTTP</h3>
<p>Serviço responsável por buscar o e-mail do usuário via `HEADER HTTP` (somente para fins de exemplo).</p>

```csharp
public class UserRequest : IUserRequest
{
    private readonly IHttpContextAccessor _contextAccessor;

    public UserRequest(IHttpContextAccessor contextAccessor)
    {
         _contextAccessor = contextAccessor;
    }

     public string Email => _contextAccessor.HttpContext?.Request.Headers["user-email"] ?? string.Empty;
}
```

<h3>DbContext - configurando o filtro global</h3>

  ```csharp
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        private readonly IUserRequest _userRequest;
        public DatabaseContext(DbContextOptions options, IUserRequest userRequest) : base(options)
        {
            _userRequest = userRequest;
        }

        public async Task<int> CommmitAsync(CancellationToken cancellationToken)
        {
            return await SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.Entity<Invoice>().HasQueryFilter(x => x.Owner == _userRequest.Email);
        }
    }
  ```

<p>No código acima, é adicionado via IoC o serviço `IUserRequest`. Com isso, é possível aplicar o filtro `global` de acordo com as informações do usuário pertencente ao request atual, deixando ele mais flexível.</p>

```csharp
modelBuilder.Entity<Invoice>().HasQueryFilter(x => x.Owner == _userRequest.Email);
```

<h3>DbContext - desabilitando o filtro global</h3>
<p>Para desabilitar o filtro global, para chamar o metódo `IgnoreQueryFilters`. Com isso, os filtros globais configurados serão ignorados na consulta.</p>

```csharp
  public async Task<IReadOnlyList<Invoice>> GetAllAsync(CancellationToken cancellationToken)
  {
     return await _invoices.IgnoreQueryFilters().ToListAsync(cancellationToken);
  }
```

![{6B2C5BBE-6C7A-4030-BA8F-D851BF2331A8}](https://github.com/user-attachments/assets/d9ec1479-0394-4d27-9804-d615b6ea3edb)

![{B23BB83A-D52F-4DDB-AB3F-7618A3EC25B9}](https://github.com/user-attachments/assets/0584fae8-c72f-4d01-9d6c-b781f354d17d)

![{C1FB0565-76D8-4280-B6A5-C1C9B57BE376}](https://github.com/user-attachments/assets/f3d1a038-f70c-44bc-b7d8-74934504fed7)

![{29256166-D5C5-4B99-A513-23F976CE5861}](https://github.com/user-attachments/assets/ef9b59e3-9eb4-49fc-a7da-48b21f7aa53a)

