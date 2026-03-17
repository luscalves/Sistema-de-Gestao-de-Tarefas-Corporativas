using System;
using SistemaTarefasCorporativas.Entities;

namespace SistemaDeGestaoDeTarefas.UseCases
{
    public class ConcluirTarefaUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public ConcluirTarefaUseCase(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        
        public Tarefa Executar(int tarefaId){
            Tarefa? tarefa = _tarefaRepository.BuscarPorId(tarefaId);
  
            if(tarefa == null){
                throw new Exception($"Tarefa com ID {tarefaId} não foi encontrada.");
            }
            
            tarefa.Concluir();
            
            _tarefaRepository.Atualizar(tarefa);

            return tarefa;
        }
    }
}

