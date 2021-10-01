using API.Models; // referencia da pasta com as models que receberá as açoes da classe DataContext
using Microsoft.EntityFrameworkCore; // 

namespace API.Data
{
    public class DataContext : DbContext // extendendo para classe DbContext pertecente ao EF
    {
    
     // Construtor da classe para que DbContext funcione
     // Recebe como parametro, uma funcionalidade da DbContext na qual 
     // é especificado dentro da mesma, a classe criada para trabalhar com a parte do banco de dados
     // Através deste construtor, libera as funcionalidades para fazer comandos SQL
       public DataContext(DbContextOptions<DataContext> options ) : base(options)
       {
           
       } 

      // Agora basta especificar qual modelo será comtemplado com as funcionalidades do EF
      public DbSet<Pessoa> pessoa { get; set;} 
      // Para cada modelo que for criado, teremos um public DbSet<nome do modelo>
      // nome do método seguido de um get e set
      // DataContext pode receber vários models não sendo necessário criar um DataContext para cada model
      // Agora já podemos apartir de uma rota, efetuar um (INSERT, SELECT,
      // UPDATE E DELETE) sem precisar escrever uma linha se quer de código SQL. 
    }
}