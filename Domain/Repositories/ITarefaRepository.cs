using System;
using System.Collections.Generic;

namespace SistemaDeGestaoDeTarefas
{
    public interface ITarefaRepository
    {
       void Adicionar(Tarefa tarefa);
       
       Tarefa? BuscarPorId(int id);

       void Atualizar(Tarefa tarefa);

       void Remover(int id);
        
    }
}
