using ExemploApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Jogo{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), Nome = "Fifa 21", Ano = 2021, Produtora = "EA", Preco = 200} },
            {Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), new Jogo{ Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), Nome = "Fifa 20", Ano = 2020, Produtora = "EA", Preco = 190} },
            {Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), new Jogo{ Id = Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), Nome = "Fifa 19", Ano = 2019, Produtora = "EA", Preco = 180} },
            {Guid.Parse("da033439-f352-4539-879f-515759312d53"), new Jogo{ Id = Guid.Parse("da033439-f352-4539-879f-515759312d53"), Nome = "Fifa 18", Ano = 2018, Produtora = "EA", Preco = 170} },
            {Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), new Jogo{ Id = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), Nome = "Street Fighter V", Ano = 2016, Produtora = "Capcom", Preco = 80} },
            {Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), new Jogo{ Id = Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), Nome = "Grand Theft Auto V", Ano = 2013, Produtora = "Rockstar", Preco = 190} },
            {Guid.Parse("b7b312c7-ab05-4cc6-bbf5-f795c99eff26"), new Jogo{ Id = Guid.Parse("b7b312c7-ab05-4cc6-bbf5-f795c99eff26"), Nome = "The long dark", Ano = 2014, Produtora = "HinterLand Studio inc", Preco = 20} },
            {Guid.Parse("2779b01a-ed97-41e7-bb5f-88eca57e1454"), new Jogo{ Id = Guid.Parse("2779b01a-ed97-41e7-bb5f-88eca57e1454"), Nome = "Outer Wilds", Ano = 2019, Produtora = "Mobius digital", Preco = 47} },
            {Guid.Parse("db98425e-e33b-46ce-834a-1bb1d4399dde"), new Jogo{ Id = Guid.Parse("db98425e-e33b-46ce-834a-1bb1d4399dde"), Nome = "Undertale", Ano = 2015, Produtora = "lobyfox", Preco = 5.99} },
            
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return Task.FromResult<Jogo>(null);

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();

            foreach(var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco
        }
    }
}
