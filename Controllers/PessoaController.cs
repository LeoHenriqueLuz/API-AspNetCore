using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
   // através da Anotation, informo p/ projeto que está classe é um controlador responsável pelas rotas.
   [Controller]
   [Route("[controller]")]

    public class PessoaController : ControllerBase
    {
       // é necessário criar um objeto do tipo DataContext para ter acesso as funçoes
       // de (Cadastro, Alteração, Seleção,Exclusão e outras funções.)
        private DataContext dc; // objeto

       // Toda vez que a ControllerPessoa for executada, é necessário pegar o DataContext e passar para objeto criado.
       // Construtor
       public PessoaController(DataContext context) // recebe um parametro do tipo DataContext
       {
           this.dc = context; // toda vez que PessoaController for chamado,o construtor 
           // vai pegar o objeto (dc) e adicionar o parametro (context) que vem da pasta Data.
       }
       /* O método abaixo de cadastro, usa async/await (assincrona) devido a necessidade de esperar que algumas partes do código seja executado
        e usando junto com funcionalidade Task que recebe um objeto ActionResult .
        No FrontEnd, sera enviado caracteristicas para efetuar cadastro como: nome, idade e cidade.
        Sendo assim, uso um comando da ControlleBase (FromBody) que permite capturar informações através (Body do front) 
        e crio uma variável do tipo do objeto que quero trabalhar.
       */
        [HttpPost("api")]
        public async Task<ActionResult> cadastrar([FromBody] Pessoa p)
        {
            // Preparando Cadastro
            // dc trabalha c/ pessoa usando método para adicionar o parametro Pessoa p.
           dc.pessoa.Add(p); 
           await dc.SaveChangesAsync(); 
           /* Enquanto Entity Framework não efetuar o cadastro, o await trava essa 
           linha de código não sendo possível proseguir. Assim que Ef realiza o cadastro, 
           é liberado para ler as linhas de código a seguir que no caso é 
           um retorno com status Created que da um ok e um feedback que deu tudo certo
           e return em formato Json do objeto Pessoa p já com id criado seguido do nome idade e cidade*/
           
           return Created("objeto pessoa", p);
        }

        [HttpGet("api")]

        public async Task<ActionResult> listar()
        {
           var dados = await dc.pessoa.ToListAsync();
           return Ok(dados);
           // variável vai funcionar como um vetor onde receberá todos os registros cadastrados no banco
           // await vai esperar todos os registros serem carregados 
           // DataContext vai buscar a Model pessoa e listar com a funcionalidade ToListAsync
           // Em seguida é retornado o status 200.
        }
        
        [HttpGet("api/{codigo}")]
        public Pessoa filtrar(int codigo)
        {
           Pessoa obj = dc.pessoa.Find(codigo);
           return obj;
            // Este método vai filtrar informações atravé de um id.
          // O método irá retornar um objeto e por isso declaro filtrar do tipo obj Pessoa
          // Como parametro, teremos a variável (codigo) que foi declarada no corpo da requisição HttpGet
          // em seguida crio um obj Pessoa que recebe o DataContext + model + método Find que ira filtrar 
          // Por fim, retorno do obj.
        }
        
        [HttpPut("api")]
        public async Task<ActionResult> editar([FromBody] Pessoa obj)
        {
           // Uso do Put, é preciso que no Front-End via (Body) seja passado todas as caracteristicas do objeto
           // Pessoa (id,name,city e age) e se não for passado, o Put não funciona.
           // Como parametro do método, teremos FromBody que espera receber um obj do tipo Pessoa
           // Chamo o DataContext seguindo da model que estou manipulando + método Update com obj que está vindo do FromBody.  
           dc.pessoa.Update(obj);
         await  dc.SaveChangesAsync(); // aqui nesta linha, vai travar e só vai executar as linhas seguintes
           // quando houver a alteração do registro no banco de dados.
        return Ok(obj);
           // Se der tudo certo, retornamos um status Ok com obj.
        }
        
        [HttpDelete("api/{codigo}")] 
        public async Task<ActionResult> remover(int codigo)
        {
           // Comando de remoção não remove por Id e sim por um obj completo
           // neste caso temos que passar um obj contendo todas as caracteristicas (id,name,city e age)
           // antes de remover, utilizo método filtrar() que retorna um obj do tipo Pessoa.
            Pessoa obj = filtrar(codigo);

            if(obj == null) // Se for  passado um código que não existe, retornará um status NotFound
            {
               return NotFound();
            } else 
            {
                dc.pessoa.Remove(obj);
                await dc.SaveChangesAsync();
                return Ok();
            }
        }
    }
}