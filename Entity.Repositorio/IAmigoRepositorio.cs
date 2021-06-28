using System.Collections.Generic;

namespace Entity.Repositorio
{
    public interface IAmigoRepositorio
    {
        List<Domain.Amigo> AniversariantesDoDiaDB();
        void AtualizarDB(Domain.Amigo amigo, int idAmigo);
        void CadastrarDB(Domain.Amigo amigo);
        void DeletarDB(int idAmigo);
        Domain.Amigo GetAmigoDB(int idAmigo);
        List<Domain.Amigo> GetAmigoNomeDB(string nome);
        List<Domain.Amigo> PegarTodosDB();
    }
}