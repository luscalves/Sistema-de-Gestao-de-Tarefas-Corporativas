using System;
using SistemaDeGestaoDeTarefas.Domain.Entities;
using SistemaDeGestaoDeTarefas.Application.DTOs;

namespace SistemaDeGestaoDeTarefas.UseCases
{
    public class ConcluirTarefaUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public ConcluirTarefaUseCase(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        
        public TarefaResponseDTO Executar(int tarefaId){
            Tarefa? tarefa = _tarefaRepository.ObterPorId(tarefaId);
  
            if(tarefa == null){
                throw new Exception($"Tarefa com ID {tarefaId} não foi encontrada.");
            }
            
            tarefa.Concluir();
            
            _tarefaRepository.Atualizar(tarefa);
            
         var response = new TarefaResponseDTO{
            Id = tarefa.Id,
            Titulo = tarefa.Titulo,
            Descricao = tarefa.Descricao,
            Status = tarefa.Status.ToString(),
            DataCriacao = tarefa.DataCriacao,
            UsuarioAtribuidoId = tarefa.UsuarioAtribuidoId,
            MotivoBloqueio = tarefa.MotivoBloqueio
         }; 
         
         return response;
        }
    }
}

