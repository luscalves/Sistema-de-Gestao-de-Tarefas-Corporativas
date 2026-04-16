using System;
using System.Collections.Generic;
using SistemaDeGestaoDeTarefas.Domain.Entities;

namespace SistemaDeGestaoDeTarefas
{
    public interface ITarefaRepository
    {
       void Adicionar(Tarefa tarefa);
       
       Tarefa? ObterPorId(int id);
       void Atualizar(Tarefa tarefa);
       void Remover(Tarefa tarefa);
       IEnumerable<Tarefa> ObterTodas();
       
        
    }
}
